using System;
using System.Runtime.InteropServices;
using Sunburst.Win32Ole.Interfaces;

namespace Sunburst.Win32Ole
{
    public static class ServiceProviderHelper
    {
        public static object QueryService(this IOleServiceProvider source, Guid serviceId, Guid requestedIID)
        {
            try
            {
                object obj;
                source.QueryService(ref serviceId, ref requestedIID, out obj);
                return obj;
            }
            catch (COMException)
            {
                return null;
            }
        }

        public static T QueryService<T>(this IOleServiceProvider source, Guid serviceId)
        {
            return (T)QueryService(source, serviceId, typeof(T).GUID);
        }
    }
}
