using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ATEA.console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ATEA console->Web application stored on Github!");
            var message = ConstructMessage();
            PostMessage(message).Wait();
        }

        public static ConsoleMessage ConstructMessage()
        {
            Console.WriteLine("Please construct a message..");
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Body: ");
            var body = Console.ReadLine();

            ConsoleMessage message = new ConsoleMessage { Title = title, Body = body, Date = DateTime.Now };
            return message;
        }

        static async Task PostMessage(ConsoleMessage message)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50046/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HTTP POST
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Messages", message);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    Uri messageUrl = response.Headers.Location;
                }
            }
        }
    }
}
