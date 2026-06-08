using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketIntelligentTieringConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string intelligentTieringId;

		private IntelligentTieringConfiguration intelligentTieringConfiguration;

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

		public IntelligentTieringConfiguration IntelligentTieringConfiguration
		{
			get
			{
				return intelligentTieringConfiguration;
			}
			set
			{
				intelligentTieringConfiguration = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetIntelligentTieringId()
		{
			return intelligentTieringId != null;
		}

		internal bool IsIntelligentTieringConfiguration()
		{
			return intelligentTieringConfiguration != null;
		}
	}
}
