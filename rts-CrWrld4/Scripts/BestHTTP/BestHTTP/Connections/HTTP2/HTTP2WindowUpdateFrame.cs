namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2WindowUpdateFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte ReservedBit;

		public uint WindowSizeIncrement;

		public HTTP2WindowUpdateFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			ReservedBit = 0;
			WindowSizeIncrement = 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
