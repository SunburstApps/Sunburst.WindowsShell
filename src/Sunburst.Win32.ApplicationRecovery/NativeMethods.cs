using System;
using System.Runtime.InteropServices;

namespace Sunburst.Win32.ApplicationRecovery
{
    internal static class NativeMethods
    {
        internal delegate uint InternalRecoveryCallback(IntPtr state);
        internal static InternalRecoveryCallback InternalRecoveryHandler { get; } = RecoveryHandler;

        private static uint RecoveryHandler(IntPtr parameter)
        {
            bool cancelled = false;
            ApplicationRecoveryInProgress(out cancelled);
            if (cancelled) return 0;

            GCHandle handle = GCHandle.FromIntPtr(parameter);
            RecoverySettings settings = (RecoverySettings)handle.Target;
            settings.Callback?.Invoke(settings.State);
            handle.Free();

            return 0;
        }

        [DllImport("kernel32.dll")]
        internal static extern void ApplicationRecoveryFinished([In, MarshalAs(UnmanagedType.Bool)] bool succeeded);

        [DllImport("kernel32.dll", PreserveSig = true)]
        internal static extern int ApplicationRecoveryInProgress([Out, MarshalAs(UnmanagedType.Bool)] out bool cancelled);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        internal static extern int RegisterApplicationRecoveryCallback(InternalRecoveryCallback callback, IntPtr param, uint pingInterval, uint flags);

        [DllImport("kernel32.dll", PreserveSig = true)]
        internal static extern int UnregisterApplicationRecoveryCallback();

        [DllImport("kernel32.dll", PreserveSig = true)]
        internal static extern int RegisterApplicationRestart([MarshalAs(UnmanagedType.BStr)] string commandLine, RestartCondition flags);

        [DllImport("kernel32.dll", PreserveSig = true)]
        internal static extern int UnregisterApplicationRestart();
    }
}
