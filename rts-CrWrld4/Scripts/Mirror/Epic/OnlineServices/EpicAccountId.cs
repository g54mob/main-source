using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	public sealed class EpicAccountId : Handle
	{
		public const int EpicaccountidMaxLength = 32;

		public EpicAccountId()
		{
		}

		public EpicAccountId(IntPtr innerHandle)
		{
		}

		public static EpicAccountId FromString(string accountIdString)
		{
			return null;
		}

		public bool IsValid()
		{
			return false;
		}

		public Result ToString(out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		[PreserveSig]
		internal static extern IntPtr EOS_EpicAccountId_FromString(IntPtr accountIdString);

		[PreserveSig]
		internal static extern int EOS_EpicAccountId_IsValid(IntPtr accountId);

		[PreserveSig]
		internal static extern Result EOS_EpicAccountId_ToString(IntPtr accountId, IntPtr outBuffer, ref int inOutBufferLength);
	}
}
