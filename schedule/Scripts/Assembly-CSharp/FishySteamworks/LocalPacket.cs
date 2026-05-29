using System;

namespace FishySteamworks
{
	internal struct LocalPacket
	{
		public byte[] Data;

		public int Length;

		public byte Channel;

		public LocalPacket(ArraySegment<byte> data, byte channel)
		{
			Data = null;
			Length = 0;
			Channel = 0;
		}
	}
}
