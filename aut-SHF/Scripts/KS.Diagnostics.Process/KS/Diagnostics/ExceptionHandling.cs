using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;

namespace KS.Diagnostics
{
	internal static class ExceptionHandling
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void ExceptionReceivedHandler(int hresult, string methodName, string error);

		private static Queue<Exception> exceptions;

		static ExceptionHandling()
		{
		}

		[PreserveSig]
		private static extern void AddExceptionReceived(ExceptionReceivedHandler del);

		[PreserveSig]
		private static extern void RemoveExceptionReceived();

		[MonoPInvokeCallback(typeof(ExceptionReceivedHandler))]
		private static void OutputExceptionReceivedWrapper(int hresult, string methodName, string error)
		{
		}

		private static Exception GetExceptionFromHResult(int hresult, string msg)
		{
			return null;
		}

		public static bool TryGetException(out Exception e)
		{
			e = null;
			return false;
		}
	}
}
