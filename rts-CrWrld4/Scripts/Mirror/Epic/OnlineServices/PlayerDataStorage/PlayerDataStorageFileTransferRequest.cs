using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	public sealed class PlayerDataStorageFileTransferRequest : Handle
	{
		public PlayerDataStorageFileTransferRequest()
		{
		}

		public PlayerDataStorageFileTransferRequest(IntPtr innerHandle)
		{
		}

		public Result CancelRequest()
		{
			return default(Result);
		}

		public Result GetFileRequestState()
		{
			return default(Result);
		}

		public Result GetFilename(out string outStringBuffer)
		{
			outStringBuffer = null;
			return default(Result);
		}

		public void Release()
		{
		}

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorageFileTransferRequest_CancelRequest(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorageFileTransferRequest_GetFileRequestState(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_PlayerDataStorageFileTransferRequest_GetFilename(IntPtr handle, uint filenameStringBufferSizeBytes, IntPtr outStringBuffer, ref int outStringLength);

		[PreserveSig]
		internal static extern void EOS_PlayerDataStorageFileTransferRequest_Release(IntPtr playerDataStorageFileTransferHandle);
	}
}
