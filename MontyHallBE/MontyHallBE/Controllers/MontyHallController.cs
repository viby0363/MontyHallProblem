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
        public async Task<MontyHallResponse> GetSimulationResultAsync([FromQuery]MontyHallRequest request)
        {
            var simulator = new Simulator(request.NumberOfRuns, request.ChangeDoor);
            return await simulator.GetSimulationResult();
        }
    }
}
