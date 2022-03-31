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
        private IBowlerRepository _repo { get; set; }
        //Constructor
        public HomeController(IBowlerRepository temp)
        {
            _repo = temp;
        }


        public IActionResult Index(string bowlerTeam)
        {
            //just a comment so I can make sure everythings committed:)
            ViewBag.Teams = _repo.Teams.ToList();

            var b = new BowlingViewModel
            {
                Bowlers = _repo.Bowlers
                    .Where(b => b.Team.TeamName == bowlerTeam)
            };
            return View(b);
        }


    }
}
