using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 56)]
	internal struct SendPacketOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_RemoteUserId;

		private IntPtr m_SocketId;

		private byte m_Channel;

		private uint m_DataLengthBytes;

		private IntPtr m_Data;

		private int m_AllowDelayedDelivery;

		private PacketReliability m_Reliability;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public ProductUserId RemoteUserId
		{
			set
			{
			}
		}

		public SocketId SocketId
		{
			set
			{
			}
		}

		public byte Channel
		{
			set
			{
			}
		}

		public byte[] Data
		{
			set
			{
			}
		}

		public bool AllowDelayedDelivery
		{
			set
			{
			}
		}

		public PacketReliability Reliability
		{
			set
			{
			}
		}

		public void Set(SendPacketOptions other)
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
