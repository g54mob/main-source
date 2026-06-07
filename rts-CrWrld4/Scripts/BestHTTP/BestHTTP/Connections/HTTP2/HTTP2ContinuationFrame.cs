namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2ContinuationFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte[] HeaderBlockFragment;

		public HTTP2ContinuationFlags Flags => default(HTTP2ContinuationFlags);

		public uint HeaderBlockFragmentLength => 0u;

		public HTTP2ContinuationFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			HeaderBlockFragment = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
