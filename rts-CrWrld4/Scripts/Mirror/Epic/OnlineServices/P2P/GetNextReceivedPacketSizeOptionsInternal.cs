using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct GetNextReceivedPacketSizeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_RequestedChannel;

		public ProductUserId LocalUserId
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

		public void Set(GetNextReceivedPacketSizeOptions other)
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
