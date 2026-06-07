using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct WriteFileDataCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_Filename;

		private uint m_DataBufferLengthBytes;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;

		public string Filename => null;

		public uint DataBufferLengthBytes => 0u;
	}
}
