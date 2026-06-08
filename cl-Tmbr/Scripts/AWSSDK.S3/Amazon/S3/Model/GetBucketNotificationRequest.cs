using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketNotificationRequest : AmazonWebServiceRequest
	{
		private string bucket;

		private string expectedBucketOwner;

		public string BucketName
		{
			get
			{
				return bucket;
			}
			set
			{
				bucket = value;
			}
		}

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

		internal bool IsSetBucketName()
		{
			return bucket != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
