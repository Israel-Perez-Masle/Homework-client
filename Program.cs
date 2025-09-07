using Microsoft.AspNetCore.SignalR.Client;
using entities;
using System.Text.Json;


class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://54.197.45.169:5000/chatHub")
            .WithAutomaticReconnect()
            .Build();

        connection.On<string>("ReceiveMessage", (message) =>
        {
            Console.WriteLine($"{message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Connected to chat!");

        Console.Write("Enter your name: ");
        var name = Console.ReadLine();
        List<Message> messageHistory = new List<Message>();

        while (true)
        {
            var msg = Console.ReadLine();
            Message message = new Message(msg,name);
            string jsonString = JsonSerializer.Serialize(message);
            Console.Write(jsonString);
           

            if (msg?.ToLower() == "exit") break;

            await connection.InvokeAsync("SendMessage",jsonString);
        }
    }
}
