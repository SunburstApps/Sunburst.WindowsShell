using System;
using System.Runtime.InteropServices;

namespace Sunburst.Win32Ole.Interfaces
{
    [ComImport, Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
    public interface IObjectArray
    {
        void GetCount(out uint pcObjects);
        void GetAt(uint index, [In] Guid iid, [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppv);
    }
}
