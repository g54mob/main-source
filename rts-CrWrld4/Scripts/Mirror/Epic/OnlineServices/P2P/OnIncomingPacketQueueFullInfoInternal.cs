using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct OnIncomingPacketQueueFullInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private ulong m_PacketQueueMaxSizeBytes;

		private ulong m_PacketQueueCurrentSizeBytes;

		private IntPtr m_OverflowPacketLocalUserId;

		private byte m_OverflowPacketChannel;

		private uint m_OverflowPacketSizeBytes;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ulong PacketQueueMaxSizeBytes => 0uL;

		public ulong PacketQueueCurrentSizeBytes => 0uL;

		public ProductUserId OverflowPacketLocalUserId => null;

		public byte OverflowPacketChannel => 0;

		public uint OverflowPacketSizeBytes => 0u;
	}
}
