using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkGaps
{
    public partial class Main : Form
    {
        Network network;
        string trackName1, trackName2;
        List<Block> displayedTimes;
        
        public Main()
        {
            InitializeComponent();
            lstOut.Columns.Add("Start Time");
            lstOut.Columns.Add("End Time");
            lstOut.Columns.Add("Duration");
            lstOut.Columns.Add("Starts When");
            lstOut.Columns.Add("Ends When");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = txtFilePath.Text;
            if (filePath.Length == 0)
            {
                MessageBox.Show("Please choose a CATS Folder First");
                return;
            }

            network = new Network();
            button1.Text = "Loading...";
            button1.Refresh();
            network.ImportCatsFiles(filePath);
            button1.Text = "Complete";
            button1.Enabled = false;
            FillCBOs();

        }

        private void FillCBOs()
        {
            var dt1 = new DataTable();
            dt1.Columns.Add("ID");
            dt1.Columns.Add("Text");
            var dt2 = new DataTable();
            dt2.Columns.Add("ID");
            dt2.Columns.Add("Text");
            foreach (Track track in network.Tracks)
            {
                var dr1 = dt1.NewRow();
                dr1["ID"] = track.TrackID;
                dr1["Text"] = $"{track.Station1Name} to {track.Station2Name}";
                dt1.Rows.Add(dr1);
                var dr2 = dt2.NewRow();
                dr2["ID"] = track.TrackID;
                dr2["Text"] = $"{track.Station1Name} to {track.Station2Name}";
                dt2.Rows.Add(dr2);
                

            }

            cboStation1.DataSource = dt1;
            cboStation1.DisplayMember = "Text";
            cboStation1.ValueMember = "ID";


            cboStation2.DataSource = dt2;
            cboStation2.DisplayMember = "Text";
            cboStation2.ValueMember = "ID";

            

        }


        private void btnFindPath_Click(object sender, EventArgs e)
        {

            DisplayTimes();

        }
        private void DisplayAllTrains()
        {
            DataRowView dataRow = (DataRowView)cboStation1.SelectedItem;
            var row = dataRow.Row;

            var trackID1 = row["ID"] as string;
            trackName1 = row["Text"] as string;
            dataRow = (DataRowView)cboStation2.SelectedItem;
            row = dataRow.Row;
            var trackID2 = row["ID"] as string;
            trackName2 = row["Text"] as string;
            lstPath.Items.Clear();
            lstOut.Items.Clear();

            var tracks = network.FindAllPaths(trackID1, trackID2);
            foreach (Track track in tracks)
            {
                foreach (Block block in track.Blocks)
                {
                    var lstItem = new ListViewItem(block.StartTime.ToString("ddd HH:mm"));

                    lstItem.SubItems.Add(block.EndTime.ToString("ddd HH:mm"));
                    lstItem.SubItems.Add(block.BlockSpan().ToString(@"hh\:mm"));
                    lstItem.SubItems.Add(block.StartDescription);
                    lstItem.SubItems.Add(block.EndDescription);
                    lstOut.Items.Add(lstItem);
                    //displayedTimes.Add(block);
                }
            }



        }
        private void DisplayTimes(TimeSpan? minSpan = null)
        {

            DataRowView dataRow = (DataRowView)cboStation1.SelectedItem;
            var row = dataRow.Row;

            var trackID1 = row["ID"] as string;
            trackName1 = row["Text"] as string;
            dataRow = (DataRowView)cboStation2.SelectedItem;
            row = dataRow.Row;
            var trackID2 = row["ID"] as string;
            trackName2 = row["Text"] as string;
            lstPath.Items.Clear();
            lstOut.Items.Clear();
            var paths = network.FindAllPaths(trackID1, trackID2);
            if (paths == null)
            {
                lblResult.Text = "No path found between these 2 tracks";
                return;
            }
            lblResult.Text = $"Path found over {paths.Count} hops.";
            paths.ForEach(p => lstPath.Items.Add($"{p.Station1Name} to {p.Station2Name}")

            );

           var freeTimes = network.GetFreeWorkTimes(trackID1, trackID2);
            displayedTimes = new List<Block>();

            foreach (Block block in freeTimes)
            {
                var lstItem = new ListViewItem(block.StartTime.ToString("ddd HH:mm"));
                if (minSpan != null)
                {
                    if (block.BlockSpan() < minSpan) continue;
                }
                lstItem.SubItems.Add(block.EndTime.ToString("ddd HH:mm"));
                lstItem.SubItems.Add(block.BlockSpan().ToString(@"hh\:mm"));
                lstItem.SubItems.Add(block.StartDescription);
                lstItem.SubItems.Add(block.EndDescription);
                lstOut.Items.Add(lstItem);
                displayedTimes.Add(block);
            }
        }

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Please select the CATS Folder";
            fbd.ShowDialog();
            
            if (fbd.SelectedPath.Length > 0)
            {
                txtFilePath.Text = fbd.SelectedPath;
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            int minHour = Convert.ToInt16(nudHour.Value);
            int minMinute = Convert.ToInt16(nudMinute.Value);
            DisplayTimes(new TimeSpan(minHour, minMinute, 0));


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayAllTrains();
        }

        private void btnWriteData_Click(object sender, EventArgs e)
        {
            if (displayedTimes.Count < 1) return;
            var ws = Globals.Sheet1;
            
            ws.Range["A1"].Value = "Train Gap Data";
            ws.Range["A3"].Value = "From:";
            ws.Range["B3"].Value = trackName1;
            ws.Range["A4"].Value = "To:";
            ws.Range["B4"].Value = trackName2;

            ws.Range["A5"].Value = "Start Time";
            ws.Range["B5"].Value = "End Time";
            ws.Range["C5"].Value = "Duration";
            ws.Range["D5"].Value = "Starts When";
            ws.Range["E5"].Value = "Ends When";

            for (int i = 0; i < displayedTimes.Count; i++)
            {
                ws.Cells[i + 6, 1] = displayedTimes[i].StartTime.ToString("ddd HH:mm");
                ws.Cells[i + 6, 2] = displayedTimes[i].EndTime.ToString("ddd HH:mm");
                ws.Cells[i + 6, 3] = displayedTimes[i].BlockSpan().ToString(@"hh\:mm");
                ws.Cells[i + 6, 4] = displayedTimes[i].StartDescription;
                ws.Cells[i + 6, 5] = displayedTimes[i].EndDescription;


            }

            ws.Range["A:E"].Columns.AutoFit();

            this.Hide();

        }
    }
}
