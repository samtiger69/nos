using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace nosee.Models
{
    public class ApiCaller : IDisposable
    {
        private HttpClient client;

        public ApiCaller()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://webservicesapi.apphb.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void Dispose()
        {
            client.Dispose();
        }

        public List<Item> GetAllItems()
        {
            var result = new List<Item>();

            HttpResponseMessage response = client.GetAsync("api/Values").Result;
            if (response.IsSuccessStatusCode)
            {
                var items = response.Content.ReadAsAsync<List<Item>>().Result;
                foreach (var item in items)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public Item GetItemById(int itemId)
        {
            var result = new Item();

            HttpResponseMessage response = client.GetAsync("api/Values/" + itemId).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<Item>().Result;
            }
            return result;
        }

        public int InsertItem(Item item)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            // HTTP POST
            HttpResponseMessage response =  client.PostAsync("api/Values", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }

        public int UpdateItem(Item item)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            // HTTP POST
            HttpResponseMessage response = client.PutAsync("api/Values", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return 1;
            }
            return 0;
        }

    }
}