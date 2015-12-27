using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BonApp.Model;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BonApp.Data
{
    public class AzureDataAccess
    {
        private HttpClient client;

        public AzureDataAccess()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://bonapp2.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            HttpResponseMessage response = await client.GetAsync("api/recipes");
            var recipes = new List<Recipe>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);
            }
            return recipes;


            /*string json = await response.Content.ReadAsStringAsync();
            var listRecipes = Newtonsoft.Json.JsonConvert.DeserializeObject<Recipe[]>(json);
            return listRecipes.ToList<Recipe>();*/
        }

    }
}
