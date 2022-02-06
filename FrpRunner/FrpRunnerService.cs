using FrpRunner.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FrpRunner.Service
{
    public partial class FrpRunnerService : ServiceBase
    {
        public FrpRunnerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            FrpHelper.Start();
        }

        protected override void OnStop()
        {
            FrpHelper.Stop();
        }
    }
}
