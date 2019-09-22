using System.Collections.Generic;
using System.Threading.Tasks;
using app.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace app.APIs
{
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger _logger;
        public DemoController(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Get()
        {
            _logger.Information("Start get data of demo");
            var result = await Task.Run(() => new List<DemoA>
            {
                new DemoA { Id = 1, Name = "Demo A 1" },
                new DemoA { Id = 2, Name = "Demo A 2" }
            });
            
            return Ok(result);
        }
    }
}