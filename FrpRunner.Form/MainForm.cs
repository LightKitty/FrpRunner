using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrpRunner.Form
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        string serviceFilePath = $"{Application.StartupPath}\\FrpRunner.Service.exe";
        string serviceName = "FrpRunner";

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName)) this.UninstallService(serviceName);
            this.InstallService(serviceFilePath);
            MessageBox.Show("安装成功");
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName))
            {
                this.ServiceStop(serviceName);
                this.UninstallService(serviceFilePath);
            }
            MessageBox.Show("卸载成功");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName)) this.ServiceStart(serviceName);
            MessageBox.Show("启动成功");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (this.IsServiceExisted(serviceName)) this.ServiceStop(serviceName);
            MessageBox.Show("停止成功");
        }

        //判断服务是否存在
        private bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        //安装服务
        private void InstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                IDictionary savedState = new Hashtable();
                installer.Install(savedState);
                installer.Commit(savedState);
            }
        }

        //卸载服务
        private void UninstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
            }
        }
        //启动服务
        private void ServiceStart(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                {
                    control.Start();
                }
            }
        }

        //停止服务
        private void ServiceStop(string serviceName)
        {
            using (ServiceController control = new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Running)
                {
                    control.Stop();
                }
            }
        }
    }
}
