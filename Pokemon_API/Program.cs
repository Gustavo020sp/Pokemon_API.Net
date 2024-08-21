using RestSharp;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using Pokemon_API.Entities;
using Microsoft.VisualBasic;

namespace Pokemon_API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int response = 0;
            string pokemon_url = "";

            do
            {
                Console.WriteLine("Pokémon options:");
                Console.WriteLine("Bulbasaur [1]" + Environment.NewLine + "Ivysaur [2]" + Environment.NewLine + "Venusaur [3]" + Environment.NewLine + "Charmander [4]");
                Console.Write("Enter a pokémon number > ");

                response = Convert.ToInt32(Console.ReadLine());

                if (response == 0 || response > 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose a valid pokémon number." + Environment.NewLine);
                }

                else
                {
                    switch (response)
                    {
                        case 1:
                            pokemon_url = $"https://pokeapi.co/api/v2/pokemon/1/";
                            break;
                        case 2:
                            pokemon_url = $"https://pokeapi.co/api/v2/pokemon/2/";
                            break;
                        case 3:
                            pokemon_url = $"https://pokeapi.co/api/v2/pokemon/3/";
                            break;
                        case 4:
                            pokemon_url = $"https://pokeapi.co/api/v2/pokemon/4";
                            break;
                    }

                    InvokeGet(pokemon_url);
                }

            } while (response == 0 || response > 3);
        }

        public static void InvokeGet(string pokemon_url)
        {
            var client = new RestSharp.RestClient(pokemon_url);
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                // Parse my JSON object
                var jsonObject = JsonSerializer.Deserialize<Mascot>(response.Content);

                //Returns the formated string in the Mascot class
                Console.WriteLine($"{jsonObject}".ToString());
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }
    }
}
