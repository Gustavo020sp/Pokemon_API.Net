using RestSharp;
using static System.Net.WebRequestMethods;

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
                Console.WriteLine("Opções de pokémon:");
                Console.WriteLine("Bulbasaur [1]" + Environment.NewLine + "Ivysaur [2]" + Environment.NewLine + "Venusaur [3]");
                Console.Write("Digite o número que deseja > ");

                response = Convert.ToInt32(Console.ReadLine());

                if (response > 3)
                {
                    Console.WriteLine("Choose a valid pokémon number." + Environment.NewLine);
                }

                else
                {
                    if (response == 1)
                    {
                        pokemon_url = $"https://pokeapi.co/api/v2/pokemon/1/";
                    }
                    if (response == 2)
                    {
                        pokemon_url = $"https://pokeapi.co/api/v2/pokemon/2/";
                    }
                    if (response == 3)
                    {
                        pokemon_url = $"https://pokeapi.co/api/v2/pokemon/3/";
                    }
                    //Invoke Get method
                    InvokeGet(pokemon_url);
                }

            } while (response > 3);
        }
        public static void InvokeGet(string pokemon_url)
        {
            var client = new RestSharp.RestClient(pokemon_url);
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Assuming response.Content is a JSON string
                var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);

                // Serialize back to formatted JSON
                string formattedJson = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject, Newtonsoft.Json.Formatting.Indented);

                Console.WriteLine($"{response.Content}");
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }
    }
}
