using RabbitMQ.Client;

namespace RabbitMQ_WEbComparative.Models
{
    public class RabbitMQViewModel
    {
        public List<string>? CustomerName { get; set; }
       
        public RabbitMQViewModel()
        {
            CustomerName = new List<string>();
        }

        public void ConvertList(string names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                CustomerName.Add(names[i].ToString());
            }

        }
        public void SendMessageQueue()
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

                List<string> message = GetListNameFile();
                var body = message.SelectMany(s => System.Text.Encoding.UTF8.GetBytes(s + Environment.NewLine)).ToArray();
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: "",
                                     routingKey: "ListNames",
                                     basicProperties: null,
                                     body: body);
            }
            
        }

        

        public List<string> GetListNameFile()
        {
            var filename = "C:\\Users\\Tecnologia7.ERITELTELECOM\\source\\PersonalProject\\RabbitMQ_WEbComparative\\RabbitMQ_WEbComparative\\Docs\\Names.txt";
            var lines = File.ReadAllLines(filename);
            List<string> list = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                list.Add(lines[i]);
            }
            return list;
        }
    }

 

    
}
