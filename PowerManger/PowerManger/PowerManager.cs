

namespace PowerManger
{
    using System.Runtime.InteropServices;
    using System;

    public struct SYSTEM_POWER_INFORMATION
    {
        public uint MaxIdlenessAllowed;
        public uint Idleness;
        public uint TimeRemaining;
        public byte CoolingMode;
    }
    public struct SYSTEM_BATTERY_STATE
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public uint Spare1;
        public uint MaxCapacity;
        public uint RemainingCapacity;
        public uint Rate;
        public uint EstimatedTime;
        public uint DefaultAlert1;
        public uint DefaultAlert2;
    }
    


public class PowerManager
    {
        [DllImport("powrprof.dll")]
        public static extern uint SetSuspendState(
            bool Hibernate,
            bool ForceCritical,
            bool DisableWakeEvent
        );

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int InformationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_POWER_INFORMATION spi,
            int nOutputBufferSize
        );

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int InformationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out UInt64 outval,
            int nOutputBufferSize
        );

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int InformationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_BATTERY_STATE spi,
            int nOutputBufferSize
        );

        public static ulong? GetLastSleepTime()
        {
            var t = Marshal.SizeOf(typeof(ulong));
            uint STATUS_SUCCESS = 0;
            ulong retvalue = 0;
            uint callsuccess = CallNtPowerInformation(15, IntPtr.Zero, 0, out retvalue, t);
            if (callsuccess == STATUS_SUCCESS)
                return retvalue;
            return null;
        }

        public static ulong? GetLastWakeTime()
        {
            var t = Marshal.SizeOf(typeof(ulong));
            uint STATUS_SUCCESS = 0;
            ulong retvalue = 0;
            uint callsuccess = CallNtPowerInformation(14, IntPtr.Zero, 0, out retvalue, t);
            if (callsuccess == STATUS_SUCCESS)
                return retvalue;
            return null;
        }

        public static SYSTEM_BATTERY_STATE? GetBatteryState()
        {
            int SystemPowerInformation = 5;
            uint STATUS_SUCCESS = 0;
            SYSTEM_BATTERY_STATE spi;

            uint retval = PowerManager.CallNtPowerInformation(
                SystemPowerInformation,
                IntPtr.Zero,
                0,
                out spi,
                Marshal.SizeOf(typeof(SYSTEM_BATTERY_STATE))
            );
            if (retval == STATUS_SUCCESS)
                return spi;
            return null;
        }

        public static SYSTEM_POWER_INFORMATION? GetSystemPowerInformation()
        {
            int SystemPowerInformation = 12;
            uint STATUS_SUCCESS = 0;
            SYSTEM_POWER_INFORMATION spi;

            uint retval = PowerManager.CallNtPowerInformation(
                SystemPowerInformation,
                IntPtr.Zero,
                0,
                out spi,
                Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION))
            );
            if (retval == STATUS_SUCCESS)
                return spi;
            return null;
        }

        public static void SetSleepState()
        {
            uint STATUS_SUCCESS = 0;
            uint retval = PowerManager.SetSuspendState(false, false, false);
        }

        public static void ReserveHyberFile()
        {
            int SystemPowerInformation = 10;
            uint STATUS_SUCCESS = 0;
            SYSTEM_POWER_INFORMATION spi;
            
            uint retval = PowerManager.CallNtPowerInformation(
                SystemPowerInformation,
                IntPtr.Zero,
                0,
                out spi,
                Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION))
            );
            if (retval == STATUS_SUCCESS)

        }

    }



}
