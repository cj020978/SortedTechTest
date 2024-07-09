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
                if (count < 1 || count > 100)
                    return BadRequest(Error.ErrorManager.RaiseCountError());

                var rainfallApiManager = new RainfallAPIManager();
                var rainfallData = await rainfallApiManager.GetStationRainfallData(stationId);

                if (rainfallData == null || rainfallData.Items == null || rainfallData.Items.Length == 0)
                    return NotFound(Error.ErrorManager.RaiseNotFoundError());

                return new RainfallReading[] { new RainfallReading() };
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
