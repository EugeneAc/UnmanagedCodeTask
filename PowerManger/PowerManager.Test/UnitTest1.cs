using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using System.Runtime.InteropServices;

    using PowerManger;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetPowerInfo()
        {
            var powerinfo = PowerManager.GetSystemPowerInformation();
            Assert.IsTrue(powerinfo.HasValue);
            Console.WriteLine(powerinfo.Value.TimeRemaining);
            Console.WriteLine(powerinfo.Value.CoolingMode);
            Console.WriteLine(powerinfo.Value.Idleness);
        }

        [TestMethod]
        public void TestGetLastSleepTime()
        {
            var retvalue = PowerManager.GetLastSleepTime();
            Assert.IsTrue(retvalue.HasValue);
            Console.WriteLine(retvalue);
        }

        [TestMethod]
        public void TestGetLastWakeTime()
        {
            var retvalue = PowerManager.GetLastSleepTime();
            Assert.IsTrue(retvalue.HasValue);
            Console.WriteLine(retvalue);
        }

        [TestMethod]
        public void GetBatteryState()
        {
            var batteryState = PowerManager.GetBatteryState();
            Assert.IsTrue(batteryState.HasValue);
            Console.WriteLine(batteryState.Value.AcOnLine);
            Console.WriteLine(batteryState.Value.BatteryPresent);
            Console.WriteLine(batteryState.Value.Charging);
        }
        [TestMethod]
        public void TestSleepState()
        {
            //PowerManager.SetSleepState();
        }

    }
}
