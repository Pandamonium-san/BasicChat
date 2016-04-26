//Henrik Phan, AE3413
//Malmö Högskola
//2016-01-09
namespace BasicChatClient
{
    partial class ClientForm
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
            this.txBoxMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txBoxIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.txBoxName = new System.Windows.Forms.TextBox();
            this.txBoxLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstBoxUsers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // txBoxMsg
            // 
            this.txBoxMsg.Enabled = false;
            this.txBoxMsg.Location = new System.Drawing.Point(12, 269);
            this.txBoxMsg.MaxLength = 140;
            this.txBoxMsg.Name = "txBoxMsg";
            this.txBoxMsg.Size = new System.Drawing.Size(306, 20);
            this.txBoxMsg.TabIndex = 0;
            this.txBoxMsg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txBoxMsg_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(327, 267);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(76, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(324, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txBoxIP
            // 
            this.txBoxIP.Location = new System.Drawing.Point(12, 25);
            this.txBoxIP.Name = "txBoxIP";
            this.txBoxIP.Size = new System.Drawing.Size(120, 20);
            this.txBoxIP.TabIndex = 4;
            this.txBoxIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(139, 25);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(53, 20);
            this.numPort.TabIndex = 8;
            this.numPort.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // txBoxName
            // 
            this.txBoxName.Location = new System.Drawing.Point(198, 25);
            this.txBoxName.MaxLength = 20;
            this.txBoxName.Name = "txBoxName";
            this.txBoxName.Size = new System.Drawing.Size(120, 20);
            this.txBoxName.TabIndex = 9;
            // 
            // txBoxLog
            // 
            this.txBoxLog.BackColor = System.Drawing.SystemColors.Window;
            this.txBoxLog.Location = new System.Drawing.Point(12, 51);
            this.txBoxLog.Multiline = true;
            this.txBoxLog.Name = "txBoxLog";
            this.txBoxLog.ReadOnly = true;
            this.txBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBoxLog.Size = new System.Drawing.Size(265, 210);
            this.txBoxLog.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Username";
            // 
            // lstBoxUsers
            // 
            this.lstBoxUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstBoxUsers.FormattingEnabled = true;
            this.lstBoxUsers.Location = new System.Drawing.Point(283, 51);
            this.lstBoxUsers.Name = "lstBoxUsers";
            this.lstBoxUsers.Size = new System.Drawing.Size(120, 210);
            this.lstBoxUsers.TabIndex = 12;
            this.lstBoxUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBoxUsers_MouseDoubleClick);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 301);
            this.Controls.Add(this.lstBoxUsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txBoxLog);
            this.Controls.Add(this.txBoxName);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txBoxIP);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txBoxMsg);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txBoxMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txBoxIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TextBox txBoxName;
        private System.Windows.Forms.TextBox txBoxLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxUsers;


    }
}

