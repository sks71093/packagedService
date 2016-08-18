using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

using System.Timers;


namespace sampleService2
{
    public partial class Scheduler : ServiceBase
    {
        public int i;
        private Timer timer1 = null;
        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 300000;
            this.timer1.Elapsed += Timer1_Elapsed;
            timer1.Enabled = true;
            i = 1;
            Program.WriteErrorLog("The timer been started");
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Program.WriteErrorLog(String.Format("Task {0} has been completed", i));
            i++;
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Program.WriteErrorLog("Window Service has been Stopped");
        }
    }
}
