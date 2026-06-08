using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketIntelligentTieringConfigurationResponse : AmazonWebServiceResponse
	{
		private IntelligentTieringConfiguration intelligentTieringConfiguration;

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

		internal bool IsSetIntelligentTieringConfiguration()
		{
			return intelligentTieringConfiguration != null;
		}
	}
}
