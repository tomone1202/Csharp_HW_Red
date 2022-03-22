using ClassicWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassicWebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        
           Task<IEnumerable<CountryInfo>> GetAll();
           Task<string> GetMap(string country);

           Task<PostDataInfo> GetCountryNamesBySubRegion (string region);
    }
}