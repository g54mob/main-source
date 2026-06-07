using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class XboxLiveContext
	{
		[PreserveSig]
		public unsafe static extern int XblContextDuplicateHandle(IntPtr xboxLiveContextHandle, IntPtr* duplicatedHandle);

		[PreserveSig]
		public unsafe static extern int XblContextGetUser(IntPtr context, IntPtr* user);

		[PreserveSig]
		public unsafe static extern int XblContextGetXboxUserId(IntPtr context, ulong* xboxUserId);
	}
}
