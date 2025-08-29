using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://54.197.45.169:5000/chatHub")
            .WithAutomaticReconnect()
            .Build();

        connection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            Console.WriteLine($"{user}: {message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Connected to chat!");

        Console.Write("Enter your name: ");
        var name = Console.ReadLine();

        while (true)
        {
            var msg = Console.ReadLine();
            if (msg?.ToLower() == "exit") break;

            await connection.InvokeAsync("SendMessage", name, msg);
        }
    }
}
