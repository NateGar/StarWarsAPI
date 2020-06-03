using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Lab28_SWAPI.Models
{
    public class SwapiDAL
    {
        public string GetAPIJson(string endpoint, int Id)
        {
            string url = $"https://swapi.dev/api/{endpoint}/{Id}/";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string output = sr.ReadToEnd();
            return output;

        }

        public Person GetPersonbyId(string endpoint, int Id)
        {
            string personData = GetAPIJson(endpoint, Id);
            Person p = JsonConvert.DeserializeObject<Person>(personData);

            return p;
        }

        public Planet GetPlanetbyId(string endpoint, int Id)
        {
            string planetData = GetAPIJson(endpoint, Id);
            Planet p = JsonConvert.DeserializeObject<Planet>(planetData);

            return p;
        }

    }
}
