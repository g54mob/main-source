using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class WriteGetObjectResponseResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static WriteGetObjectResponseResponseUnmarshaller _instance;

		public static WriteGetObjectResponseResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new WriteGetObjectResponseResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			return new WriteGetObjectResponseResponse();
		}
	}
}
