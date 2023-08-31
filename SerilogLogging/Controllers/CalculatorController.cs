using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace SerilogLoggingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add/{a}/{b}")]
        public IActionResult Add(double a, double b)
        {
            Log.Debug("Adding {A} and {B}", a, b);
            var result = a + b;
            return Ok(result);
        }

        [HttpGet("subtract/{a}/{b}")]
        public IActionResult Subtract(double a, double b)
        {
            Log.Debug("Subtracting {B} from {A}", b, a);
            var result = a - b;
            return Ok(result);
        }

        [HttpGet("multiply/{a}/{b}")]
        public IActionResult Multiply(double a, double b)
        {
            Log.Debug("Multiplying {A} and {B}", a, b);
            var result = a * b;
            return Ok(result);
        }

        [HttpGet("divide/{a}/{b}")]
        public IActionResult Divide(double a, double b)
        {
            if (b == 0)
            {
                Log.Error("Division by zero attempted");
                return BadRequest("Cannot divide by zero");
            }

            Log.Debug("Dividing {A} by {B}", a, b);
            var result = a / b;
            return Ok(result);
        }
    }
}