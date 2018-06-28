using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGaps
{
    class Train
    {
        public string TrainID { get; set; }
        public List<TimingPoint> TimingPoints;
        public Direction TrainDirection { get; set; }

        public enum Direction
        {
            NorthBound = 1,
            SouthBound = 2
        }


        public Train(string trainID)
        {
            TrainID = trainID;

            string lastTrainDigit = TrainID.Substring(TrainID.Length - 1, 1);
            var isNumeric = int.TryParse(lastTrainDigit, out int n);
            if (isNumeric)
            TrainDirection = n % 2 == 0 ? Direction.NorthBound : Direction.SouthBound;

            TimingPoints = new List<TimingPoint>();
        }

    }
}
