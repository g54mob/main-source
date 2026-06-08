using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectLockConfigurationRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private string expectedBucketOwner;

		public string BucketName
		{
			get
			{
				return _bucketName;
			}
			set
			{
				_bucketName = value;
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
			return !string.IsNullOrEmpty(_bucketName);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
