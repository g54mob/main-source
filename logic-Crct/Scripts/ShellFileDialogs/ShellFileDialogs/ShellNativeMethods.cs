using System;
using System.Runtime.InteropServices;

namespace ShellFileDialogs
{
	internal static class ShellNativeMethods
	{
		[PreserveSig]
		internal static extern HResult SHCreateItemFromParsingName(string path, IntPtr pbc, ref Guid riid, out IShellItem2 shellItem);
	}
}
