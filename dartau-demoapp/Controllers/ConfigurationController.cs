using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dartau_demoapp.Controllers
{
    [Route("api/Configuration")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConfigurationController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Configuration
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = _config.GetValue<string>("Logging:LogLevel:Default"); // "Information"
            return new string[] { result.ToString() };
        }

        // GET: api/Configuration
        [HttpGet]
        public IEnumerable<string> Get(string key)
        {
            var result = _config.GetValue<string>(key); // "Information"
            return new string[] { result.ToString() };
        }
    }

    public class AppSettings
    {
        public ApplicationInsights ApplicationInsights { get; set; }
    }

    public class ApplicationInsights { public string InstrumentationKey { get; set; } }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }

        //public string Warning { get; set; }

        //public string Error { get; set; }
    }
}
