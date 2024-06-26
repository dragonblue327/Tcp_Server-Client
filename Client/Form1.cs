using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;


namespace Client
{
	public partial class Form1 : Form
	{
		private TcpClientHandler clientHandler;
		public Form1()
		{
			InitializeComponent();
			Task.Run(() => NewConnection());
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			
			
		}
		private void NewConnection()
		{
			clientHandler = new TcpClientHandler(HostIP.Text, Int32.Parse(Port.Text));

			// Subscribe to events
			clientHandler.MessageReceived += OnMessageReceived;
			clientHandler.PhotoReceived += OnPhotoReceived;
			clientHandler.XmlReceived += OnXmlReceived;
			clientHandler.Disconnected += OnDisconnected;
			clientHandler.MessageSent += OnMessageSent;

			// Start receiving data 
			try
			{
				Task.Run(() => clientHandler.StartReceiving());
				UpdateConnectionStatus(true);
				
			}
			catch { }

		}

		
		private void OnMessageSent(string message)
		{
			// Update the UI to reflect that the message was sent
			Invoke(new Action(() =>
			{
				massagebox.AppendText($"Message sent: {message}" + Environment.NewLine);
			}));
		}

		private void UpdateConnectionStatus(bool isConnected)
		{
			// Update the connection status on the form
			lblConnectionStatus.Text = isConnected ? "Connected" : "Disconnected";
			if(isConnected)
			{
				
				lblConnectionStatus.ForeColor = Color.Green;
				button1.Enabled = false;
				button2.Enabled = true;
			}
			else
			{
				
				lblConnectionStatus.ForeColor = Color.Red;
				button1.Enabled = true;
				button2.Enabled = false;
			}
		}
		

		
		private void OnMessageReceived(string message)
		{
			
			// Update the UI with the received message
			Invoke(new Action(() =>
			{
				massagebox.AppendText("Server: "+message + Environment.NewLine);
			}));
		
		}
		private void OnPhotoReceived(Image photo)
		{
			this.Invoke(new Action(() =>
			{
				pictureBox.Image = photo;
			}));
		}

		private void OnXmlReceived(string xmlContent)
		{
			// Invoke the method on the UI thread
			this.Invoke(new Action(() =>
			{
				txtMessage.Text = xmlContent;
			}));
		}

		private void OnDisconnected()
		{
			// Invoke the method on the UI thread
			this.Invoke(new Action(() =>
			{
				UpdateConnectionStatus(false);
			}));
		}


		private void btnSendText_Click(object sender, EventArgs e)
		{
			string messageToSend = txtMessage.Text; 
			clientHandler.SendMessage(messageToSend);
			txtMessage.Text = string.Empty;
		}

		
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			clientHandler.Disconnect();
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			NewConnection();
			button2.Enabled = true;
			button1.Enabled = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			clientHandler.Disconnect();
			button2.Enabled = false;
			button1.Enabled = true;
		}
		
		
	}
	
	
}
