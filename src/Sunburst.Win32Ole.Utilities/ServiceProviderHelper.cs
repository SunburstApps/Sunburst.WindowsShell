﻿using System.Runtime.InteropServices;
using Sunburst.Win32Ole.Interfaces;
using Guid = System.Guid;

namespace Sunburst.Win32Ole
{
    public static class ServiceProviderHelper
    {
        public static object QueryService(this IServiceProvider source, Guid serviceId, Guid requestedIID)
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

        public static T QueryService<T>(this IServiceProvider source, Guid serviceId)
        {
            return (T)QueryService(source, serviceId, typeof(T).GUID);
        }
    }
}
