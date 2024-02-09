using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory factory = new();
IConnection connection = factory.CreateConnection();
IModel channel = connection.CreateModel();


channel.QueueDeclare(queue: "hello",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);


var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" Server tarafından gönderilen mesaj  :  {message}");
};

channel.BasicConsume(queue: "hello",
                        autoAck: true,
                        consumer: consumer);


Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
