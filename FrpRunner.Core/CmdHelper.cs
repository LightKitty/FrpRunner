using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpRunner.Core
{
    public static class CmdHelper
    {
        static Process cmd = null;

        public static void Start()
        {
            Stop();
            cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            cmd.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            cmd.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            cmd.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            cmd.StartInfo.CreateNoWindow = true;//不显示程序窗口
            cmd.Start();//启动程序
        }

        public static string Input(string str, bool withExit = true)
        {
            Start();
            cmd.StandardInput.WriteLine(str + (withExit ? "&exit" : string.Empty)); //向cmd窗口发送输入信息
            string output = cmd?.StandardOutput?.ReadToEnd(); //获取cmd窗口的输出信息
            return output;
        }

        public static void Stop()
        {
            if(cmd != null)
            {
                cmd?.Close();
                cmd?.Kill();
                cmd?.Dispose();
            }
        }
    }
}
