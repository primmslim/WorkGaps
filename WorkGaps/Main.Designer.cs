namespace WorkGaps
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboStation1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lstOut = new System.Windows.Forms.ListView();
            this.cboStation2 = new System.Windows.Forms.ComboBox();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.lstPath = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.btnWriteData = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // cboStation1
            // 
            this.cboStation1.FormattingEnabled = true;
            this.cboStation1.Location = new System.Drawing.Point(32, 166);
            this.cboStation1.Name = "cboStation1";
            this.cboStation1.Size = new System.Drawing.Size(298, 21);
            this.cboStation1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load CATS File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstOut
            // 
            this.lstOut.LabelWrap = false;
            this.lstOut.Location = new System.Drawing.Point(405, 52);
            this.lstOut.Name = "lstOut";
            this.lstOut.Size = new System.Drawing.Size(700, 565);
            this.lstOut.TabIndex = 3;
            this.lstOut.UseCompatibleStateImageBehavior = false;
            this.lstOut.View = System.Windows.Forms.View.Details;
            // 
            // cboStation2
            // 
            this.cboStation2.FormattingEnabled = true;
            this.cboStation2.Location = new System.Drawing.Point(32, 224);
            this.cboStation2.Name = "cboStation2";
            this.cboStation2.Size = new System.Drawing.Size(298, 21);
            this.cboStation2.TabIndex = 4;
            // 
            // btnFindPath
            // 
            this.btnFindPath.Location = new System.Drawing.Point(32, 264);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(298, 34);
            this.btnFindPath.TabIndex = 5;
            this.btnFindPath.Text = "Find Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // lstPath
            // 
            this.lstPath.Location = new System.Drawing.Point(32, 322);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(298, 255);
            this.lstPath.TabIndex = 6;
            this.lstPath.UseCompatibleStateImageBehavior = false;
            this.lstPath.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Point 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Point 2";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(35, 306);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(34, 13);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "Paths";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "CATS File";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(38, 52);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(292, 20);
            this.txtFilePath.TabIndex = 13;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(220, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(110, 25);
            this.btnSelectFile.TabIndex = 14;
            this.btnSelectFile.Text = "Select CATS File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // nudHour
            // 
            this.nudHour.Location = new System.Drawing.Point(425, 23);
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(82, 20);
            this.nudHour.TabIndex = 15;
            this.nudHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudMinute
            // 
            this.nudMinute.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudMinute.Location = new System.Drawing.Point(548, 23);
            this.nudMinute.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(78, 20);
            this.nudMinute.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Hours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Minutes";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(648, 23);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(44, 20);
            this.btnApplyFilter.TabIndex = 19;
            this.btnApplyFilter.Text = "Filter";
            this.btnApplyFilter.UseVisualStyleBackColor = true;
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(1021, 18);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(84, 28);
            this.btnWriteData.TabIndex = 20;
            this.btnWriteData.Text = "Write to Sheet";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 583);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(298, 34);
            this.button2.TabIndex = 21;
            this.button2.Text = "Display All Trains";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 629);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnWriteData);
            this.Controls.Add(this.btnApplyFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudMinute);
            this.Controls.Add(this.nudHour);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPath);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.cboStation2);
            this.Controls.Add(this.lstOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboStation1);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Free Worktimes";
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboStation1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lstOut;
        private System.Windows.Forms.ComboBox cboStation2;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.ListView lstPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.Button btnWriteData;
        private System.Windows.Forms.Button button2;
    }
}