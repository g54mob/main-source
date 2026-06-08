using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketMetricsConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string metricsId;

		private MetricsConfiguration metricsConfiguration;

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

		public string MetricsId
		{
			get
			{
				return metricsId;
			}
			set
			{
				metricsId = value;
			}
		}

		public MetricsConfiguration MetricsConfiguration
		{
			get
			{
				return metricsConfiguration;
			}
			set
			{
				metricsConfiguration = value;
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
			return bucketName != null;
		}

		internal bool IsSetMetricsId()
		{
			return metricsId != null;
		}

		internal bool IsSetMetricsConfiguration()
		{
			return metricsConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
