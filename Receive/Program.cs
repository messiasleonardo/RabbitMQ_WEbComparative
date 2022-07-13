// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_WEbComparative.Models;
using System.Text;



var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "ListNames",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        Console.WriteLine(" [x] Received {0}", message);

        //RabbitMQViewModel rabbit = new RabbitMQViewModel();
        //rabbit.ConvertList(message);
    };
    channel.BasicConsume(queue: "ListNames",
                         autoAck: true,
                         consumer: consumer);
    Console.ReadLine();
}
