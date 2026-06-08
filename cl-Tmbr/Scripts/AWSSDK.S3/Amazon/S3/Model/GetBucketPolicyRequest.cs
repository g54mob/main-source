using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketPolicyRequest : AmazonWebServiceRequest
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

		internal bool IsSetBucket()
		{
			return BucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
