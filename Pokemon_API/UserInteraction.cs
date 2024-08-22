using Pokemon_API.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemon_API
{
    public class UserInteraction
    {
        public void GenerateInteraction()
        {
            int mascotnumber = 0;
            string pokemon_url = "";
            string pokemon_name = "";
            int response;
            bool has_mascot = false;

            Console.WriteLine("#######");
            Console.WriteLine("   #     ##     #    #    ##      ####      ####    #####   ####    #    #  #");
            Console.WriteLine("   #    #  #    ##  ##   #  #    #     #   #    #     #    #    #   #    #  #");
            Console.WriteLine("   #   #    #   # ## #  #    #   #         #    #     #    #        ######  #");
            Console.WriteLine("   #   ######   #    #  ######   #   ###   #    #     #    #        #    #  #");
            Console.WriteLine("   #   #    #   #    #  #    #   #     #   #    #     #    #    #   #    #  #");
            Console.WriteLine("   #   #    #   #    #  #    #    ####      ####      #     ####    #    #  #");

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("What is your name?" + Environment.NewLine + "> ");
            string name = Console.ReadLine();


            //-----PRIMEIRA ETAPA-----//
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------MENU------------------------------------");
            Console.Write(name + ", Do you wish:"
                + Environment.NewLine + "1 - Adopt a virtual mascot"
                + Environment.NewLine + "2 - See your mascots"
                + Environment.NewLine + "3 - Quit"
                + Environment.NewLine + "> ");

            int answer = Convert.ToInt32(Console.ReadLine());

            //-----SEGUNDA ETAPA-----//
            switch (answer)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------- ADOPT MASCOT ------------------------------");
                        Console.WriteLine(name + ", Choose a species: ");
                        Console.WriteLine("Bulbasaur [1]" + Environment.NewLine + "Ivysaur [2]" + Environment.NewLine + "Venusaur [3]" + Environment.NewLine + "Charmander [4]");
                        Console.Write("Enter a pokémon number > ");

                        mascotnumber = Convert.ToInt32(Console.ReadLine());

                        if (mascotnumber == 0 || mascotnumber > 4)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Choose a valid pokémon number." + Environment.NewLine);
                        }

                        else
                        {
                            switch (mascotnumber)
                            {
                                case 1:
                                    pokemon_url = $"https://pokeapi.co/api/v2/pokemon/1/";
                                    pokemon_name = "Bulbasour";
                                    break;
                                case 2:
                                    pokemon_url = $"https://pokeapi.co/api/v2/pokemon/2/";
                                    pokemon_name = "Ivysaur";
                                    break;
                                case 3:
                                    pokemon_url = $"https://pokeapi.co/api/v2/pokemon/3/";
                                    pokemon_name = "Venusaur";
                                    break;
                                case 4:
                                    pokemon_url = $"https://pokeapi.co/api/v2/pokemon/4";
                                    pokemon_name = "Charmander";
                                    break;
                            }


                            //------TERCEIRA ETAPA-----//
                            do
                            {
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("--------------------------------------------------------------------------------");
                                Console.Write(name + ", Do you wish:"
                                    + Environment.NewLine + "1 - MORE INFORMATION ABOUT " + pokemon_name
                                    + Environment.NewLine + "2 - ADOPT " + pokemon_name
                                    + Environment.NewLine + "3 - BACK"
                                    + Environment.NewLine + "> ");

                                response = Convert.ToInt32(Console.ReadLine());                                
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("---------------------------------------------------------------------------------");

                                switch (response)
                                {
                                    case 1:
                                        InvokeGet(pokemon_url);
                                        continue;
                                    case 2:
                                        has_mascot = true;
                                        Console.WriteLine(name + ", Mascot successfully adopted, the egg is hatching!!! .......");
                                        Console.WriteLine("       _____ ");
                                        Console.WriteLine("      /     \\ ");
                                        Console.WriteLine("     /       \\ ");
                                        Console.WriteLine("    /         \\ ");
                                        Console.WriteLine("   /           \\ ");
                                        Console.WriteLine("  /             \\ ");
                                        Console.WriteLine(" /               \\ ");
                                        Console.WriteLine(" |    \\   /     | ");
                                        Console.WriteLine("  \\    \\ /     / ");
                                        Console.WriteLine("   \\   (_)    / ");
                                        Console.WriteLine("    \\       / ");
                                        Console.WriteLine("     \\_____/ ");
                                        break;

                                    default:
                                        Console.WriteLine("Invalid option, please try again.");
                                        break;
                                }
                            } while (response != 2 && response != 3);
                        }
                    } while (mascotnumber == 0 || mascotnumber > 3);
                    break;
                case 2:
                    if (has_mascot == false)
                    {
                        Console.WriteLine("You have no mascots yet!!");
                    }
                    else
                    {
                        InvokeGet(pokemon_url);
                    }
                    break;
            }

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
        }
    }
}

