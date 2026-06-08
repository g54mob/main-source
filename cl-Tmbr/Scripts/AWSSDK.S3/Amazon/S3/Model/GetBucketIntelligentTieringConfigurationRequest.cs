using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketIntelligentTieringConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string intelligentTieringId;

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

		public string IntelligentTieringId
		{
			get
			{
				return intelligentTieringId;
			}
			set
			{
				intelligentTieringId = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return BucketName != null;
		}

		internal bool IsSetIntelligentTieringId()
		{
			return !string.IsNullOrEmpty(intelligentTieringId);
		}
	}
}
