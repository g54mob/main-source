using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class ListDirectoryBucketsResponse : AmazonWebServiceResponse
	{
		private List<S3Bucket> _buckets = (AWSConfigs.InitializeCollections ? new List<S3Bucket>() : null);

		private string _continuationToken;

		public List<S3Bucket> Buckets
		{
			get
			{
				return _buckets;
			}
			set
			{
				_buckets = value;
			}
		}

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

		internal bool IsSetBuckets()
		{
			if (_buckets != null)
			{
				if (_buckets.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetContinuationToken()
		{
			return _continuationToken != null;
		}
	}
}
