using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetACLRequest : AmazonWebServiceRequest
	{
		private string expectedBucketOwner;

		public string BucketName { get; set; }

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		public string Key { get; set; }

		public string VersionId { get; set; }

		internal bool IsSetBucket()
		{
			return BucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return Key != null;
		}

		internal bool IsSetVersionId()
		{
			return VersionId != null;
		}
	}
}
