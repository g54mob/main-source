using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct PacketQueueInfoInternal : ISettable, IDisposable
	{
		private ulong m_IncomingPacketQueueMaxSizeBytes;

		private ulong m_IncomingPacketQueueCurrentSizeBytes;

		private ulong m_IncomingPacketQueueCurrentPacketCount;

		private ulong m_OutgoingPacketQueueMaxSizeBytes;

		private ulong m_OutgoingPacketQueueCurrentSizeBytes;

		private ulong m_OutgoingPacketQueueCurrentPacketCount;

		public ulong IncomingPacketQueueMaxSizeBytes
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong IncomingPacketQueueCurrentSizeBytes
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong IncomingPacketQueueCurrentPacketCount
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong OutgoingPacketQueueMaxSizeBytes
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong OutgoingPacketQueueCurrentSizeBytes
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong OutgoingPacketQueueCurrentPacketCount
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public void Set(PacketQueueInfo other)
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
