HttpClient client = new();

Uri requestUri = new Uri("http://localhost:8080");
client.BaseAddress = requestUri;

Console.WriteLine("Http Client Çalışıyor...");

while (true)
{
    Console.WriteLine("Mesajı giriniz:");
    string contet = Console.ReadLine();
    var content = new StringContent(contet);
    var result = await client.PostAsync("/", content);
    string resultContent = await result.Content.ReadAsStringAsync();
    Console.WriteLine(resultContent);
    Console.WriteLine("\n");
}


