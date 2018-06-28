using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGaps
{
    class TimingPoint
    {
        public Station PointStation { get; set; }
        public DateTime ArriveTime { get; set; }
        public DateTime DepartTime { get; set; }
        public int Importance { get; set; }


    }
}
