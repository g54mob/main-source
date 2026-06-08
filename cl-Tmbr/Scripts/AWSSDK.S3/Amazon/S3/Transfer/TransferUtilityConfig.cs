using System;

namespace Amazon.S3.Transfer
{
	public class TransferUtilityConfig
	{
		private long _minSizeBeforePartUpload = 16 * (long)Math.Pow(2.0, 20.0);

		private int _concurrentServiceRequests;

		public long MinSizeBeforePartUpload
		{
			get
			{
				return _minSizeBeforePartUpload;
			}
			set
			{
				_minSizeBeforePartUpload = value;
			}
		}

		public int ConcurrentServiceRequests
		{
			get
			{
				return _concurrentServiceRequests;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				_concurrentServiceRequests = value;
			}
		}

		public TransferUtilityConfig()
		{
			ConcurrentServiceRequests = 10;
		}
	}
}
