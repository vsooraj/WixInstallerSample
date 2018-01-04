using System.IO;

namespace SchedulerService
{
    class ScheduleService
    {
        System.Timers.Timer timeDelay;
        int count;
        public ScheduleService()
        {
            timeDelay = new System.Timers.Timer();
            timeDelay.Elapsed += new System.Timers.ElapsedEventHandler(WorkProcess);
        }
        public bool Start()
        {
            LogService("Service is Started");
            timeDelay.Enabled = true;

            return true;
        }
        public void WorkProcess(object sender, System.Timers.ElapsedEventArgs e)
        {
            string process = "Timer Tick " + count;
            LogService(process);
            count++;
        }

        public bool Stop()
        {
            LogService("Service Stoped");
            timeDelay.Enabled = false;

            return true;
        }
        private void LogService(string content)
        {
            var fs = new FileStream(@"c:\temp\a\WiXServiceLog.txt", FileMode.OpenOrCreate, FileAccess.Write);
            using (var sw = new StreamWriter(fs))
            {
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(content);
                sw.Flush();
                sw.Close();
            }
        }


    }
}
