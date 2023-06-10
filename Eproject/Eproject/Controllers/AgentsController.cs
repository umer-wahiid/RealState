using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Eproject.Models;

namespace Eproject.Controllers
{
    public class AgentsController : Controller
    {
        private readonly Dbs _context;

        public AgentsController(Dbs context)
        {
            _context = context;
        }

        // GET: Agents
        public async Task<IActionResult> Index()
        {
              return _context.AgentLogins != null ? 
                          View(await _context.AgentLogins.ToListAsync()) :
                          Problem("Entity set 'Dbs.AgentLogins'  is null.");
        }

        // GET: Agents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgentLogins == null)
            {
                return NotFound();
            }

            var agent = await _context.AgentLogins
                .FirstOrDefaultAsync(m => m.AgentId == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Agents/Create
        public IActionResult Create()
        {
            var id = HttpContext.Session.GetInt32("ID");

            if (id != null)
            {
                var e = HttpContext.Session.GetString("ID");
                ViewBag.id = id;
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin", "Home");
            }
        }

        // POST: Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agent agent)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("a", agent.Email);
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }
        //public IActionResult AgentLogin()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AgentLogin(Agent lg)
        //{
        //    var x = from a in _context.UserLogins
        //            where a.Email.Equals(lg.Email) && a.Password.Equals(lg.Password)
        //            select a;
        //    if (x.Any())
        //    {
        //        HttpContext.Session.SetString("u", lg.Email);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.m = "Wrong Email Or Password";
        //    }
        //    return View();
        //}

        // GET: Agents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgentLogins == null)
            {
                return NotFound();
            }

            var agent = await _context.AgentLogins.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgentId,Username,Password,CPassword,Email")] Agent agent)
        {
            if (id != agent.AgentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.AgentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgentLogins == null)
            {
                return NotFound();
            }

            var agent = await _context.AgentLogins
                .FirstOrDefaultAsync(m => m.AgentId == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgentLogins == null)
            {
                return Problem("Entity set 'Dbs.AgentLogins'  is null.");
            }
            var agent = await _context.AgentLogins.FindAsync(id);
            if (agent != null)
            {
                _context.AgentLogins.Remove(agent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(int id)
        {
          return (_context.AgentLogins?.Any(e => e.AgentId == id)).GetValueOrDefault();
        }
    }
}
