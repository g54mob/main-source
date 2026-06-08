using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketIntelligentTieringConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutBucketIntelligentTieringConfigurationResponseUnmarshaller _instance;

		public static PutBucketIntelligentTieringConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketIntelligentTieringConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new PutBucketIntelligentTieringConfigurationResponse();
		}
	}
}
