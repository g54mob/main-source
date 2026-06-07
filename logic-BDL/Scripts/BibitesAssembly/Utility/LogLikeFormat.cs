namespace Utility
{
	public struct LogLikeFormat
	{
		public int size;

		public int feedRatio;

		public bool isInfinite
		{
			get
			{
				if (size < 1)
				{
					return feedRatio < 1;
				}
				return false;
			}
		}

		public LogLikeFormat(int bucketSize, int bucketFeedRatio = 0)
		{
			size = bucketSize;
			feedRatio = bucketFeedRatio;
		}

		public static LogLikeFormat Infinite()
		{
			return new LogLikeFormat
			{
				size = 0,
				feedRatio = 0
			};
		}
	}
}
