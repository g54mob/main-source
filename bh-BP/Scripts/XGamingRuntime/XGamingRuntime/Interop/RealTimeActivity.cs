using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class RealTimeActivity
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void XblRealTimeActivityConnectionStateChangeHandler(IntPtr context, XblRealTimeActivityConnectionState connectionState);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void XblRealTimeActivityResyncHandler(IntPtr context);

		[PreserveSig]
		public static extern int XblRealTimeActivityAddConnectionStateChangeHandler(IntPtr xboxLiveContext, XblRealTimeActivityConnectionStateChangeHandler handler, IntPtr context);

		[PreserveSig]
		public static extern int XblRealTimeActivityRemoveConnectionStateChangeHandler(IntPtr xboxLiveContext, int token);

		[PreserveSig]
		public static extern int XblRealTimeActivityAddResyncHandler(IntPtr xboxLiveContext, XblRealTimeActivityResyncHandler handler, IntPtr context);

		[PreserveSig]
		public static extern int XblRealTimeActivityRemoveResyncHandler(IntPtr xboxLiveContext, int token);
	}
}
