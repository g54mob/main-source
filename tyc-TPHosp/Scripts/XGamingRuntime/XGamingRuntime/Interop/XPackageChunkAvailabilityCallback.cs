using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate NativeBool XPackageChunkAvailabilityCallback(IntPtr context, ref XPackageChunkSelector selector, XPackageChunkAvailability availability);
}
