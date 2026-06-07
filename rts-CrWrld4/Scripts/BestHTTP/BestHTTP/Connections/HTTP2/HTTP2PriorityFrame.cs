namespace BestHTTP.Connections.HTTP2
{
	public struct HTTP2PriorityFrame
	{
		public readonly HTTP2FrameHeaderAndPayload Header;

		public byte IsExclusive;

		public uint StreamDependency;

		public byte Weight;

		public HTTP2PriorityFrame(HTTP2FrameHeaderAndPayload header)
		{
			Header = default(HTTP2FrameHeaderAndPayload);
			IsExclusive = 0;
			StreamDependency = 0u;
			Weight = 0;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
