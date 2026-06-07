namespace BestHTTP.Extensions
{
	public sealed class PeekableIncomingSegmentStream : BufferSegmentStream
	{
		private int peek_listIdx;

		private int peek_pos;

		public void BeginPeek()
		{
		}

		public int PeekByte()
		{
			return 0;
		}
	}
}
