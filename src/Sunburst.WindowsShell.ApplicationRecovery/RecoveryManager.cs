using System;
using System.Runtime.InteropServices;

namespace Sunburst.WindowsShell.ApplicationRecovery
{
    public static class RecoveryManager
    {
        public static bool IsPlatformSupported
        {
            get
            {
                if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return false;
                return Environment.OSVersion.Version.Major >= 6;
            }
        }

        public static void RegisterApplicationRecovery(RecoverySettings settings)
        {
            if (!IsPlatformSupported) throw new PlatformNotSupportedException("Requires Windows Vista or later");

            if (settings == null) throw new ArgumentNullException(nameof(settings));

            GCHandle handle = GCHandle.Alloc(settings);
            int hr = NativeMethods.RegisterApplicationRecoveryCallback(NativeMethods.InternalRecoveryHandler,
                GCHandle.ToIntPtr(handle), (uint)Math.Round(settings.PingInterval.TotalMilliseconds), 0);
            if (hr != 0) Marshal.ThrowExceptionForHR(hr);
        }

        public static void UnregisterApplicationRecovery()
        {
            if (!IsPlatformSupported) throw new PlatformNotSupportedException("Requires Windows Vista or later");

            int hr = NativeMethods.UnregisterApplicationRecoveryCallback();
            if (hr != 0) Marshal.ThrowExceptionForHR(hr);
        }

        public static bool ApplicationRecoveryInProgress()
        {
            if (!IsPlatformSupported) throw new PlatformNotSupportedException("Requires Windows Vista or later");

            bool cancelled = false;
            int hr = NativeMethods.ApplicationRecoveryInProgress(out cancelled);
            if (hr != 0) Marshal.ThrowExceptionForHR(hr);

            return cancelled;
        }

        public static void ApplicationRecoveryFinished(bool succeeded)
        {
            if (!IsPlatformSupported) throw new PlatformNotSupportedException("Requires Windows Vista or later");

            NativeMethods.ApplicationRecoveryFinished(succeeded);
        }

        public static void RegisterApplicationRestart(string command, RestartCondition condition)
        {
            if (!IsPlatformSupported) throw new PlatformNotSupportedException("Requires Windows Vista or later");

            if (command == null) throw new ArgumentNullException(nameof(command));

            int hr = NativeMethods.RegisterApplicationRestart(command, condition);
            if (hr != 0) Marshal.ThrowExceptionForHR(hr);
        }

        public static void UnregisterApplicationRestart()
        {
            if (!IsPlatformSupported) throw new PlatformNotSupportedException("Requires Windows Vista or later");

            int hr = NativeMethods.UnregisterApplicationRestart();
            if (hr != 0) Marshal.ThrowExceptionForHR(hr);
        }
    }
}
