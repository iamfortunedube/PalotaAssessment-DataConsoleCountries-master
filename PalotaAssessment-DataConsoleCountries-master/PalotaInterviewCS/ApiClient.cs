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
        static readonly string BaseUrl = "https://restcountries.eu/rest/v2/";
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
        static void ShowCountry(IEnumerable<Country> countries)
        {
            foreach (var country in countries)
                Console.WriteLine($"Name: {country.Name}\tNative name: {country.NativeName}\tCapital city:{country.Capital}");
        }

    }
}
