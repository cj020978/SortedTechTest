using Microsoft.AspNetCore.Mvc;

namespace SortedTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Rainfall : ControllerBase
    {
        [Produces("application/json")]
        [HttpGet]
        [Route("id/{stationId}/readings")]
        public IEnumerable<RainfallReading> readings()
        {
            return new RainfallReading[] { new RainfallReading() } ;
        }
    }
}
