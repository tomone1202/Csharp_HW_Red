using ClassicWebAPI.Models;
using ClassicWebAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ClassicWebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly IHttpClientService _httpClientService;

        public CountryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<CountryInfo>> GetAll()
        {
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/all");
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
        }
        public async Task<string> GetMap(string country)
        {
            var httpResponseMessage = await _httpClientService.GetAsync($"https://restcountries.com/v3.1/name/{country}");
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
            return info?.FirstOrDefault()?.Map.GoogleMap;
        }

        public async Task<PostDataInfo> PostInfo(string region)
        {
            var httpResponseMessage = await _httpClientService.GetAsync($"https://restcountries.com/v3.1/region/{region}");
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            var info = JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
            List<string> allCountry = new List<string>();
            foreach (CountryInfo country in info)
            {
                allCountry.Add(country.CountryName.Official);
            };
            var result=new PostDataInfo();
            result.Subregion = region;
            result.Countries = allCountry.ToArray();
            return result;
        }
    }
}