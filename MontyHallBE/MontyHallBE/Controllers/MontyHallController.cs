using Microsoft.AspNetCore.Mvc;
using MontyHallBE.Models;
using MontyHallBE.Service;

namespace MontyHallBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MontyHallController
    {
        [HttpGet]
        public MontyHallResponse GetSimulationResultAsync([FromQuery]MontyHallRequest request)
        {
            var simulator = new Simulator(request.NumberOfRuns, request.ChangeDoor);
            return simulator.GetSimulationResult();
        }
    }
}
