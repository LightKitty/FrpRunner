using FrpRunner.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpRunner.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CmdHelper.Input(@"cd /d D:\Program Files\frp\ && .\frpc.exe -c .\frpc.ini");
        }
    }
}
