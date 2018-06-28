using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGaps
{
    class Block
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartDescription { get; set; }
        public string EndDescription { get; set; }

        public TimeSpan BlockSpan()
        {
            TimeSpan timeSpan = EndTime.Subtract(StartTime);
            return timeSpan;
        }

        public Block Intersects(Block test)
        {

            //if (this.StartTime > this.EndTime || test.StartTime > test.EndTime)
            //    return null;

            //if (this.StartTime == this.EndTime || test.StartTime == test.EndTime)
            //    return null; // No actual date range
            
            //if (this.StartTime == test.StartTime || this.EndTime == test.EndTime)
            //    //return true; // If any set is the same time, then by default there must be some overlap. 

            //condition if the times need to be stitched together

            if (this.EndTime == test.StartTime)
                {
                    return new Block
                    {
                        StartTime = this.StartTime,
                        EndTime = test.EndTime,
                        StartDescription = this.StartDescription,
                        EndDescription = test.EndDescription
                    };
                }

            if (this.StartTime == test.EndTime)
            {
                return new Block
                {
                    StartTime = test.StartTime,
                    EndTime = this.EndTime,
                    StartDescription = test.StartDescription,
                    EndDescription = this.EndDescription
                };
            }

            if (this.StartTime < test.StartTime)
            {
                    if (this.EndTime > test.StartTime && this.EndTime < test.EndTime)

                        // Condition 1
                        return new Block
                    {   StartTime = this.StartTime,
                        EndTime = test.EndTime,
                        StartDescription = this.StartDescription,
                        EndDescription = test.EndDescription};

                    if (this.EndTime > test.EndTime)
                        // Condition 3
                        return this;
            }
            else
            {
                    if (test.EndTime > this.StartTime && test.EndTime < this.EndTime)

                        // Condition 2
                        return new Block
                    {
                        StartTime = test.StartTime,
                        EndTime = this.EndTime,
                        StartDescription = test.StartDescription,
                        EndDescription = this.EndDescription
                    };

                    if (test.EndTime > this.EndTime)
                        return test;// Condition 4
            }
            return null;

            
        }

    }
}
