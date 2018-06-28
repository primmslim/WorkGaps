using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGaps
{
    class RailLine
    {
        public string LineName { get; set; }
        public List<Station> Stations { get; set; }
        


        public RailLine()
        {
            Stations = new List<Station>();
           
        }

    }
}
