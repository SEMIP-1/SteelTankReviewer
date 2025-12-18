using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteelTankReviewer.Application.Abstractions.Security;

namespace SteelTankReviewer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEngineerContext _engineerContext;

        public TestController(IEngineerContext engineerContext)
        {
            _engineerContext = engineerContext;
        }

        [HttpGet]
        public IActionResult GetEngineerId()
        {
            return Ok(_engineerContext.EngineerId);
        }
    }
}
