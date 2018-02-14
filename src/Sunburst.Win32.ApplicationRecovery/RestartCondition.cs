using System;
using System.Collections.Generic;
using System.Text;

namespace Sunburst.Win32.ApplicationRecovery
{
    [Flags]
    public enum RestartCondition
    {
        Always = 0,
        NotOnCrash = 1,
        NotOnHang = 2,
        NotOnPatch = 4,
        NotOnReboot = 8
    }
}
