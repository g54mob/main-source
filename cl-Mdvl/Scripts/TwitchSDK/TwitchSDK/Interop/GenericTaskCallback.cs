using System;
using System.Runtime.InteropServices;

namespace TwitchSDK.Interop
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GenericTaskCallback(IntPtr payload, IntPtr result);
}
