namespace Utility
{
	public struct LogLikeConfig
	{
		public LogLikeFormat[] formats;

		public Timescale acquisition;

		public int acquisitionFactor;

		public bool lastBucketIsInfinite;

		public LogLikeConfig(LogLikeFormat[] formats, Timescale acquisition, int factor = 1)
		{
			this.formats = formats;
			this.acquisition = acquisition;
			acquisitionFactor = factor;
			lastBucketIsInfinite = formats[^1].size == 0;
		}
	}
}
