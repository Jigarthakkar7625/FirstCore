using FirstCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FirstCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestAvinashContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, TestAvinashContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            var abc = _dbcontext.UserAddresses.ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}