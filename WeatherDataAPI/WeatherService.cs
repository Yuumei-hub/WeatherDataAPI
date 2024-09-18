using Newtonsoft.Json;

namespace WeatherDataAPI
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY= "5597432b625cacf32cdf7e9bca652047";
        private const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse> GetWeatherData(string city)
        {
            var response = await _httpClient.GetAsync($"{BASE_URL}?q={city}&appid={API_KEY}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var weatherData= JsonConvert.DeserializeObject<WeatherResponse>(jsonString);
                return weatherData;
            }
            return null;
        }
    }
}
