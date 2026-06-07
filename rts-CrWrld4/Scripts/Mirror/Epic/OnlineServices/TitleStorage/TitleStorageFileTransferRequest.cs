using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.TitleStorage
{
	public sealed class TitleStorageFileTransferRequest : Handle
	{
		public TitleStorageFileTransferRequest()
		{
		}

		public TitleStorageFileTransferRequest(IntPtr innerHandle)
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
		internal static extern Result EOS_TitleStorageFileTransferRequest_CancelRequest(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_TitleStorageFileTransferRequest_GetFileRequestState(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_TitleStorageFileTransferRequest_GetFilename(IntPtr handle, uint filenameStringBufferSizeBytes, IntPtr outStringBuffer, ref int outStringLength);

		[PreserveSig]
		internal static extern void EOS_TitleStorageFileTransferRequest_Release(IntPtr titleStorageFileTransferHandle);
	}
}
