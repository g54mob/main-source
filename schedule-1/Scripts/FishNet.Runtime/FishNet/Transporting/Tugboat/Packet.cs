using System;

namespace FishNet.Transporting.Tugboat
{
	internal struct Packet
	{
		public readonly int ConnectionId;

		public readonly byte[] Data;

		public readonly int Length;

		public readonly byte Channel;

		public Packet(int connectionId, byte[] data, int length, byte channel)
		{
			ConnectionId = 0;
			Data = null;
			Length = 0;
			Channel = 0;
		}

		public Packet(int sender, ArraySegment<byte> segment, byte channel, int mtu)
		{
			ConnectionId = 0;
			Data = null;
			Length = 0;
			Channel = 0;
		}

		public ArraySegment<byte> GetArraySegment()
		{
			return default(ArraySegment<byte>);
		}

		public void Dispose()
		{
		}
	}
}
