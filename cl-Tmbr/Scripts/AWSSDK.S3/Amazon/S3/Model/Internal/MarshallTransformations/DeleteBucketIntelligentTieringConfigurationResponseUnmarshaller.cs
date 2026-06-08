using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketIntelligentTieringConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static DeleteBucketIntelligentTieringConfigurationResponseUnmarshaller _instance;

		public static DeleteBucketIntelligentTieringConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketIntelligentTieringConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new DeleteBucketIntelligentTieringConfigurationResponse();
		}
	}
}
