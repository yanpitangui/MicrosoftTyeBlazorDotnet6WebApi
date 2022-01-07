namespace Frontend.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastAsync(DateTime startDate)
        {
            var httpClient = _httpClientFactory.CreateClient("weatherapi");
            var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
            return result ?? Enumerable.Empty<WeatherForecast>();
        }
    }
}