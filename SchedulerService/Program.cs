using Topshelf;

namespace SchedulerService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.Service<ScheduleService>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(() => new ScheduleService());
                    serviceInstance.WhenStarted(execute => execute.Start());
                    serviceInstance.WhenStopped(execute => execute.Stop());

                });
                serviceConfig.SetServiceName("WiXSchedulerService");
                serviceConfig.SetDisplayName("WiX Scheduler Service");
                serviceConfig.SetDescription("WiX Scheduler Service");
                serviceConfig.StartAutomatically();
            });
        }
    }
}
