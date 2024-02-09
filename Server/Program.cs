using System.Net;

string serverAddress = "http://localhost:8080/";

HttpListener listener = new HttpListener();
listener.Prefixes.Add(serverAddress);

Console.WriteLine($"HTTP sunucu çalışıyor...");

listener.Start();

while (true)
{
    HttpListenerContext context = listener.GetContext();
    HttpListenerRequest request = context.Request;
    HttpListenerResponse response = context.Response;
    string text = "";

    if (request.HasEntityBody)
    {
        System.IO.Stream body = request.InputStream;
        StreamReader reader = new StreamReader(body);
        text = reader.ReadToEnd();
        Console.WriteLine($"Request body : {text}");
    }

    string responseString = text == "" ? "Mesaj gelmedi" : $"{DateTime.Now} -- Bu mesajı attınız : {text}";
    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);

    response.ContentLength64 = buffer.Length;
    System.IO.Stream output = response.OutputStream;
    output.Write(buffer, 0, buffer.Length);
    output.Close();
}

