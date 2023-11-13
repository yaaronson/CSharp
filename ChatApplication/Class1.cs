using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Server
{
    private TcpListener tcpListener;
    private List<ChatClient> clients = new List<ChatClient>();

    public void Start()
    {
        tcpListener = new TcpListener(IPAddress.Any, 8888);
        tcpListener.Start();
        Console.WriteLine("Server started...");

        while (true)
        {
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            ChatClient client = new ChatClient(tcpClient, this);
            clients.Add(client);

            Thread clientThread = new Thread(new ThreadStart(client.HandleClient));
            clientThread.Start();
        }
    }

    public void BroadcastMessage(string message, ChatClient sender)
    {
        foreach (var client in clients)
        {
            if (client != sender)
            {
                client.SendMessage($"{sender.Username}: {message}");
            }
        }
    }

    public void RemoveClient(ChatClient client)
    {
        clients.Remove(client);
    }
}

class ChatClient
{
    private TcpClient tcpClient;
    private Server server;
    private NetworkStream clientStream;
    private string username;

    public string Username { get { return username; } }

    public ChatClient(TcpClient tcpClient, Server server)
    {
        this.tcpClient = tcpClient;
        this.server = server;
        this.clientStream = tcpClient.GetStream();
    }

    public void HandleClient()
    {
        Console.WriteLine("New client connected.");

        // Get the username from the client
        username = ReadMessage();

        // Notify all clients about the new user
        server.BroadcastMessage($"{username} has joined the chat.", this);

        // Listen for messages from the client
        while (true)
        {
            string message = ReadMessage();
            if (message == null)
                break;

            // Broadcast the message to all clients
            server.BroadcastMessage(message, this);
        }

        // Remove the client when they disconnect
        server.RemoveClient(this);
        server.BroadcastMessage($"{username} has left the chat.", this);

        tcpClient.Close();
        Console.WriteLine($"{username} disconnected.");
    }

    public void SendMessage(string message)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
        clientStream.Write(data, 0, data.Length);
        clientStream.Flush();
    }

    private string ReadMessage()
    {
        byte[] data = new byte[256];
        int bytesRead = clientStream.Read(data, 0, data.Length);
        if (bytesRead == 0)
            return null;

        return System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
    }
}

partial class Program
{
    static void Main(string[] args)
    {
        Server server = new Server();
        server.Start();
    }
}

