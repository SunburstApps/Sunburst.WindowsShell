using System;
using System.Runtime.InteropServices;

namespace Sunburst.Win32.Ole.Interfaces
{
    [ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    public interface IOleServiceProvider
    {
        void QueryService([In] ref Guid serviceId, [In] ref Guid iid, [Out, MarshalAs(UnmanagedType.Interface)] out object obj);
    }

    [ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    public interface IOleServiceProviderRaw
    {
        [PreserveSig]
        int QueryService([In] ref Guid serviceId, [In] ref Guid iid, [Out] out IntPtr obj);
    }
}
