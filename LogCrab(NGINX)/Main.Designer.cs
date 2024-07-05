namespace LogCrab_NGINX_
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            logCheckBox = new CheckBox();
            csvCheckBox = new CheckBox();
            logSelectButton = new Button();
            abuseipCheckBox = new CheckBox();
            timePicker = new DateTimePicker();
            apikeyTextBox = new TextBox();
            apikeyLabel = new Label();
            timeLabel = new Label();
            finnishButton = new Button();
            openLogDialog = new OpenFileDialog();
            graphCheckBox = new CheckBox();
            requiredLabel = new Label();
            optionalLabel = new Label();
            menuStrip = new MenuStrip();
            helpToolStripMenuItem = new ToolStripMenuItem();
            gitHubPageToolStripMenuItem = new ToolStripMenuItem();
            haveAnIssueToolStripMenuItem = new ToolStripMenuItem();
            firstRunToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // logCheckBox
            // 
            logCheckBox.AutoSize = true;
            logCheckBox.Location = new Point(11, 67);
            logCheckBox.Name = "logCheckBox";
            logCheckBox.Size = new Size(144, 29);
            logCheckBox.TabIndex = 0;
            logCheckBox.Text = "Make .log file";
            logCheckBox.UseVisualStyleBackColor = true;
            // 
            // csvCheckBox
            // 
            csvCheckBox.AutoSize = true;
            csvCheckBox.Location = new Point(11, 102);
            csvCheckBox.Name = "csvCheckBox";
            csvCheckBox.Size = new Size(143, 29);
            csvCheckBox.TabIndex = 1;
            csvCheckBox.Text = "Make .csv file";
            csvCheckBox.UseVisualStyleBackColor = true;
            // 
            // logSelectButton
            // 
            logSelectButton.Location = new Point(11, 456);
            logSelectButton.Name = "logSelectButton";
            logSelectButton.Size = new Size(209, 61);
            logSelectButton.TabIndex = 2;
            logSelectButton.Text = "Select log file";
            logSelectButton.UseVisualStyleBackColor = true;
            logSelectButton.Click += logSelectButton_Click;
            // 
            // abuseipCheckBox
            // 
            abuseipCheckBox.AutoSize = true;
            abuseipCheckBox.Location = new Point(12, 223);
            abuseipCheckBox.Name = "abuseipCheckBox";
            abuseipCheckBox.Size = new Size(269, 29);
            abuseipCheckBox.TabIndex = 3;
            abuseipCheckBox.Text = "In .log, use AbuseIp API data";
            abuseipCheckBox.UseVisualStyleBackColor = true;
            abuseipCheckBox.CheckedChanged += abuseipCheckBox_CheckedChanged;
            // 
            // timePicker
            // 
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.Location = new Point(11, 417);
            timePicker.Name = "timePicker";
            timePicker.Size = new Size(209, 33);
            timePicker.TabIndex = 4;
            // 
            // apikeyTextBox
            // 
            apikeyTextBox.Location = new Point(287, 223);
            apikeyTextBox.Name = "apikeyTextBox";
            apikeyTextBox.Size = new Size(650, 33);
            apikeyTextBox.TabIndex = 5;
            apikeyTextBox.Visible = false;
            // 
            // apikeyLabel
            // 
            apikeyLabel.AutoSize = true;
            apikeyLabel.Location = new Point(287, 259);
            apikeyLabel.Name = "apikeyLabel";
            apikeyLabel.Size = new Size(297, 25);
            apikeyLabel.TabIndex = 6;
            apikeyLabel.Text = "Please Input your AbuseIP API key";
            apikeyLabel.Visible = false;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(226, 417);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(330, 25);
            timeLabel.TabIndex = 7;
            timeLabel.Text = "Insert the time the script will auto-run";
            // 
            // finnishButton
            // 
            finnishButton.Location = new Point(915, 428);
            finnishButton.Name = "finnishButton";
            finnishButton.Size = new Size(243, 89);
            finnishButton.TabIndex = 8;
            finnishButton.Text = "Accept";
            finnishButton.UseVisualStyleBackColor = true;
            finnishButton.Visible = false;
            finnishButton.Click += finnishButton_Click;
            // 
            // openLogDialog
            // 
            openLogDialog.FileName = "access.txt";
            // 
            // graphCheckBox
            // 
            graphCheckBox.AutoSize = true;
            graphCheckBox.Location = new Point(12, 188);
            graphCheckBox.Name = "graphCheckBox";
            graphCheckBox.Size = new Size(335, 29);
            graphCheckBox.TabIndex = 9;
            graphCheckBox.Text = "Make a Graph with accesses per day";
            graphCheckBox.UseVisualStyleBackColor = true;
            // 
            // requiredLabel
            // 
            requiredLabel.AutoSize = true;
            requiredLabel.Location = new Point(10, 39);
            requiredLabel.Name = "requiredLabel";
            requiredLabel.Size = new Size(91, 25);
            requiredLabel.TabIndex = 10;
            requiredLabel.Text = "Required:";
            // 
            // optionalLabel
            // 
            optionalLabel.AutoSize = true;
            optionalLabel.Location = new Point(11, 160);
            optionalLabel.Name = "optionalLabel";
            optionalLabel.Size = new Size(89, 25);
            optionalLabel.TabIndex = 11;
            optionalLabel.Text = "Optional:";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { helpToolStripMenuItem, firstRunToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1170, 24);
            menuStrip.TabIndex = 12;
            menuStrip.Text = "menuStrip";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gitHubPageToolStripMenuItem, haveAnIssueToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // gitHubPageToolStripMenuItem
            // 
            gitHubPageToolStripMenuItem.Name = "gitHubPageToolStripMenuItem";
            gitHubPageToolStripMenuItem.Size = new Size(151, 22);
            gitHubPageToolStripMenuItem.Text = "GitHub Page";
            gitHubPageToolStripMenuItem.Click += gitHubPageToolStripMenuItem_Click;
            // 
            // haveAnIssueToolStripMenuItem
            // 
            haveAnIssueToolStripMenuItem.Name = "haveAnIssueToolStripMenuItem";
            haveAnIssueToolStripMenuItem.Size = new Size(151, 22);
            haveAnIssueToolStripMenuItem.Text = "Have an Issue?";
            haveAnIssueToolStripMenuItem.Click += haveAnIssueToolStripMenuItem_Click;
            // 
            // firstRunToolStripMenuItem
            // 
            firstRunToolStripMenuItem.Name = "firstRunToolStripMenuItem";
            firstRunToolStripMenuItem.Size = new Size(70, 20);
            firstRunToolStripMenuItem.Text = "First Run?";
            firstRunToolStripMenuItem.Click += firstRunToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 529);
            Controls.Add(optionalLabel);
            Controls.Add(requiredLabel);
            Controls.Add(graphCheckBox);
            Controls.Add(finnishButton);
            Controls.Add(timeLabel);
            Controls.Add(apikeyLabel);
            Controls.Add(apikeyTextBox);
            Controls.Add(timePicker);
            Controls.Add(abuseipCheckBox);
            Controls.Add(logSelectButton);
            Controls.Add(csvCheckBox);
            Controls.Add(logCheckBox);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            Name = "Main";
            Text = "LogCrab";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox logCheckBox;
        private CheckBox csvCheckBox;
        private Button logSelectButton;
        private CheckBox abuseipCheckBox;
        private DateTimePicker timePicker;
        private TextBox apikeyTextBox;
        private Label apikeyLabel;
        private Label timeLabel;
        private Button finnishButton;
        private OpenFileDialog openLogDialog;
        private CheckBox graphCheckBox;
        private Label requiredLabel;
        private Label optionalLabel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem gitHubPageToolStripMenuItem;
        private ToolStripMenuItem haveAnIssueToolStripMenuItem;
        private ToolStripMenuItem firstRunToolStripMenuItem;
    }
}
