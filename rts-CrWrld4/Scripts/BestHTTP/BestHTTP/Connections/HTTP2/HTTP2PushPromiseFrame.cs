namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2PushPromiseFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte? PadLength;

		public byte ReservedBit;

		public uint PromisedStreamId;

		public uint HeaderBlockFragmentIdx;

		public byte[] HeaderBlockFragment;

		public uint HeaderBlockFragmentLength;

		public HTTP2PushPromiseFlags Flags => default(HTTP2PushPromiseFlags);

		public HTTP2PushPromiseFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			PadLength = null;
			ReservedBit = 0;
			PromisedStreamId = 0u;
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
