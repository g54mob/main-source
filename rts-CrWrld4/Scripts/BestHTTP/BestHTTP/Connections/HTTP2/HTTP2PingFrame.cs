namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2PingFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public readonly byte[] OpaqueData;

		public readonly byte OpaqueDataLength;

		public HTTP2PingFlags Flags => default(HTTP2PingFlags);

		public HTTP2PingFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			OpaqueData = null;
			OpaqueDataLength = 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
