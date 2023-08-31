using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
//this file is pulling a logger
namespace SerilogLogging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested the index page");
            try
            {
                throw new Exception("This is the exception");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We caught an error");
            }
        }
    }
}