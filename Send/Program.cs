// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ_WEbComparative.Models;
using System.Text;

RabbitMQViewModel model = new RabbitMQViewModel();
if (model.Valid)
{

    var factory = new ConnectionFactory() { HostName = "localhost" };
    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "ListNames",
                                      durable: true,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);

        List<string> message = model.GetListNameFile();
        var body = message.SelectMany(s => System.Text.Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        channel.BasicPublish(exchange: "",
                             routingKey: "ListNames",
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);
    }

}
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
