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
            UserInteraction interaction = new UserInteraction();

            interaction.GenerateInteraction();            
        }        
    }
}
