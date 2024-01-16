using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace APIsAndJSON
{

    public class OpenWeatherMapAPI
    {
        
        public double Weather(string city, string apiKey)
        {
            var client = new HttpClient();
            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";

            
            var result = client.GetStringAsync(weatherURL).Result;
            var temp = double.Parse(JObject.Parse(result)["main"]["temp"].ToString());
            
            return temp;
        }

    }
}

