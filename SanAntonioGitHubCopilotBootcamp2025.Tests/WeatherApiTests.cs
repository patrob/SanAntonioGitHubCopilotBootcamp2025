using Xunit;
using SanAntonioGitHubCopilotBootcamp2025;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;

public class WeatherApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccessAndForecast()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/weatherforecast");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("temperatureC", content, System.StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task GetWeatherForecastByCity_ReturnsSuccessAndCity()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/weatherforecast/SanAntonio");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("SanAntonio", content);
    }

    [Fact]
    public async Task WillItRain_ReturnsSuccessAndBoolean()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/willitrain");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("WillItRain", content);
    }
}
