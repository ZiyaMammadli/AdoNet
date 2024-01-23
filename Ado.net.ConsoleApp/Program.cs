using Ado.netCore.Entities;
using System.Text.Json;
Console.WriteLine("Hello, World!");

string connString = @"Server=WIN-PRIFU0D7GO7\SQLEXPRESS;Database=PersonDb;Trusted_Connection=true;";
HttpClient client = new HttpClient();
string result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
Console.WriteLine(result);

using (HttpClient client2 = new HttpClient())
{
    string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
    List<Post>? DbPost = JsonSerializer.Deserialize<List<Post>>(response);
}

