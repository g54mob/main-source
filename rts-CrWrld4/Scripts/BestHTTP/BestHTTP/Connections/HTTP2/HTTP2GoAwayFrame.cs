namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2GoAwayFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte ReservedBit;

		public uint LastStreamId;

		public uint ErrorCode;

		public byte[] AdditionalDebugData;

		public uint AdditionalDebugDataLength;

		public HTTP2ErrorCodes Error => default(HTTP2ErrorCodes);

		public HTTP2GoAwayFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			ReservedBit = 0;
			LastStreamId = 0u;
			ErrorCode = 0u;
			AdditionalDebugData = null;
			AdditionalDebugDataLength = 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
