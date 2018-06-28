using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGaps
{
    class Track
    {
        public string Station1Name { get; set; }
        public string Station2Name { get; set; }
        public List<Block> Blocks { get; set; }
        public string TrackName { get; set; }
        public Track(Station S1, Station S2)
        {
            if (S1.Meterage < S2.Meterage)
            {
                Station1Name = S1.LocationName;
                Station2Name = S2.LocationName;
            }
            else
            {
                Station1Name = S2.LocationName;
                Station2Name = S1.LocationName;
            }
            Blocks = new List<Block>();
        }

        public string TrackID { get {return Station1Name + Station2Name;} }

        public void AddBlock(DateTime startTime, DateTime endTime, string StartDescription, string EndDescription)
        {



            var block = new Block();
            block.StartTime = startTime;
            block.EndTime = endTime;
            block.StartDescription = StartDescription;
            block.EndDescription = EndDescription;

            //check for intersects
            foreach (Block b in Blocks)
            {
                var intercect = b.Intersects(block);
                if (intercect != null)
                {
                    Blocks.Remove(b);
                    Blocks.Add(intercect);
                    return;
                }
            }
            Blocks.Add(block);

        }
        public void AddBlock(Block block)
        {
            AddBlock(block.StartTime, block.EndTime, block.StartDescription, block.EndDescription);
        }
    }
}
