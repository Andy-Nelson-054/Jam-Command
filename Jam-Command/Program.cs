using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jam_Command
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {

            Console.WriteLine("Press any key to send request");
            Console.ReadLine();

            string clientId = "36b9cf32018546d2979476d378b56292";
            //string clientSecret = "";
            string responseType = "code";
            string redirectUri = "https://github.com/Andy-Nelson-054";
            string options = String.Concat(
                $"?client_id={clientId}" +
                $"&response_type={responseType}" +
                $"&redirect_uri={redirectUri}"
                );

            client.BaseAddress = new Uri("https://accounts.spotify.com/authorize");

            var tokenData = new
            {
                grant_type = "client_credentials"
            };

            //base 64 encoded string required. Like this?
            var tokenHeader = new
            {
                Authorization = "Basic <base64 encoded clientId:clientSecret>"
            };

            //call async network methods
            try
            {
                string responseBody = await client.GetStringAsync(options);

                Console.WriteLine("Success: ");
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught:");
                Console.WriteLine("\nMessage:{0} ", e.Message);
            }
        }


    }
}

