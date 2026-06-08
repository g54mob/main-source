using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListBucketsResponse : AmazonWebServiceResponse
	{
		private List<S3Bucket> buckets = (AWSConfigs.InitializeCollections ? new List<S3Bucket>() : null);

		private Owner owner;

		private string continuationToken;

		private string _prefix;

		public List<S3Bucket> Buckets
		{
			get
			{
				return buckets;
			}
			set
			{
				buckets = value;
			}
		}

		public Owner Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		public string ContinuationToken
		{
			get
			{
				return continuationToken;
			}
			set
			{
				continuationToken = value;
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

		internal bool IsSetBuckets()
		{
			if (buckets != null)
			{
				if (buckets.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetOwner()
		{
			return owner != null;
		}

		internal bool IsSetContinuationToken()
		{
			return continuationToken != null;
		}

		internal bool IsSetPrefix()
		{
			return _prefix != null;
		}
	}
}
