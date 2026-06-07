using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices
{
	public sealed class ProductUserId : Handle
	{
		public const int ProductuseridMaxLength = 128;

		public ProductUserId()
		{
		}

		public ProductUserId(IntPtr innerHandle)
		{
		}

		public static ProductUserId FromString(string productUserIdString)
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
		internal static extern IntPtr EOS_ProductUserId_FromString(IntPtr productUserIdString);

		[PreserveSig]
		internal static extern int EOS_ProductUserId_IsValid(IntPtr accountId);

		[PreserveSig]
		internal static extern Result EOS_ProductUserId_ToString(IntPtr accountId, IntPtr outBuffer, ref int inOutBufferLength);
	}
}
