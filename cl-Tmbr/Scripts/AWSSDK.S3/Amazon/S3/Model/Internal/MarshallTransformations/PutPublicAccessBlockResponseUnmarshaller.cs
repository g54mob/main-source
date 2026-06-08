using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutPublicAccessBlockResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static PutPublicAccessBlockResponseUnmarshaller _instance;

		public static PutPublicAccessBlockResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutPublicAccessBlockResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new PutPublicAccessBlockResponse();
		}
	}
}
