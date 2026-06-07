using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct ReadFileOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_Filename;

		private uint m_ReadChunkLengthBytes;

		private IntPtr m_ReadFileDataCallback;

		private IntPtr m_FileTransferProgressCallback;

		private static OnReadFileDataCallbackInternal s_ReadFileDataCallback;

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

		public uint ReadChunkLengthBytes
		{
			set
			{
			}
		}

		public static OnReadFileDataCallbackInternal ReadFileDataCallback => null;

		public static OnFileTransferProgressCallbackInternal FileTransferProgressCallback => null;

		public void Set(ReadFileOptions other)
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
