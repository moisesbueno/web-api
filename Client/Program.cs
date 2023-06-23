// See https://aka.ms/new-console-template for more information
using var client = new HttpClient();

var result = await client.GetStringAsync("http://localhost:5000/api/book");


Console.WriteLine(result);
Console.ReadKey();
