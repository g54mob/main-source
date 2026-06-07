namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2HeadersFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte? PadLength;

		public byte? IsExclusive;

		public uint? StreamDependency;

		public byte? Weight;

		public uint HeaderBlockFragmentIdx;

		public byte[] HeaderBlockFragment;

		public uint HeaderBlockFragmentLength;

		public HTTP2HeadersFlags Flags => default(HTTP2HeadersFlags);

		public HTTP2HeadersFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			PadLength = null;
			IsExclusive = null;
			StreamDependency = null;
			Weight = null;
			HeaderBlockFragmentIdx = 0u;
			HeaderBlockFragment = null;
			HeaderBlockFragmentLength = 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
