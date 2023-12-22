
using CodeFirst.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace FirstCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly TestAvinashContext _dbcontext;
        private readonly IHostingEnvironment _env;

        private readonly ITransient _transientService1;
        private readonly ITransient _transientService2;


        private readonly IScoped _scopedService1;
        private readonly IScoped _scopedService2;

        private readonly ISingleton _singletonService1;
        private readonly ISingleton _singletonService2;


        public HomeController(ILogger<HomeController> logger, IHostingEnvironment env, ITransient transientService1, ITransient transientService2, IScoped scopedService1, IScoped scopedService2, ISingleton singletonService1, ISingleton singletonService2)
        {
            _logger = logger;
            //_dbcontext = dbcontext;
            _env = env;
            _transientService1=transientService1;
            _transientService2 = transientService2;
            
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;   

            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            var path = _env.EnvironmentName;
            var path12 = Directory.GetFiles(_env.WebRootPath + "\\css");

            ViewBag.t1 = _transientService1.GetGUID().ToString();
            ViewBag.t2 = _transientService2.GetGUID().ToString();

            ViewBag.s1 = _scopedService1.GetGUID().ToString();
            ViewBag.s2 = _scopedService2.GetGUID().ToString();

            ViewBag.single1 = _singletonService1.GetGUID().ToString();
            ViewBag.single2 = _singletonService2.GetGUID().ToString();



            //var abc = _dbcontext.UserAddresses.ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}