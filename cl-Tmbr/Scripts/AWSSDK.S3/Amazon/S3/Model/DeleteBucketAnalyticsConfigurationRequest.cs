using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class DeleteBucketAnalyticsConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string analyticsId;

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

		public string AnalyticsId
		{
			get
			{
				return analyticsId;
			}
			set
			{
				analyticsId = value;
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

		internal bool IsSetAnalyticsId()
		{
			return !string.IsNullOrEmpty(analyticsId);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
