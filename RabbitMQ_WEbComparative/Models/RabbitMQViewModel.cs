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
