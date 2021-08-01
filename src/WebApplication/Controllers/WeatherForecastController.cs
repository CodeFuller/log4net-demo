using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries =
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
		};

		private readonly ILogger<WeatherForecastController> logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			logger.LogInformation("Processing request ...");

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
#pragma warning disable CA5394 // Do not use insecure randomness
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)],
#pragma warning restore CA5394 // Do not use insecure randomness
			})
			.ToArray();
		}
	}
}
