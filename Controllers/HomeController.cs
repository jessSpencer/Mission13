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


        public IActionResult Entry(Bowler b)
        {
            return View();
            //if (ModelState.IsValid)
            //{
            //    _context.Add(b);
            //    _context.SaveChanges();

            //    return View("Confirmation", b);
            //}
            //else
            //{
            //    ViewBag.Teams = _context.Teams.ToList();
            //    return View(b);
            //}
        }


    }
}
