using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketAclRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private string _expectedBucketOwner;

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
				return _expectedBucketOwner;
			}
			set
			{
				_expectedBucketOwner = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return _bucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(_expectedBucketOwner);
		}
	}
}
