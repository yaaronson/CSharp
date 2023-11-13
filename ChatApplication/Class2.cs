using System;
using System.Net.Sockets;
using System.Threading;

class Client
{
    private TcpClient tcpClient;
    private NetworkStream clientStream;

    public void Start()
    {
        tcpClient = new TcpClient("127.0.0.1", 8888);
        clientStream = tcpClient.GetStream();

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        SendMessage(username);

        Thread receiveThread = new Thread(new ThreadStart(ReceiveMessages));
        receiveThread.Start();

        Console.WriteLine($"Welcome, {username}! Start chatting:");

        while (true)
        {
            string message = Console.ReadLine();
            SendMessage(message);
        }
    }

    private void ReceiveMessages()
    {
        while (true)
        {
            string message = ReadMessage();
            if (message == null)
                break;

            Console.WriteLine(message);
        }
    }

    private void SendMessage(string message)
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

    static void Main(string[] args)
    {
        Client client = new Client();
        client.Start();
    }
}

