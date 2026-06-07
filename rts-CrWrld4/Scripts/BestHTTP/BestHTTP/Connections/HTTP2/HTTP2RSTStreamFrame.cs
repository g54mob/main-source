namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2RSTStreamFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public uint ErrorCode;

		public HTTP2ErrorCodes Error => default(HTTP2ErrorCodes);

		public HTTP2RSTStreamFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			ErrorCode = 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
