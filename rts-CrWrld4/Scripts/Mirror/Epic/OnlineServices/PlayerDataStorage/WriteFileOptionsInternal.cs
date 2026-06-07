using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct WriteFileOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_Filename;

		private uint m_ChunkLengthBytes;

		private IntPtr m_WriteFileDataCallback;

		private IntPtr m_FileTransferProgressCallback;

		private static OnWriteFileDataCallbackInternal s_WriteFileDataCallback;

		private static OnFileTransferProgressCallbackInternal s_FileTransferProgressCallback;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public string Filename
		{
			set
			{
			}
		}

		public uint ChunkLengthBytes
		{
			set
			{
			}
		}

		public static OnWriteFileDataCallbackInternal WriteFileDataCallback => null;

		public static OnFileTransferProgressCallbackInternal FileTransferProgressCallback => null;

		public void Set(WriteFileOptions other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
