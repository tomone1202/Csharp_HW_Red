using ClassicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassicWebAPI.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return Ok("Welcome to ClassicWebAPI.");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return new JsonResult(await _countryService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Map(string country)
        {
            var url = await _countryService.GetMap(country);
            if (url == null)
            {
                return Ok("找不到國家");
            }
            return Redirect(url);
        }

        [HttpPost]
        public async Task<IActionResult> GetCountryBySubRegion(string SubRegion)
        {
            var result = await _countryService.PostInfo(SubRegion);
            if (result == null)
            {
                return Ok("找不到地區");
            }
            return new JsonResult(result);
        }
    }
}