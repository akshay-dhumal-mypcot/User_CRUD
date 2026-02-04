using Microsoft.AspNetCore.Mvc;

namespace User_CRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class DummyController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly int[] Numbers = new[] { 1, 2, 3, 4, 5, 5, 67, 8, 8, 8 };

    private readonly ILogger<DummyController> _logger;

    public DummyController(ILogger<DummyController> logger)
    {
        _logger = logger;
    }

    // Returns random weather forecast
    [HttpGet("weather")]
    public IEnumerable<WeatherForecast> GetWeather()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // Returns a list of numbers
    [HttpGet("numbers")]
    public IEnumerable<int> GetNumbers()
    {
        return Numbers.ToArray();
    }

    // Returns a list of dummy users
    [HttpGet("users")]
    public IEnumerable<object> GetUsers()
    {
        return new[]
        {
            new { Id = 1, Name = "John Doe", Email = "john@example.com" },
            new { Id = 2, Name = "Jane Smith", Email = "jane@example.com" },
            new { Id = 3, Name = "Bob Johnson", Email = "bob@example.com" }
        };
    }

    // Returns random quotes
    [HttpGet("quotes")]
    public IEnumerable<string> GetQuotes()
    {
        var quotes = new[]
        {
            "The best way to predict the future is to invent it.",
            "Life is what happens when you're busy making other plans.",
            "You miss 100% of the shots you don’t take.",
            "Do or do not. There is no try."
        };
        return quotes.OrderBy(x => Random.Shared.Next()).Take(3);
    }

    // Returns current server time
    [HttpGet("time")]
    public object GetServerTime()
    {
        return new
        {
            ServerTime = DateTime.Now,
            TimeZone = TimeZoneInfo.Local.StandardName
        };
    }
}
