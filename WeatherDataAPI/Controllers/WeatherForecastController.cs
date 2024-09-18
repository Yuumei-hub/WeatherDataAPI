using Microsoft.AspNetCore.Mvc;

namespace WeatherDataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly WeatherService _weatherService;
        public WeatherForecastController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherData(string city)
        {
            var weatherData = await _weatherService.GetWeatherData(city);
            if (weatherData == null)
            {
                return NotFound();
            }
            return Ok(weatherData);
        }
    }
}
