using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class DeleteBucketIntelligentTieringConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string intelligentTieiringId;

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
				return intelligentTieiringId;
			}
			set
			{
				intelligentTieiringId = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(bucketName);
		}

		internal bool IsSetIntelligentTieiringId()
		{
			return !string.IsNullOrEmpty(IntelligentTieringId);
		}
	}
}
