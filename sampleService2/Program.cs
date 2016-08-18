using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sampleService2
{
    public static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Scheduler()
            };
            ServiceBase.Run(ServicesToRun);
        }
        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory +"\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ":" + ex.Source.ToString().Trim() + ";" + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
        public static void WriteErrorLog(String message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory +"\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ":" + message);
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
    }
}
