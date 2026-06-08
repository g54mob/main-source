using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketAnalyticsConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string analyticsId;

		private AnalyticsConfiguration analyticsConfiguration;

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

		public AnalyticsConfiguration AnalyticsConfiguration
		{
			get
			{
				return analyticsConfiguration;
			}
			set
			{
				analyticsConfiguration = value;
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

		internal bool IsSetBucket()
		{
			return !string.IsNullOrEmpty(bucketName);
		}

		internal bool IsSetAnalyticsId()
		{
			return !string.IsNullOrEmpty(analyticsId);
		}

		internal bool IsSetAnalyticsConfiguration()
		{
			return analyticsConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
