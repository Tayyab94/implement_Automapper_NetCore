using AutoMapper;
using AutoMapper_CodeProject.Models.DTOs;
using AutoMapper_CodeProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper_CodeProject.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IEnumerable<TeamMember> ComplexObjectToList([FromBody] Team team)
        {
            return _mapper.Map<IEnumerable<TeamMember>>(team);
        }

        [HttpPost]
        public IEnumerable<Team>
       ListToComplexObjectList([FromBody] IEnumerable<TeamMember> list)
        {
            return _mapper.Map<IEnumerable<Team>>(list);
        }
    }
}