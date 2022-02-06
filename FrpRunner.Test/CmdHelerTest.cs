using FrpRunner.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrpRunner.Test
{
    [TestClass]
    public class CmdHelerTest
    {
        [TestMethod]
        public void InputTest()
        {
            //CmdHelper.Input(@"notepad");
            //string result = CmdHelper.Input("ipconfig", false);
            CmdHelper.Stop();
            Console.ReadLine();
        }

        [TestMethod]
        public void StartTest()
        {
            CmdHelper.Start();
            Console.ReadLine();
        }
    }
}
