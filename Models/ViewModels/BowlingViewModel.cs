using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models.ViewModels
{
    public class BowlingViewModel
    {
        public IEnumerable<Bowler> Bowlers { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
