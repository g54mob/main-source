using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListBucketInventoryConfigurationsRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string token;

		private string expectedBucketOwner;

		public string BucketName
		{
			get
			{
				return bucketName;
			}
			set
			{
				bucketName = value;
			}
		}

		public string ContinuationToken
		{
			get
			{
				return token;
			}
			set
			{
				token = value;
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
			return !string.IsNullOrEmpty(bucketName);
		}

		internal bool IsSetContinuationToken()
		{
			return !string.IsNullOrEmpty(token);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
