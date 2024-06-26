using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class TcpClientHandler
{
	private TcpClient tcpClient;
	private NetworkStream networkStream;

	public delegate void MessageReceivedEventHandler(string message);
	public delegate void PhotoReceivedEventHandler(Image photo);
	public delegate void XmlReceivedEventHandler(string xmlContent);
	public delegate void DisconnectedEventHandler();
	public delegate void MessageSentEventHandler(string message);

	public event MessageReceivedEventHandler MessageReceived;
	public event PhotoReceivedEventHandler PhotoReceived;
	public event XmlReceivedEventHandler XmlReceived;
	public event DisconnectedEventHandler Disconnected;
	public event MessageSentEventHandler MessageSent;

	public TcpClientHandler(string ipAddress, int port)
	{
		tcpClient = new TcpClient(ipAddress, port);
		networkStream = tcpClient.GetStream();
	}

	public void SendMessage(string message)
	{
		if (tcpClient == null || !tcpClient.Connected)
		{
			Console.WriteLine("Cannot send message. No connection established.");
			return;
		}

		try
		{
			NetworkStream networkStream = tcpClient.GetStream();
			byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
			byte[] lengthPrefix = BitConverter.GetBytes(messageBuffer.Length);
			byte messageType = 0x01; // Assuming 0x01 is the message type for text

			networkStream.Write(new byte[] { messageType }, 0, 1); // Write the message type
			networkStream.Write(lengthPrefix, 0, lengthPrefix.Length); // Write the length prefix
			networkStream.Write(messageBuffer, 0, messageBuffer.Length); // Write the actual message
			networkStream.Flush();

			// Raise the MessageSent event
			MessageSent?.Invoke(message);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error sending message: " + ex.Message);
		}
	}

	public async Task StartReceiving()
	{
		try
		{
			while (tcpClient.Connected)
			{
				// Read the message type
				byte[] messageTypeBuffer = new byte[1];
				await networkStream.ReadAsync(messageTypeBuffer, 0, 1);
				byte messageType = messageTypeBuffer[0];

				// Read the length prefix
				byte[] lengthPrefixBuffer = new byte[4];
				await networkStream.ReadAsync(lengthPrefixBuffer, 0, 4);
				int messageLength = BitConverter.ToInt32(lengthPrefixBuffer, 0);

				// Read the actual message
				byte[] messageBuffer = new byte[messageLength];
				await networkStream.ReadAsync(messageBuffer, 0, messageLength);

				using (MemoryStream ms = new MemoryStream(messageBuffer))
				{
					switch (messageType) // First byte indicates the data type
					{
						case 0x01: // Text message
							string textMessage = Encoding.UTF8.GetString(messageBuffer, 0, messageLength);
							MessageReceived?.Invoke(textMessage);
							break;
						case 0x02: // Photo
							Image photo = Image.FromStream(ms);
							PhotoReceived?.Invoke(photo);
							break;
						case 0x03: // XML
							string xmlContent = Encoding.UTF8.GetString(messageBuffer, 0, messageLength);
							XmlReceived?.Invoke(xmlContent);
							break;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error receiving data: " + ex.Message);
			Disconnected?.Invoke();
		}
	}

	public void Disconnect()
	{
		tcpClient.Close();
		Disconnected?.Invoke();
	}
}
