using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PalotaInterviewCS
{
    public class ApiClient
    {
        static readonly HttpClient client = new HttpClient();
        public ApiClient()
        {
        }

        public static async Task<IEnumerable<Country>> GetCountries(string path)
        {
            IEnumerable<Country> countries = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                countries = await response.Content.ReadAsAsync<IEnumerable<Country>>();
            }
            return countries;
        }
    }
}
