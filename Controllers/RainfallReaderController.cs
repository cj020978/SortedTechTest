using Microsoft.AspNetCore.Mvc;
using SortedTechTest.RainfallAPI;

namespace SortedTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Rainfall : ControllerBase
    {
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        [Route("id/{stationId}/readings")]
        public async Task<ActionResult<RainfallReading[]>> readings(string stationId, [FromQuery] int count = 10)
        {
            try
            {
                var rainfallApiManager = new RainfallAPIManager();
                var rainfallData = await rainfallApiManager.GetStationRainfallData(stationId);

                return new RainfallReading[] { new RainfallReading() };
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
