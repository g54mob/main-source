using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct ReceivePacketOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private uint m_MaxDataSizeBytes;

		private IntPtr m_RequestedChannel;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public uint MaxDataSizeBytes
		{
			set
			{
			}
		}

		public byte? RequestedChannel
		{
			set
			{
			}
		}

		public void Set(ReceivePacketOptions other)
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
