using System;

namespace Sunburst.WindowsShell.ApplicationRecovery
{
    public sealed class RecoverySettings
    {
        public RecoverySettings(Func<object, int> callback)
        {
            Callback = callback;
        }

        public RecoverySettings(Func<object, int> callback, TimeSpan interval)
        {
            Callback = callback;
            PingInterval = interval;
        }

        public Func<object, int> Callback { get; }
        public object State { get; set; }

        public TimeSpan PingInterval { get; } = TimeSpan.FromSeconds(5);
    }
}
