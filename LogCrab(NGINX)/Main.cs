using Microsoft.Win32.TaskScheduler;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.Text;

namespace LogCrab_NGINX_
{
    public partial class Main : Form
    {
        private string nginxLogPath = "";
        public Main()
        {
            InitializeComponent();
        }

        private void abuseipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            apikeyTextBox.Visible = abuseipCheckBox.Checked;
            apikeyLabel.Visible = abuseipCheckBox.Checked;
        }

        private void logSelectButton_Click(object sender, EventArgs e)
        {
            if (openLogDialog.ShowDialog() == DialogResult.OK)
            {
                nginxLogPath = openLogDialog.FileName;

                nginxLogPath = nginxLogPath.Replace("\\", "\\\\");

                finnishButton.Visible = true;
            }
        }

        private void finnishButton_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(Application.StartupPath, "script");
            string iniFilePath = Path.Combine(directoryPath, "setup.ini");
            string scriptFilePath = Path.Combine(directoryPath, "runscript.bat");

            if (!logCheckBox.Checked && !csvCheckBox.Checked)
            {
                MessageBox.Show("You have to select at least one of the required options!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if ((abuseipCheckBox.Checked && apikeyTextBox.Text == "") || (abuseipCheckBox.Checked && !logCheckBox.Checked))
            {
                MessageBox.Show("If you want Abuse IP info on the logs, you must select both the log option and provide an Abuse IP api key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            FileIniDataParser parser = new FileIniDataParser();

            try
            {
                IniData data = parser.ReadFile(iniFilePath);

                bool doLog = logCheckBox.Checked;
                bool doCsv = csvCheckBox.Checked;
                bool doAbuseIp = abuseipCheckBox.Checked;
                bool doGraph = graphCheckBox.Checked;

                data["Setup"]["nginxlog_path"] = nginxLogPath;
                data["Setup"]["log"] = doLog ? "yes" : "no";
                data["Setup"]["csv"] = doCsv ? "yes" : "no";
                data["Optional"]["abuseip"] = doAbuseIp ? "yes" : "no";
                if (doAbuseIp)
                {
                    data["Optional"]["abuseip_key"] = apikeyTextBox.Text;
                }
                data["Optional"]["hour_graph"] = doGraph ? "yes" : "no";

                parser.WriteFile(iniFilePath, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime selectedTime = timePicker.Value;

            try
            {
                using (TaskService ts = new TaskService())
                {
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "Run nginx log crawler script, results in folder";

                    DailyTrigger trigger = new DailyTrigger();
                    trigger.StartBoundary = selectedTime;
                    trigger.DaysInterval = 1;
                    td.Triggers.Add(trigger);

                    td.Actions.Add(new ExecAction(scriptFilePath, null, null));

                    ts.RootFolder.RegisterTaskDefinition("RunNginxScriptTask", td);
                }

                MessageBox.Show("Task scheduled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void gitHubPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Asmosd/LogCrab-NGINX-/issues",
                UseShellExecute = true
            });
        }

        private void haveAnIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Asmosd/LogCrab-NGINX-",
                UseShellExecute = true
            });
        }

        private void firstRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(Application.StartupPath, "script");
            string scriptFilePath = Path.Combine(directoryPath, "firstrun.bat");

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = scriptFilePath,
                    UseShellExecute = true,
                    CreateNoWindow = false
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred, please report!: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
