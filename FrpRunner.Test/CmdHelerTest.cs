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
            CmdHelper.Input(@"notepad");
            //string result = CmdHelper.Input("ipconfig", true);
            Console.ReadLine();
        }
    }
}
