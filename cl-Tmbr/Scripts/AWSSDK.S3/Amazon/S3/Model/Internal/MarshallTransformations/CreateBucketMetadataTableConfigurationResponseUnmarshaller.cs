using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CreateBucketMetadataTableConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static CreateBucketMetadataTableConfigurationResponseUnmarshaller _instance;

		public static CreateBucketMetadataTableConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CreateBucketMetadataTableConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new CreateBucketMetadataTableConfigurationResponse();
		}
	}
}
