using LightLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrpRunner.Core
{
    public static class FrpHelper
    {
        public static void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    CmdHelper.Input(@"cd /d D:\Program Files\frp\ && .\frpc.exe -c .\frpc.ini", false);
                }
                catch (Exception ex)
                {
                    Log.Error("FrpHelper.Start error", ex);
                }
            });
        }

        public static void Stop()
        {
            try
            {
                CmdHelper.Stop();
            }
            catch (Exception ex)
            {
                Log.Error("FrpHelper.Start error", ex);
            }
        }
    }
}
