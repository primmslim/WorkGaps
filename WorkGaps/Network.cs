using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WorkGaps
{
    class Network
    {
        public List<RailLine> RailLines;
        public List<Train> Trains;
        public List<Track> Tracks { get; set; }
        public void ImportCatsFiles(string FilePath)
        {
            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()}: Processing Starting");
            RailLines = new List<RailLine>();
            Trains = new List<Train>();
            Tracks = new List<Track>();
            ProcessFolder(FilePath);
            BuildTrack();
            Debug.WriteLine($"{DateTime.Now.ToLongTimeString()}: Processing Finished");
            
        }
        private void BuildTrack()
        {
            foreach(Train train in Trains)
            {
                for (int i = 0; i <= train.TimingPoints.Count-2; i++)
                {
                    var timingPoint1 = train.TimingPoints[i];
                    var timingPoint2 = train.TimingPoints[i + 1];
                    var track = new Track(timingPoint1.PointStation, timingPoint2.PointStation);
                    var trackIndex = Tracks.IndexOf(Tracks.Find(t => t.TrackID == track.TrackID));

                    if (trackIndex == -1)
                    {
                        Tracks.Add(track);
                        trackIndex = Tracks.IndexOf(track);
                    }


                    Tracks[trackIndex].AddBlock(timingPoint1.ArriveTime,
                        timingPoint2.DepartTime,
                        $"{train.TrainID} arrives into {timingPoint1.PointStation.LocationName}",
                        $"{train.TrainID} departs from {timingPoint2.PointStation.LocationName}"
                        );

                }
            }
        }
        public void ProcessFolder(string Folder)
        {
            string[] files = Directory.GetFiles(Folder, "*BC.*", SearchOption.TopDirectoryOnly);
            var fileExtentions = new List<string> { ".mo", ".tu", ".we", ".th", ".fr", ".sa", ".su" };
            foreach (string file in files)
            {
                string fileExtention = Path.GetExtension(file);
                string TrainName = Path.GetFileNameWithoutExtension(file);
                if (fileExtentions.Contains(fileExtention))
                    ProcessTrains(file,TrainName);
            }

        }
        public void ProcessTrains(string File, string LineName)
        {
            StreamReader reader = new StreamReader(File);
            string line;
            string DayOfWeek;
            

            line = reader.ReadLine(); //first line of file
            DayOfWeek = line.Substring(42, 3);
            var baseDate = GetDayOfWeek(DayOfWeek);

            
            reader.ReadLine(); //second line (contains no useful info)
            line = reader.ReadLine(); //third line of file
            int StationCount = int.Parse( line.Substring(0, 10));

            var lineIndex = RailLines.IndexOf(RailLines.Find(l => l.LineName == LineName));
            if (lineIndex == -1)
            {
                var railLine = new RailLine();
                railLine.LineName = LineName;
                for (int i = 0; i < StationCount; i++)
                {
                    line = reader.ReadLine();
                    var station = new Station();
                    station.LocationName = line.Substring(0, 12).Trim();
                    station.Meterage = double.Parse(line.Substring(14, 8));
                    station.Importance = int.Parse(line.Substring(20, 5));
                    railLine.Stations.Add(station);

                }

                RailLines.Add(railLine);
                lineIndex = RailLines.IndexOf(railLine);
            }
            else
            {
                for (int i = 0; i < StationCount; i++)
                {
                    reader.ReadLine();
                }
            }
            



            while ((line = reader.ReadLine()) != null)
            {
               
                string TrainID = line.Substring(5, 4).Trim();
                var train = new Train(TrainID);
                int startIndex = int.Parse(line.Substring(10, 5));
                int endIndex = int.Parse(line.Substring(15, 5));
                int ArrDep = int.Parse(line.Substring(20, 5));
                int timeCount = 0;
                line = reader.ReadLine();

                if (startIndex > endIndex)
                {
                    var s = startIndex;
                    var e = endIndex;
                    startIndex = e;
                    endIndex = s;
                }

                for (int i = startIndex; i <= endIndex ; i++)
                {
                    if (timeCount == 5)
                    {
                        line = reader.ReadLine();
                        timeCount = 0;
                    }

                    var Mins1 = line.Substring((timeCount * 15), 5);
                    var Mins2 = line.Substring((timeCount * 15) +5, 5);
                    var importanceString = line.Substring((timeCount * 15) + 10, 5);
                    var timingPoint = new TimingPoint();
                    timingPoint.PointStation = RailLines[lineIndex].Stations[i-1];

                    if (ArrDep == 1)
                    {
                        timingPoint.ArriveTime = baseDate.AddMinutes(Double.Parse(Mins1));
                        timingPoint.DepartTime = baseDate.AddMinutes(Double.Parse(Mins2));
                    }
                    else
                    {
                        timingPoint.ArriveTime = baseDate.AddMinutes(Double.Parse(Mins2));
                        timingPoint.DepartTime = baseDate.AddMinutes(Double.Parse(Mins1));
                    }
                    timingPoint.Importance = int.Parse(importanceString);
                    //if (timingPoint.PointStation.Importance > 0)
                    train.TimingPoints.Add(timingPoint);
                    timeCount++;   
                }
                if (train.TimingPoints.Count > 0)
                {
                    train.TimingPoints.Sort((p, q) => p.DepartTime.CompareTo(q.DepartTime));
                    Trains.Add(train);
                }
            }
            
            
            
        }
        private DateTime GetDayOfWeek(string WeekdayName)
        {
            switch (WeekdayName)
            {
                case "MON":
                    return new DateTime(1970, 1, 5);
                case "TUE":
                    return new DateTime(1970, 1, 6);
                case "WED":
                    return new DateTime(1970, 1, 7);
                case "THU":
                    return new DateTime(1970, 1, 1);
                case "FRI":
                    return new DateTime(1970, 1, 2);
                case "SAT":
                    return new DateTime(1970, 1, 3);
                case "SUN":
                    return new DateTime(1970, 1, 4);
                default:
                    return new DateTime(1970, 1, 1);
            }
        }
        public List<Track> FindAllPaths(Track track1, Track track2)
        {
            var paths = FindPath(track1, track2, Train.Direction.NorthBound);
            if (paths == null) paths = FindPath(track1, track2, Train.Direction.SouthBound);
            return paths;
        }
        private List<Track> FindPath(Track track1,Track track2, Train.Direction direction)
        {
            if (track1.TrackID.Equals(track2.TrackID)) return new List<Track> { track1 };
            var connectingTracks = ConnectingTracks(track1, direction);
            foreach (Track connectingTrack in connectingTracks)
            {
                if (connectingTrack.TrackID == track2.TrackID)
                {
                    return new List<Track> { track1 , connectingTrack };
                }
                else
                {
                    var subPath = FindPath(connectingTrack, track2, direction);
                    if (subPath != null)
                    {
                        subPath.Insert(0, track1);
                        return subPath;
                    }
                        
                }
            }


            return null;



        }
        public List<Track> FindAllPaths(string Trackid1, string Trackid2)
        {
            var track1 = Tracks.First(t => t.TrackID == Trackid1);
            var track2 = Tracks.First(t => t.TrackID == Trackid2);
            return FindAllPaths(track1, track2);
        }
        private List<Track> ConnectingTracks(Track track, Train.Direction direction)
        {
            if (direction == Train.Direction.NorthBound)
            {

                return Tracks.FindAll(t => t.Station2Name == track.Station1Name).ToList();
            }
            else
            {
                return  Tracks.FindAll(t => t.Station1Name == track.Station2Name).ToList();
            }
            

        }
        private List<Block> CompressTrackBlocks(List<Track> tracks)
        {
            var blocks = new List<Block>();
            
            var track = new Track(new Station(), new Station());
            tracks.ForEach(t => t.Blocks.ForEach(b => blocks.Add(b)));

            foreach(Block block in blocks)
            {
                track.AddBlock(block);
            }




            track.Blocks.Sort((p, q) => p.StartTime.CompareTo(q.StartTime));
            return track.Blocks.ToList();
        }
        public List<Block> GetFreeWorkTimes(string Trackid1, string Trackid2)
        {
            var res = new List<Block>();

            //find the path
            var tracks = FindAllPaths(Trackid1, Trackid2);
            if (tracks == null) return null;
            var workBlocks = CompressTrackBlocks(tracks);


            // if only 1 train in result
            if (workBlocks.Count == 1) return new List<Block> { new Block { StartTime = workBlocks[0].EndTime ,
                                                                            EndTime = workBlocks[0].StartTime,
                                                                            StartDescription = workBlocks[0].EndDescription,
                                                                            EndDescription = workBlocks[0].StartDescription
            } };

            var block = new Block();

            for (int i = 0; i <= workBlocks.Count-1; i++)
            {
                var workBlock = workBlocks[i];
                block.StartTime = workBlock.EndTime;
                block.StartDescription = workBlock.EndDescription;

                //if last block, connect the end time up to first block start time
                if (i == workBlocks.Count - 1)
                {
                    block.EndTime = workBlocks[0].StartTime.AddDays(7);
                    block.EndDescription = workBlocks[0].StartDescription;
                    res.Add(block);
                }
                else
                {
                    block.EndTime = workBlocks[i+1].StartTime;
                    block.EndDescription = workBlocks[i+1].StartDescription;
                    res.Add(block);
                    block = new Block();
                }

            }

            return res;
        }
    }
}
