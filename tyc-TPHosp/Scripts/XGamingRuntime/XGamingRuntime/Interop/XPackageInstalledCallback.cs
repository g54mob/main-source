using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XPackageInstalledCallback(IntPtr context, ref XPackageDetails details);
}
