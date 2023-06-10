using Eproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eproject.Controllers
{
    public class AdminController : Controller
    {
        Dbs db;
        public AdminController(Dbs dbc)
        {
            db = dbc;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin A)
        {
            db.AdminLogins.Add(A);
            db.SaveChanges();
            ViewBag.m = "Account create successfully";
            return View();
            //return RedirectToAction("Login", "UserLogin");
        }
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin lg)
        {
            var x = from a in db.AdminLogins
                    where a.Email.Equals(lg.Email) && a.Password.Equals(lg.Password)
                    select a;
            if (x.Any())
            {
                HttpContext.Session.SetString("u", lg.Email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.m = "Wrong Email Or Password";
            }
            return View();
        }
        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
