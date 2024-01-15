using System;
using System.Collections.Generic;
using System.Net.Http;
using APIs_and_JSON_Exercise;
using Newtonsoft.Json.Linq;
using System.IO;


namespace APIsAndJSON
{
    public class Program
    {

        static void Main(string[] args)
        {
            var client = new HttpClient();
            var quote = new Quote(client);
            string key = File.ReadAllText("appsettings.json");
            string apiKey = JObject.Parse(key).GetValue("APIKey").ToString();
            var weather = new OpenWeatherMapAPI();

            Console.WriteLine("Would you like to:");
            Console.WriteLine("1. Check the Weather");
            Console.WriteLine("2. View a simulated conversation between Kanye West and Ron Swanson");
            Console.WriteLine("Type 1 or 2");
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                Console.WriteLine("Enter the name of the city you would like to get the current temperature for: ");
                string cityName = Console.ReadLine();
                double temp = weather.Weather(cityName, apiKey);

                Console.WriteLine($"The current temperature in {cityName} is {temp} degrees Fahrenheit");
            }

            else if (userInput == 2)
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Kanye: {quote.Kanye()}");
                    Console.WriteLine($"Ron: {quote.Ron()}");
                    Console.WriteLine("");
                }



        }
    }
}