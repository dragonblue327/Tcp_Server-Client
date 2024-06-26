using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Linq;


	public class TcpServer
	{
		public delegate void MessageReceivedEventHandler(string message);
		public delegate void PhotoReceivedEventHandler(Image photo);
		public delegate void XmlReceivedEventHandler(string xmlContent);
		public delegate void ConnectionChangedEventHandler(int connectionCount);
		public delegate void MessageSentEventHandler(TcpClient client, string message);
		public delegate void ClientDisconnectedEventHandler(string clientId);

		public event ClientDisconnectedEventHandler ClientDisconnected;
		public event MessageReceivedEventHandler MessageReceived;
		public event PhotoReceivedEventHandler PhotoReceived;
		public event XmlReceivedEventHandler XmlReceived;
		public event ConnectionChangedEventHandler ConnectionChanged;
		public event MessageSentEventHandler MessageSent;

		private TcpListener tcpListener;
		private Thread listenThread;
		private Dictionary<string, TcpClient> connectedClients = new Dictionary<string, TcpClient>();
		private Dictionary<TcpClient, string> reverseClientLookup = new Dictionary<TcpClient, string>();
		private int clientIdCounter = 0;
		private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

		public TcpServer(int port)
		{
			tcpListener = new TcpListener(IPAddress.Any, port);
			listenThread = new Thread(new ThreadStart(ListenForClients));
			listenThread.Start();
		}
		public IEnumerable<string> GetClientIds()
		{
			// Create a snapshot of the keys to ensure thread safety
			return connectedClients.Keys.ToArray();

		}
		private void ListenForClients()
		{
			tcpListener.Start();

			try
			{
				while (!cancellationTokenSource.IsCancellationRequested)
				{
					TcpClient client = tcpListener.AcceptTcpClient();
					string clientId = "Client" + clientIdCounter++;
					lock (connectedClients)
					{
						connectedClients.Add(clientId, client);
						ConnectionChanged?.Invoke(connectedClients.Count);
					}
					Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
					clientThread.Start(client);
				}
			}
			catch (SocketException ex)
			{
				Console.WriteLine($"SocketException: {ex.Message}");
			}
			finally
			{
				tcpListener.Stop();
			}
		}

		public void Stop()
		{
			cancellationTokenSource.Cancel();
			listenThread.Join();

			foreach (var client in connectedClients.Values)
			{
				client.Close();
			}
			connectedClients.Clear();
		}

		public void SendMessageToClient(string clientId, string message)
		{
			if (!connectedClients.TryGetValue(clientId, out TcpClient client) || !client.Connected)
			{
				Console.WriteLine($"Client with ID {clientId} is not connected.");
				return;
			}

			NetworkStream stream = client.GetStream();
			if (stream.CanWrite)
			{
				byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
				byte[] lengthPrefix = BitConverter.GetBytes(messageBuffer.Length);
				byte messageType = 0x01; // Assuming 0x01 is the message type for text

				stream.Write(new byte[] { messageType }, 0, 1); // Write the message type
				stream.Write(lengthPrefix, 0, lengthPrefix.Length); // Write the length prefix
				stream.Write(messageBuffer, 0, messageBuffer.Length); // Write the actual message
				stream.Flush();

				// Raise the MessageSent event
				MessageSent?.Invoke(client, message);
			}
		}

		private void HandleClientComm(object client)
		{
			TcpClient tcpClient = (TcpClient)client;
			NetworkStream clientStream = tcpClient.GetStream();

			try
			{
				byte[] lengthBuffer = new byte[4];
				int totalBytesRead = 0;
				while (totalBytesRead < 4)
				{
					int bytesRead = clientStream.Read(lengthBuffer, totalBytesRead, 4 - totalBytesRead);
					if (bytesRead == 0)
					{
						throw new Exception("Client disconnected.");
					}
					totalBytesRead += bytesRead;
				}

				int messageLength = BitConverter.ToInt32(lengthBuffer, 0);
				byte[] messageBuffer = new byte[messageLength];
				totalBytesRead = 0;
				while (totalBytesRead < messageLength)
				{
					int bytesRead = clientStream.Read(messageBuffer, totalBytesRead, messageLength - totalBytesRead);
					if (bytesRead == 0)
					{
						throw new Exception("Client disconnected.");
					}
					totalBytesRead += bytesRead;
				}

				using (MemoryStream ms = new MemoryStream(messageBuffer))
				{
					switch (messageBuffer[0]) // First byte indicates the data type
					{
						case 0x01: // Text message
							string message = Encoding.UTF8.GetString(messageBuffer, 1, messageLength - 1);
							MessageReceived?.Invoke(message);
							break;
						case 0x02: // Photo
							Image photo = Image.FromStream(ms);
							PhotoReceived?.Invoke(photo);
							break;
						case 0x03: // XML
							string xmlContent = Encoding.UTF8.GetString(messageBuffer, 1, messageLength - 1);
							XmlReceived?.Invoke(xmlContent);
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			finally
			{
				// Assuming you have a way to get the client's ID from the TcpClient object
				// For example, you could use a reverse lookup dictionary or store the ID as a property of TcpClient
				string clientId = GetClientIdFromTcpClient(tcpClient); // Implement this method based on your setup

				lock (connectedClients)
				{
					if (clientId != null && connectedClients.ContainsKey(clientId))
					{
						connectedClients.Remove(clientId);
						ConnectionChanged?.Invoke(connectedClients.Count);
					}
				}
				tcpClient.Close();
			}


		}

		private string GetClientIdFromTcpClient(TcpClient tcpClient)
		{
			if (tcpClient != null && reverseClientLookup.TryGetValue(tcpClient, out string clientId))
			{
				return clientId;
			}
			return null; // Client ID not found, or tcpClient is null
		}
		public void DisconnectClient(TcpClient tcpClient)
		{
			string clientId = GetClientIdFromTcpClient(tcpClient);
			if (clientId != null)
			{
				lock (connectedClients)
				{
					connectedClients.Remove(clientId);
					reverseClientLookup.Remove(tcpClient);
					ConnectionChanged?.Invoke(connectedClients.Count);
					ClientDisconnected?.Invoke(clientId); // Raise the ClientDisconnected event
				}
				tcpClient.Close();
			}
		}
	}



