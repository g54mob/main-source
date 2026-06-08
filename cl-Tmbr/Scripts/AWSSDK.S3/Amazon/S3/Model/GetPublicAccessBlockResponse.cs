using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetPublicAccessBlockResponse : AmazonWebServiceResponse
	{
		private PublicAccessBlockConfiguration publicAccessBlockConfiguration;

		public PublicAccessBlockConfiguration PublicAccessBlockConfiguration
		{
			get
			{
				return publicAccessBlockConfiguration;
			}
			set
			{
				publicAccessBlockConfiguration = value;
			}
		}

		internal bool IsSetPublicAccessBlockConfiguration()
		{
			return publicAccessBlockConfiguration != null;
		}
	}
}
