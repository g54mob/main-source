using System;
using System.Runtime.InteropServices;

namespace KS.Diagnostics
{
	public static class MarshalHelper
	{
		[PreserveSig]
		public static extern void Free(IntPtr ptr);

		[PreserveSig]
		public static extern void FreeGCHandle(IntPtr ptr);

		public static string FromUni(this IntPtr ptrStr, bool free = true)
		{
			return null;
		}

		public static IntPtr ToUniPtr(this string s)
		{
			return (IntPtr)0;
		}
	}
}
