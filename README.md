# TcpClientHandler / TcpServer

The `TcpServer` class is a robust and easy-to-use TCP server implementation in C# that allows for handling multiple client connections, sending and receiving various types of data, and managing client connections efficiently.

The `TcpClientHandler` class is a versatile TCP client implementation for .NET applications that allows for easy sending and receiving of different types of data over a network. It supports sending text messages, photos, and XML content, as well as handling disconnections.

## Features TcpServer

- **Handle Multiple Clients**: Manage multiple client connections simultaneously.
- **Send and Receive Data**: Support for sending and receiving text messages, images, and XML content.
- **Event-Driven Architecture**: Utilize events to handle received data, client connections, and disconnections.
- **Thread-Safe Client Management**: Safely manage client connections using locks and thread-safe collections.

## Features TcpClientHandler

- **Send Text Messages**: Send text data to a connected TCP server.
- **Receive Data**: Asynchronously receive text, photo, or XML data.
- **Event-Driven**: Utilize events to handle received data and disconnections.
- **Custom Delegates**: Define custom event handlers for various data types.

# Usage 

 Before you can handle client connections or send and receive messages, you need to start the server. Here's how to get the server running:

 **Instantiate the Server**:
   Create an instance of the `TcpServer` class by specifying the port number you want the server to listen on. "you may need to allow connection".
