namespace PowerManager.Test
{
    using System;
    using global::PowerManager;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PowerManagerTests
    {
        [TestMethod]
        public void TestGetPowerInfo()
        {
            var manager = new PowerManager();
            var powerinfo = manager.GetSystemPowerInformation();
            Assert.IsTrue(powerinfo.HasValue);
            Console.WriteLine(powerinfo.Value.TimeRemaining);
            Console.WriteLine(powerinfo.Value.CoolingMode);
            Console.WriteLine(powerinfo.Value.Idleness);
        }

        [TestMethod]
        public void TestGetLastSleepTime()
        {
            var manager = new PowerManager();
            var retvalue = manager.GetLastSleepTime();
            Assert.IsTrue(retvalue.HasValue);
            Console.WriteLine(retvalue);
        }

        [TestMethod]
        public void TestGetLastWakeTime()
        {
            var manager = new PowerManager();
            var retvalue = manager.GetLastWakeTime();
            Assert.IsTrue(retvalue.HasValue);
            Console.WriteLine(retvalue);
        }

        [TestMethod]
        public void TestGetBatteryState()
        {
            var manager = new PowerManager();
            var batteryState = manager.GetBatteryState();
            Assert.IsTrue(batteryState.HasValue);
            Console.WriteLine(batteryState.Value.AcOnLine);
            Console.WriteLine(batteryState.Value.BatteryPresent);
            Console.WriteLine(batteryState.Value.Charging);
        }

        [TestMethod]
        public void TestSleepState()
        {
            var manager = new PowerManager();
            //manager.SetSleepState();
        }

        [TestMethod]
        public void TestReserveHybernationFile()
        {
            var manager = new PowerManager();
            var filesize = manager.ReserveHyberFile();
            Assert.IsTrue(filesize > 0);
            Console.WriteLine(filesize);
        }

        [TestMethod]
        public void TestFreeHybernationFile()
        {
            var manager = new PowerManager();
            var filesize = manager.FreeHybernatoinFile();
            Assert.IsTrue(filesize > 0);
            Console.WriteLine(filesize);
        }
    }
}
