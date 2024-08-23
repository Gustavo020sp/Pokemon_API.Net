using RestSharp;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using Pokemon_API.Entities;
using Microsoft.VisualBasic;
using Pokemon_API.Controller;

namespace Pokemon_API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TamagotchiController interaction = new TamagotchiController();

            interaction.GenerateInteraction();            
        }        
    }
}
