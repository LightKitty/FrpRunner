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
        static Process p = null;

        public static void Start()
        {
            Stop();
            p = new Process();
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = false;
            //启动程序
            p.Start();
        }

        public static void Input(string command, bool withExit = false)
        {
            Start();
            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(command);
            p.StandardInput.AutoFlush = true;
        }

        public static void Stop()
        {
            if(p != null)
            {
                p?.Close();
            }
        }
    }
}
