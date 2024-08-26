namespace LOLRAT_V2
{
    partial class Screensharing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            lblTitle = new Label();
            btnToggleUDP = new Button();
            btnSnap = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Location = new Point(14, 55);
            pictureBox.Margin = new Padding(3, 4, 3, 4);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(887, 529);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(149, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(138, 28);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Screensharing:";
            // 
            // btnToggleUDP
            // 
            btnToggleUDP.Location = new Point(790, 12);
            btnToggleUDP.Margin = new Padding(3, 4, 3, 4);
            btnToggleUDP.Name = "btnToggleUDP";
            btnToggleUDP.Size = new Size(111, 35);
            btnToggleUDP.TabIndex = 2;
            btnToggleUDP.Text = "Start UDP";
            btnToggleUDP.UseVisualStyleBackColor = true;
            btnToggleUDP.Click += btnToggleUDP_Click;
            // 
            // btnSnap
            // 
            btnSnap.Location = new Point(14, 16);
            btnSnap.Margin = new Padding(3, 4, 3, 4);
            btnSnap.Name = "btnSnap";
            btnSnap.Size = new Size(128, 31);
            btnSnap.TabIndex = 3;
            btnSnap.Text = "Take screenshot!";
            btnSnap.UseVisualStyleBackColor = true;
            btnSnap.Click += btnSnap_Click;
            // 
            // Screensharing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnSnap);
            Controls.Add(btnToggleUDP);
            Controls.Add(lblTitle);
            Controls.Add(pictureBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Screensharing";
            Text = "Screensharing";
            FormClosing += Screensharing_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Label lblTitle;
        private Button btnToggleUDP;
        private Button btnSnap;
    }
}