using System;

namespace Mirror
{
	public struct UpdateVarsMessage : NetworkMessage
	{
		public uint netId;

		public ArraySegment<byte> payload;
	}
}
