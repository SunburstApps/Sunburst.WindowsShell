using System.Runtime.InteropServices;

namespace Sunburst.Win32.Ole
{
    /// <summary>
    /// Contains utility methods for dealing with <c>HRESULT</c> values.
    /// </summary>
    public static class HRESULT
    {
        /// <summary>
        /// Returns the specified <c>HRESULT</c> to COM. Equivalent to returning
        /// the value from a method marked with <see cref="PreserveSigAttribute"/>.
        /// </summary>
        /// <param name="hr">
        /// The <c>HRESULT</c> to return.
        /// </param>
        public static void Return(int hr) => throw new COMException(string.Empty, hr);

        /// <summary>
        /// Tests if the specified <c>HRESULT</c> represents a success condition.
        /// </summary>
        /// <param name="hr">
        /// An <c>HRESULT</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="hr"/> represents a success condition, or <c>false</c> otherwise.
        /// </returns>
        public static bool Succeeded(int hr) => hr >= 0;

        /// <summary>
        /// Tests if the specified <c>HRESULT</c> represents an error condition.
        /// </summary>
        /// <param name="hr">
        /// An <c>HRESULT</c>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the <paramref name="hr"/> represents an error condition, or <c>false</c> otherwise.
        /// </returns>
        public static bool Failed(int hr) => hr < 0;

        /// <summary>
        /// Throws an exception (using <see cref="Marshal.ThrowExceptionForHR(int)"/>) if the given
        /// <c>HRESULT</c> represents an error condition.
        /// </summary>
        /// <param name="hr">
        /// An <c>HRESULT</c>.
        /// </param>
        public static void Check(int hr)
        {
            if (Failed(hr)) Marshal.ThrowExceptionForHR(hr);
        }
    }
}
