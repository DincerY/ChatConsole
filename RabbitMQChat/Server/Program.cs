using System.Text;
using RabbitMQ.Client;


ConnectionFactory factory = new ConnectionFactory();
IConnection connection = factory.CreateConnection();


IModel channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
    durable: false,
    exclusive: false,
    autoDelete:false,
    arguments:null);


Console.WriteLine("Çıkmak için hiç bir string değer yazmadan enter tuşuna basın");

while (true)
{
    Console.Write("Mesaj Yazın : ");
    string message = Console.ReadLine();
    if (string.IsNullOrEmpty(message))
    {
        break;
    }
    var body = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: string.Empty,
        routingKey: "hello",
        basicProperties: null,
        body: body);
}

