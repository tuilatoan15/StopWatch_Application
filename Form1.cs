using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StopWatch_Application
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        Stopwatch stopwatch;
        int h, m, s, ms;
        public Form1()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();
            timer = new System.Timers.Timer();
            timer.Interval = 10;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            Invoke(new Action(() =>
            {
                TimeSpan ts = stopwatch.Elapsed;
                lblTime.Text = string.Format("{0}:{1}:{2}:{3}",
                    ts.Hours.ToString().PadLeft(2, '0'),
                    ts.Minutes.ToString().PadLeft(2, '0'),
                    ts.Seconds.ToString().PadLeft(2, '0'),
                    (ts.Milliseconds / 10).ToString().PadLeft(2, '0'));
            }));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            timer.Stop();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            timer.Stop();
            h = m = s = ms = 0;
            lblTime.Text = "00:00:00:00";
        }
    }
}
