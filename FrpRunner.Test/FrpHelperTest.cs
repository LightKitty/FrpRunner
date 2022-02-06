using FrpRunner.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrpRunner.Test
{
    [TestClass]
    public class FrpHelperTest
    {
        [TestMethod]
        public void RunTest()
        {
            FrpHelper.Start();
            Console.ReadLine();
        }
    }
}
