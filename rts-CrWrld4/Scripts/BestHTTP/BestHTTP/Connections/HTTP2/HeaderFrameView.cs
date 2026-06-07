namespace BestHTTP.Connections.HTTP2
{
	internal sealed class HeaderFrameView : CommonFrameView
	{
		public override void AddFrame(HTTP2FrameHeaderAndPayload frame)
		{
		}

		protected override long CalculateDataLengthForFrame(HTTP2FrameHeaderAndPayload frame)
		{
			return 0L;
		}

		protected override bool AdvanceFrame()
		{
			return false;
		}
	}
}
