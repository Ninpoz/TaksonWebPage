using Microsoft.AspNetCore.Mvc;

namespace TaksonWebPage.Controllers
{
    public class OmOssController : Controller
    {
        private readonly ILogger<OmOssController> _logger;

        public OmOssController(ILogger<OmOssController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
