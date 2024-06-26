namespace TcpApp
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
			this.label1 = new System.Windows.Forms.Label();
			this.HostTaxt = new System.Windows.Forms.TextBox();
			this.PortText = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Received = new System.Windows.Forms.TextBox();
			this.textMass = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.pictureBoxReceived = new System.Windows.Forms.PictureBox();
			this.lstClients = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Count = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceived)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Host:";
			// 
			// HostTaxt
			// 
			this.HostTaxt.Location = new System.Drawing.Point(72, 30);
			this.HostTaxt.Name = "HostTaxt";
			this.HostTaxt.Size = new System.Drawing.Size(100, 22);
			this.HostTaxt.TabIndex = 1;
			this.HostTaxt.Text = "127.0.0.1";
			// 
			// PortText
			// 
			this.PortText.Location = new System.Drawing.Point(220, 30);
			this.PortText.Name = "PortText";
			this.PortText.Size = new System.Drawing.Size(100, 22);
			this.PortText.TabIndex = 3;
			this.PortText.Text = "3128";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(174, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Port:";
			// 
			// Received
			// 
			this.Received.Location = new System.Drawing.Point(12, 131);
			this.Received.Multiline = true;
			this.Received.Name = "Received";
			this.Received.ReadOnly = true;
			this.Received.Size = new System.Drawing.Size(520, 127);
			this.Received.TabIndex = 6;
			// 
			// textMass
			// 
			this.textMass.Location = new System.Drawing.Point(12, 273);
			this.textMass.Multiline = true;
			this.textMass.Name = "textMass";
			this.textMass.Size = new System.Drawing.Size(420, 33);
			this.textMass.TabIndex = 7;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(438, 283);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(91, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "Send";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// pictureBoxReceived
			// 
			this.pictureBoxReceived.Location = new System.Drawing.Point(428, 131);
			this.pictureBoxReceived.Name = "pictureBoxReceived";
			this.pictureBoxReceived.Size = new System.Drawing.Size(100, 126);
			this.pictureBoxReceived.TabIndex = 9;
			this.pictureBoxReceived.TabStop = false;
			// 
			// lstClients
			// 
			this.lstClients.FormattingEnabled = true;
			this.lstClients.Location = new System.Drawing.Point(326, 30);
			this.lstClients.Name = "lstClients";
			this.lstClients.Size = new System.Drawing.Size(128, 24);
			this.lstClients.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Conected Clients :";
			// 
			// Count
			// 
			this.Count.AutoSize = true;
			this.Count.Location = new System.Drawing.Point(147, 86);
			this.Count.Name = "Count";
			this.Count.Size = new System.Drawing.Size(14, 16);
			this.Count.TabIndex = 12;
			this.Count.Text = "0";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 306);
			this.Controls.Add(this.Count);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lstClients);
			this.Controls.Add(this.pictureBoxReceived);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textMass);
			this.Controls.Add(this.Received);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.PortText);
			this.Controls.Add(this.HostTaxt);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxReceived)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox HostTaxt;
		private System.Windows.Forms.TextBox PortText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Received;
		private System.Windows.Forms.TextBox textMass;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.PictureBox pictureBoxReceived;
		private System.Windows.Forms.ComboBox lstClients;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label Count;
	}
}

