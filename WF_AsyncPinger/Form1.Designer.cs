namespace WF_AsyncPinger
{
    partial class Form1
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
            this.tbResults = new System.Windows.Forms.TextBox();
            this.btPingSync = new System.Windows.Forms.Button();
            this.tbInputIP = new System.Windows.Forms.TextBox();
            this.lblInputIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInputPorts = new System.Windows.Forms.TextBox();
            this.btPingAsync = new System.Windows.Forms.Button();
            this.btTelnetSync = new System.Windows.Forms.Button();
            this.btTelnetAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbResults
            // 
            this.tbResults.Location = new System.Drawing.Point(286, 25);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.Size = new System.Drawing.Size(497, 295);
            this.tbResults.TabIndex = 0;
            // 
            // btPingSync
            // 
            this.btPingSync.Location = new System.Drawing.Point(812, 25);
            this.btPingSync.Name = "btPingSync";
            this.btPingSync.Size = new System.Drawing.Size(109, 23);
            this.btPingSync.TabIndex = 1;
            this.btPingSync.Text = "SendPingSync";
            this.btPingSync.UseVisualStyleBackColor = true;
            this.btPingSync.Click += new System.EventHandler(this.btPingSync_Click);
            // 
            // tbInputIP
            // 
            this.tbInputIP.Location = new System.Drawing.Point(29, 25);
            this.tbInputIP.Multiline = true;
            this.tbInputIP.Name = "tbInputIP";
            this.tbInputIP.Size = new System.Drawing.Size(158, 295);
            this.tbInputIP.TabIndex = 2;
            this.tbInputIP.Text = "192.168.0.220\r\n192.168.0.221\r\n192.168.0.222";
            // 
            // lblInputIP
            // 
            this.lblInputIP.AutoSize = true;
            this.lblInputIP.Location = new System.Drawing.Point(75, 9);
            this.lblInputIP.Name = "lblInputIP";
            this.lblInputIP.Size = new System.Drawing.Size(43, 13);
            this.lblInputIP.TabIndex = 3;
            this.lblInputIP.Text = "IP input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ports input";
            // 
            // tbInputPorts
            // 
            this.tbInputPorts.Location = new System.Drawing.Point(193, 25);
            this.tbInputPorts.Multiline = true;
            this.tbInputPorts.Name = "tbInputPorts";
            this.tbInputPorts.Size = new System.Drawing.Size(75, 295);
            this.tbInputPorts.TabIndex = 4;
            this.tbInputPorts.Text = "80\r\n400\r\n443";
            // 
            // btPingAsync
            // 
            this.btPingAsync.Location = new System.Drawing.Point(812, 54);
            this.btPingAsync.Name = "btPingAsync";
            this.btPingAsync.Size = new System.Drawing.Size(109, 23);
            this.btPingAsync.TabIndex = 6;
            this.btPingAsync.Text = "SendPingAsync";
            this.btPingAsync.UseVisualStyleBackColor = true;
            this.btPingAsync.Click += new System.EventHandler(this.btPingAsync_Click);
            // 
            // btTelnetSync
            // 
            this.btTelnetSync.Location = new System.Drawing.Point(812, 83);
            this.btTelnetSync.Name = "btTelnetSync";
            this.btTelnetSync.Size = new System.Drawing.Size(109, 23);
            this.btTelnetSync.TabIndex = 7;
            this.btTelnetSync.Text = "TelnetSync";
            this.btTelnetSync.UseVisualStyleBackColor = true;
            this.btTelnetSync.Click += new System.EventHandler(this.btTelnetSync_Click);
            // 
            // btTelnetAsync
            // 
            this.btTelnetAsync.Location = new System.Drawing.Point(812, 112);
            this.btTelnetAsync.Name = "btTelnetAsync";
            this.btTelnetAsync.Size = new System.Drawing.Size(109, 23);
            this.btTelnetAsync.TabIndex = 8;
            this.btTelnetAsync.Text = "TelnetAsync";
            this.btTelnetAsync.UseVisualStyleBackColor = true;
            this.btTelnetAsync.Click += new System.EventHandler(this.btTelnetAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 334);
            this.Controls.Add(this.btTelnetAsync);
            this.Controls.Add(this.btTelnetSync);
            this.Controls.Add(this.btPingAsync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbInputPorts);
            this.Controls.Add(this.lblInputIP);
            this.Controls.Add(this.tbInputIP);
            this.Controls.Add(this.btPingSync);
            this.Controls.Add(this.tbResults);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Button btPingSync;
        private System.Windows.Forms.TextBox tbInputIP;
        private System.Windows.Forms.Label lblInputIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInputPorts;
        private System.Windows.Forms.Button btPingAsync;
        private System.Windows.Forms.Button btTelnetSync;
        private System.Windows.Forms.Button btTelnetAsync;
    }
}

