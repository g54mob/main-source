using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteBucketMetadataTableConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static DeleteBucketMetadataTableConfigurationResponseUnmarshaller _instance;

		public static DeleteBucketMetadataTableConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteBucketMetadataTableConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new DeleteBucketMetadataTableConfigurationResponse();
		}
	}
}
