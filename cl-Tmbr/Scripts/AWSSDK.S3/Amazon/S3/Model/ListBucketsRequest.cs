using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class ListBucketsRequest : AmazonWebServiceRequest
	{
		private string _continuationToken;

		private int? _maxBuckets;

		private string _prefix;

		private string _bucketRegion;

		public string ContinuationToken
		{
			get
			{
				return _continuationToken;
			}
			set
			{
				_continuationToken = value;
			}
		}

		[AWSProperty(Min = 1L, Max = 10000L)]
		public int MaxBuckets
		{
			get
			{
				return _maxBuckets.GetValueOrDefault();
			}
			set
			{
				_maxBuckets = value;
			}
		}

		public string Prefix
		{
			get
			{
				return _prefix;
			}
			set
			{
				_prefix = value;
			}
		}

		public string BucketRegion
		{
			get
			{
				return _bucketRegion;
			}
			set
			{
				_bucketRegion = value;
			}
		}

		internal bool IsSetContinuationToken()
		{
			return _continuationToken != null;
		}

		internal bool IsSetMaxBuckets()
		{
			return _maxBuckets.HasValue;
		}

		internal bool IsSetPrefix()
		{
			return _prefix != null;
		}

		internal bool IsSetBucketRegion()
		{
			return _bucketRegion != null;
		}
	}
}
