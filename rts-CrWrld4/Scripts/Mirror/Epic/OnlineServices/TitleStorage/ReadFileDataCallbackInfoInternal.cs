using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.TitleStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct ReadFileDataCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_Filename;

		private uint m_TotalFileSizeBytes;

		private int m_IsLastChunk;

		private uint m_DataChunkLengthBytes;

		private IntPtr m_DataChunk;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;

		public string Filename => null;

		public uint TotalFileSizeBytes => 0u;

		public bool IsLastChunk => false;

		public byte[] DataChunk => null;
	}
}
