using System;
using System.Runtime.InteropServices;

namespace Sunburst.Win32Ole.ObjectArray
{
    [ComImport, Guid("5632b1a4-e38a-400a-928a-d4cd63230295")]
    public interface IObjectCollection
    {
        void AddObject([MarshalAs(UnmanagedType.IUnknown)] object obj);
        void AddFromArray([In] IObjectArray source);
        void RemoveObjectAt(uint index);
        void Clear();
    }
}
