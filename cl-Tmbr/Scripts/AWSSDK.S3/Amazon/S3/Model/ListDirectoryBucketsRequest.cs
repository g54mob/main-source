using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class ListDirectoryBucketsRequest : AmazonWebServiceRequest
	{
		private string _continuationToken;

		private int? _maxDirectoryBuckets;

		[AWSProperty(Min = 0L, Max = 1024L)]
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

		[AWSProperty(Min = 0L, Max = 1000L)]
		public int? MaxDirectoryBuckets
		{
			get
			{
				return _maxDirectoryBuckets;
			}
			set
			{
				_maxDirectoryBuckets = value;
			}
		}

		internal bool IsSetContinuationToken()
		{
			return _continuationToken != null;
		}

		internal bool IsSetMaxDirectoryBuckets()
		{
			return _maxDirectoryBuckets.HasValue;
		}
	}
}
