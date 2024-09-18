namespace WeatherDataAPI
{
    public class WeatherResponse
    {
        public string City { get; set; }
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
    }
}
