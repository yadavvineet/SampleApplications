using System.ServiceProcess;

namespace OwinSslWindowsService
{
    public partial class OwinStartupService : ServiceBase
    {
        public OwinStartupService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
