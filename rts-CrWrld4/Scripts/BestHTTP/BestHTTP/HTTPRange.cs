namespace BestHTTP
{
	public sealed class HTTPRange
	{
		public long FirstBytePos { get; private set; }

		public long LastBytePos { get; private set; }

		public long ContentLength { get; private set; }

		public bool IsValid { get; private set; }

		internal HTTPRange()
		{
		}

		internal HTTPRange(int contentLength)
		{
		}

		internal HTTPRange(long firstBytePosition, long lastBytePosition, long contentLength)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
