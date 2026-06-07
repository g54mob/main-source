namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2DataFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte? PadLength;

		public uint DataIdx;

		public byte[] Data;

		public uint DataLength;

		public HTTP2DataFlags Flags => default(HTTP2DataFlags);

		public HTTP2DataFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			PadLength = null;
			DataIdx = 0u;
			Data = null;
			DataLength = 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
