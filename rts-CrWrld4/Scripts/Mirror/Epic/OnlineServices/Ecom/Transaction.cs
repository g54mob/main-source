using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	public sealed class Transaction : Handle
	{
		public const int TransactionCopyentitlementbyindexApiLatest = 1;

		public const int TransactionGetentitlementscountApiLatest = 1;

		public Transaction()
		{
		}

		public Transaction(IntPtr innerHandle)
		{
		}

		public Result CopyEntitlementByIndex(TransactionCopyEntitlementByIndexOptions options, out Entitlement outEntitlement)
		{
			outEntitlement = null;
			return default(Result);
		}

		public uint GetEntitlementsCount(TransactionGetEntitlementsCountOptions options)
		{
			return 0u;
		}

		public Result GetTransactionId(out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public void Release()
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Ecom_Transaction_CopyEntitlementByIndex(IntPtr handle, IntPtr options, ref IntPtr outEntitlement);

		[PreserveSig]
		internal static extern uint EOS_Ecom_Transaction_GetEntitlementsCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_Ecom_Transaction_GetTransactionId(IntPtr handle, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern void EOS_Ecom_Transaction_Release(IntPtr transaction);
	}
}
