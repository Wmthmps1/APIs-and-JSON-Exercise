using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIs_and_JSON_Exercise
{
    public class Quote
    {
        private HttpClient _client;


        public Quote(HttpClient client)
        {
            _client = client;
        }

        public string Kanye()
        {
            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            return kanyeQuote;
        }

        public string Ron()
        {
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = _client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse);

            return ronQuote[0].ToString();
        }
    }
}

