using Eproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Eproject.Controllers
{
    public class HomeController : Controller
    {
        Dbs db;
        public HomeController(Dbs dbc)
        {
            db = dbc;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var x = HttpContext.Session.GetString("u");
            ViewBag.a = x;
            return View();
        }
        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login l)
        {
            db.UserLogins.Add(l);
            db.SaveChanges();
            ViewBag.m = "Account create successfully";
            return View();
            //return RedirectToAction("Login", "UserLogin");
        }
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Login lg)
        {
            var x = from a in db.UserLogins
                    where a.Email.Equals(lg.Email) && a.Password.Equals(lg.Password)
                    select a;
            Login log = db.UserLogins.FirstOrDefault(a=>a.Email==lg.Email);
            if (x.Any())
            {
                HttpContext.Session.SetString("u", lg.Email);
                HttpContext.Session.SetString("u", lg.Email);
                HttpContext.Session.SetInt32("ID", log.id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.m = "Wrong Email Or Password";
            }
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