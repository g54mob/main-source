using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeletePublicAccessBlockResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static DeletePublicAccessBlockResponseUnmarshaller _instance;

		public static DeletePublicAccessBlockResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeletePublicAccessBlockResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new DeletePublicAccessBlockResponse();
		}
	}
}
