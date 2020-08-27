using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Mvc;

namespace dartau_demoapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        public string Get(int id)
        {
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.InstrumentationKey = "61b7fb78-d207-411d-b7c5-59df48e5703f";
            //configuration.InstrumentationKey = new ConfigurationController().Get("ApplicationInsights:InstrumentationKey")[0];
            var telemetryClient = new TelemetryClient(configuration);
            telemetryClient.TrackTrace(string.Format("[dartau-devops] GreetingController.Get(id): {0}", id));

            return "Hello world from Dart Au blah blah blah";
        }
    }
}
