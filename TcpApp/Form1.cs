using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpApp
{
	public partial class Form1 : Form
	{
		
		
		private TcpServer tcpServer;
		public Form1()
		{
			InitializeComponent();
			Task.Run(() => run());
		}	
		private void run()
		{
			tcpServer = new TcpServer(Int32.Parse(PortText.Text));
			tcpServer.MessageReceived += Server_MessageReceived;
			tcpServer.PhotoReceived += TcpServer_PhotoReceived;
			tcpServer.XmlReceived += TcpServer_XmlReceived;
			tcpServer.ConnectionChanged += TcpServer_ConnectionChanged;
			tcpServer.ClientDisconnected += TcpServer_ClientDisconnected;
			tcpServer.MessageSent += TcpServer_MessageSent;
		}
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void TcpServer_MessageSent(TcpClient client, string message)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<TcpClient, string>(TcpServer_MessageSent), client, message);
				return;
			}

		}
		private void UpdateClientList()
		{
			// Check if the current thread is not the UI thread
			if (InvokeRequired)
			{
				// Use BeginInvoke to avoid waiting for the UI thread
				BeginInvoke(new MethodInvoker(() =>
				{
					// This code will run on the UI thread
					lstClients.Items.Clear();
					foreach (var clientId in tcpServer.GetClientIds())
					{
						lstClients.Items.Add(clientId);
					}
				}));
			}
			else
			{
				// If we're on the UI thread, update the list directly
				lstClients.Items.Clear();
				foreach (var clientId in tcpServer.GetClientIds())
				{
					lstClients.Items.Add(clientId);
				}
			}
		}
		private void Server_MessageReceived(string message)
		{
			// Update the UI with the received message
			Invoke(new Action(() =>
			{
				Received.AppendText("Client: " + message + Environment.NewLine);
			}));
		}

		private void TcpServer_PhotoReceived(Image photo)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<Image>(TcpServer_PhotoReceived), photo);
				return;
			}

			// Update the form controls to display the photo
			 pictureBoxReceived.Image = photo;
		}

		private void TcpServer_XmlReceived(string xmlContent)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(TcpServer_XmlReceived), xmlContent);
				return;
			}

			// Update the form controls to display the XML content
			 Received.Text += xmlContent;
		}
		private void TcpServer_ConnectionChanged(int connectionCount)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<int>(TcpServer_ConnectionChanged), connectionCount);
			
				return;
			}
			// Update UI with the current connection count
			Count.Text = connectionCount.ToString();
			UpdateClientList();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string messageToSend = textMass.Text;
			// Assuming you have a ListBox with connected clients and their IDs
			if (lstClients.SelectedItem != null)
			{
				string selectedClientId = lstClients.SelectedItem.ToString();
				tcpServer.SendMessageToClient(selectedClientId, messageToSend);
			}
			else
			{
				MessageBox.Show("Please select a client to send the message to.");
			}

			textMass.Text = string.Empty;
			Received.Text += messageToSend + "\n"; // Append the sent message to the Received TextBox
		}
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);

			tcpServer.Stop();
			this.Close();
		}
		private void TcpServer_ClientDisconnected(string clientId)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(TcpServer_ClientDisconnected), clientId);
				return;
			}

			// Update the form controls to reflect the client disconnection
			// For example, remove the client from a ListBox displaying connected clients
			lstClients.Items.Remove(clientId);
			// Optionally, display a message or log the disconnection
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}
	}
}

