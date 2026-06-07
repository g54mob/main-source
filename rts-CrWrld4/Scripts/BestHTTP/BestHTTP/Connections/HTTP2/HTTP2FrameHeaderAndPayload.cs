namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2FrameHeaderAndPayload
	{
		public uint PayloadLength;

		public HTTP2FrameTypes Type;

		public byte Flags;

		public uint StreamId;

		public byte[] Payload;

		public uint PayloadOffset;

		public bool DontUseMemPool;

		public override string ToString()
		{
			return null;
		}

		public string PayloadAsHex()
		{
			return null;
		}
	}
}
