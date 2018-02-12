using System;

namespace Sunburst.WindowsShell.ApplicationRecovery
{
    public class RecoveryException : Exception
    {
        public RecoveryException() { }
        public RecoveryException(string message) : base(message) { }
        public RecoveryException(string message, Exception inner) : base(message, inner) { }
    }
}
