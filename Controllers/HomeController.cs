using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using Mission13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        //private IBowlerRepository _repo { get; set; }
        ////Constructor
        //public HomeController(IBowlerRepository temp)
        //{
        //    _repo = temp;
        //}

        private BowlingDBContext _context { get; set; }
        
        public HomeController(BowlingDBContext temp)
        {
            _context = temp;
        }

        public IActionResult Index(string bowlerTeam)
        {
            //just a comment so I can make sure everythings committed:)
            ViewBag.Teams = _context.Teams.ToList();

            var b = new BowlingViewModel
            {
                Bowlers = _context.Bowlers
                    .Where(b => b.Team.TeamName == bowlerTeam || bowlerTeam == null)
            };
            return View(b);
        }
        [HttpGet]
        public IActionResult Entry()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult Entry(Bowler b)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Teams = _context.Teams.ToList();
                _context.Add(b);
                _context.SaveChanges();

                return View("Confirmation", b);
            }
            else
            {
                ViewBag.Teams = _context.Teams.ToList();
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _context.Teams.ToList();


            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Edit", bowler);

        }

        [HttpPost]
        public IActionResult Edit(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Teams = _context.Teams.ToList();

                _context.Update(bowler);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Teams = _context.Teams.ToList();
                return View("Index");
            }

        }
        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            _context.Bowlers.Remove(bowler);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
