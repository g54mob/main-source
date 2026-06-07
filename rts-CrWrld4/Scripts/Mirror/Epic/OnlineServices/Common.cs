using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	public static class Common
	{
		public const ulong InvalidNotificationid = 0uL;

		public const int PagequeryApiLatest = 1;

		public const int PagequeryMaxcountDefault = 10;

		public const int PagequeryMaxcountMaximum = 100;

		public const int PaginationApiLatest = 1;

		public static bool IsOperationComplete(Result result)
		{
			return false;
		}

		public static string ToString(Result result)
		{
			return null;
		}

		public static Result ToString(byte[] byteArray, out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		[PreserveSig]
		internal static extern int EOS_EResult_IsOperationComplete(Result result);

		[PreserveSig]
		internal static extern IntPtr EOS_EResult_ToString(Result result);

		[PreserveSig]
		internal static extern Result EOS_ByteArray_ToString(IntPtr byteArray, uint length, IntPtr outBuffer, ref uint inOutBufferLength);
	}
}
