using Microsoft.AspNetCore.Mvc;

namespace SonarCloud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get2()
        {
            NullReferenceExample();

            NoUsingExample();

            InfiniteLoopExample();
            DeadCodeExample();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        private static int NullReferenceExample()
        {
            int? number = null;
            return number.Value;
        }

        private static void NoUsingExample()
        {
            FileStream fileStream = new FileStream("example.txt", FileMode.Open);
        }

        public static void InfiniteLoopExample()
        {
            while (true)
            {
                Console.WriteLine("This is an infinite loop.");
            }
        }

        public static void DeadCodeExample()
        {
            int a = 5;
            int b = 10;

            if (a > b)
            {
                Console.WriteLine("This code will never run.");
            }
            else
            {
                Console.WriteLine("This code is always executed.");
            }
        }

        public static string OtherCases()
        {
            string url = "scheme://user:Admin123@domain.com";

            return url;
        }

        public static void ShouldNotBeEmpty()
        {
        }

        //"async" methods should not return "void"
        public static async void DoSthAsync()
        {
        }

        //Loops with at most one iteration should be refactored
        public object Method(IEnumerable<object> items)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                break; // Noncompliant: loop only executes once
            }

            foreach (object item in items)
            {
                return item; // Noncompliant: loop only executes once
            }
            return null;
        }
    }
}