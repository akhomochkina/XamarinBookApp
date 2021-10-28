using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecomm
{
    public class NetworkingManager
    {
        string url1 = "https://api.itbook.store/1.0/search/";
        

        HttpClient client = new HttpClient();
       public async Task<List<Book>> getBook(string query)
        {
            string completeURL = url1 + query;
            var response  = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Book>();
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                var array = dic.ElementAt(3).Value;
                var finalList = JsonConvert.DeserializeObject<List<Book>>(array.ToString());

                return finalList;
            }
        }
    }
}
