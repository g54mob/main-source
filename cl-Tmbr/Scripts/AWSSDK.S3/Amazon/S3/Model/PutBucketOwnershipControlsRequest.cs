using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketOwnershipControlsRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string expectedBucketOwner;

		private OwnershipControls ownershipControls;

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

		public OwnershipControls OwnershipControls
		{
			get
			{
				return ownershipControls;
			}
			set
			{
				ownershipControls = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return BucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
