using Microsoft.AspNetCore.Mvc;
using POS.Application.Business;

namespace POS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountersController : ControllerBase
    {        
        private readonly ICounterManager _counterManager;
       
        public CountersController(ICounterManager counterManager)
        {
            _counterManager = counterManager;
        }

        [HttpGet("{codes}")]
        public IActionResult CalculateTotal(string codes)
        {
            if (_counterManager.Validate(codes.ToUpper()))
            {
                double total = _counterManager.ProcessAndCalculateTotal(codes.ToUpper());
                return Ok(total);
            }
            else
            {
                return BadRequest("One or more product code are not valid, help is on the way.");
            }
        }
    }
}
