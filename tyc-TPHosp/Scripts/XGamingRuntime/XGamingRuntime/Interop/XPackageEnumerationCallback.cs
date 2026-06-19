using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate NativeBool XPackageEnumerationCallback(IntPtr context, ref XPackageDetails details);
}
