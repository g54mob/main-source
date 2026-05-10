using System;
using System.Runtime.InteropServices;

namespace Mono.Btls
{
	internal static class MonoBtlsError
	{
		[PreserveSig]
		private static extern void mono_btls_error_clear_error();

		[PreserveSig]
		private static extern int mono_btls_error_get_error_line(out IntPtr file, out int line);

		[PreserveSig]
		private static extern void mono_btls_error_get_error_string_n(int error, IntPtr buf, int len);

		[PreserveSig]
		private static extern int mono_btls_error_get_reason(int error);

		public static void ClearError()
		{
		}

		public static string GetErrorString(int error)
		{
			return null;
		}

		public static int GetError(out string file, out int line)
		{
			file = null;
			line = default(int);
			return 0;
		}

		public static int GetErrorReason(int error)
		{
			return 0;
		}
	}
}
