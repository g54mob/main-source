using System;
using System.Runtime.InteropServices;

namespace NAudio.Utils
{
	internal class NativeMethods
	{
		[PreserveSig]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[PreserveSig]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

		[PreserveSig]
		public static extern bool FreeLibrary(IntPtr hModule);
	}
}
