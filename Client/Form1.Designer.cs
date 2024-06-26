using System;

namespace Client
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
			this.massagebox = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.Port = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.HostIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblConnectionStatus = new System.Windows.Forms.Label();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnSendText = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.lstClients = new System.Windows.Forms.ComboBox();
			this.Count = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// massagebox
			// 
			this.massagebox.Location = new System.Drawing.Point(21, 74);
			this.massagebox.Multiline = true;
			this.massagebox.Name = "massagebox";
			this.massagebox.ReadOnly = true;
			this.massagebox.Size = new System.Drawing.Size(520, 154);
			this.massagebox.TabIndex = 13;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(447, 33);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 23);
			this.button2.TabIndex = 12;
			this.button2.Text = "Disconnect";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(169, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 16);
			this.label2.TabIndex = 11;
			this.label2.Text = "Port:";
			// 
			// Port
			// 
			this.Port.Location = new System.Drawing.Point(215, 30);
			this.Port.Name = "Port";
			this.Port.Size = new System.Drawing.Size(100, 22);
			this.Port.TabIndex = 10;
			this.Port.Text = "3128";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(350, 33);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(91, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Connect";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// HostIP
			// 
			this.HostIP.Location = new System.Drawing.Point(67, 30);
			this.HostIP.Name = "HostIP";
			this.HostIP.Size = new System.Drawing.Size(100, 22);
			this.HostIP.TabIndex = 8;
			this.HostIP.Text = "127.0.0.1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Host:";
			// 
			// lblConnectionStatus
			// 
			this.lblConnectionStatus.AutoSize = true;
			this.lblConnectionStatus.Location = new System.Drawing.Point(412, 9);
			this.lblConnectionStatus.Name = "lblConnectionStatus";
			this.lblConnectionStatus.Size = new System.Drawing.Size(89, 16);
			this.lblConnectionStatus.TabIndex = 14;
			this.lblConnectionStatus.Text = "Not Conected";
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(21, 235);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(444, 22);
			this.txtMessage.TabIndex = 15;
			// 
			// btnSendText
			// 
			this.btnSendText.Location = new System.Drawing.Point(471, 235);
			this.btnSendText.Name = "btnSendText";
			this.btnSendText.Size = new System.Drawing.Size(75, 23);
			this.btnSendText.TabIndex = 16;
			this.btnSendText.Text = "Send";
			this.btnSendText.UseVisualStyleBackColor = true;
			this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(437, 74);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(110, 154);
			this.pictureBox.TabIndex = 17;
			this.pictureBox.TabStop = false;
			// 
			// lstClients
			// 
			this.lstClients.FormattingEnabled = true;
			this.lstClients.Location = new System.Drawing.Point(56, 3);
			this.lstClients.Name = "lstClients";
			this.lstClients.Size = new System.Drawing.Size(128, 24);
			this.lstClients.TabIndex = 18;
			// 
			// Count
			// 
			this.Count.AutoSize = true;
			this.Count.Location = new System.Drawing.Point(294, 6);
			this.Count.Name = "Count";
			this.Count.Size = new System.Drawing.Size(0, 16);
			this.Count.TabIndex = 19;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 268);
			this.Controls.Add(this.Count);
			this.Controls.Add(this.lstClients);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.btnSendText);
			this.Controls.Add(this.txtMessage);
			this.Controls.Add(this.lblConnectionStatus);
			this.Controls.Add(this.massagebox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Port);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.HostIP);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.TextBox massagebox;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Port;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox HostIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblConnectionStatus;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnSendText;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ComboBox lstClients;
		private System.Windows.Forms.Label Count;
	}
}

