using System;
using System.Runtime.InteropServices;

namespace Mono.Unix.Native
{
	public class Stdlib
	{
		private static bool versionCheckPerformed;

		private static readonly IntPtr _SIG_DFL;

		private static readonly IntPtr _SIG_ERR;

		private static readonly IntPtr _SIG_IGN;

		[CLSCompliant(false)]
		public static readonly SignalHandler SIG_DFL;

		[CLSCompliant(false)]
		public static readonly SignalHandler SIG_ERR;

		[CLSCompliant(false)]
		public static readonly SignalHandler SIG_IGN;

		[CLSCompliant(false)]
		public static readonly int _IOFBF;

		[CLSCompliant(false)]
		public static readonly int _IOLBF;

		[CLSCompliant(false)]
		public static readonly int _IONBF;

		[CLSCompliant(false)]
		public static readonly int BUFSIZ;

		[CLSCompliant(false)]
		public static readonly int EOF;

		[CLSCompliant(false)]
		public static readonly int FOPEN_MAX;

		[CLSCompliant(false)]
		public static readonly int FILENAME_MAX;

		[CLSCompliant(false)]
		public static readonly int L_tmpnam;

		public static readonly IntPtr stderr;

		public static readonly IntPtr stdin;

		public static readonly IntPtr stdout;

		[CLSCompliant(false)]
		public static readonly int TMP_MAX;

		private static object tmpnam_lock;

		[CLSCompliant(false)]
		public static readonly int EXIT_FAILURE;

		[CLSCompliant(false)]
		public static readonly int EXIT_SUCCESS;

		[CLSCompliant(false)]
		public static readonly int MB_CUR_MAX;

		[CLSCompliant(false)]
		public static readonly int RAND_MAX;

		private static object strerror_lock;

		[PreserveSig]
		private static extern IntPtr VersionStringPtr();

		internal static void VersionCheck()
		{
		}

		static Stdlib()
		{
		}

		[PreserveSig]
		private static extern IntPtr GetDefaultSignal();

		[PreserveSig]
		private static extern IntPtr GetErrorSignal();

		[PreserveSig]
		private static extern IntPtr GetIgnoreSignal();

		private static void _ErrorHandler(int signum)
		{
		}

		private static void _DefaultHandler(int signum)
		{
		}

		private static void _IgnoreHandler(int signum)
		{
		}

		[PreserveSig]
		private static extern int GetFullyBuffered();

		[PreserveSig]
		private static extern int GetLineBuffered();

		[PreserveSig]
		private static extern int GetNonBuffered();

		[PreserveSig]
		private static extern int GetBufferSize();

		[PreserveSig]
		private static extern int GetEOF();

		[PreserveSig]
		private static extern int GetFilenameMax();

		[PreserveSig]
		private static extern int GetFopenMax();

		[PreserveSig]
		private static extern int GetTmpnamLength();

		[PreserveSig]
		private static extern IntPtr GetStandardInput();

		[PreserveSig]
		private static extern IntPtr GetStandardOutput();

		[PreserveSig]
		private static extern IntPtr GetStandardError();

		[PreserveSig]
		private static extern int GetTmpMax();

		[PreserveSig]
		private static extern int GetExitFailure();

		[PreserveSig]
		private static extern int GetExitSuccess();

		[PreserveSig]
		private static extern int GetMbCurMax();

		[PreserveSig]
		private static extern int GetRandMax();
	}
}
