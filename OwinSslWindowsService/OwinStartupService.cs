using System;
using System.Configuration;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace OwinSslWindowsService
{
    /// <summary>
    /// Owiwn Startup Service
    /// </summary>
    public partial class OwinStartupService : ServiceBase
    {
        private const string serverNameKey = "serverHostName";
        private IDisposable server;
        /// <summary>
        /// Constructor
        /// </summary>
        public OwinStartupService()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On Service Start
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            string baseAddress = ConfigurationManager.AppSettings[serverNameKey];
            server = WebApp.Start<OwinStartup>(baseAddress);
        }

        /// <summary>
        /// On Service Stop
        /// </summary>
        protected override void OnStop()
        {
            server?.Dispose();
        }
    }
}
