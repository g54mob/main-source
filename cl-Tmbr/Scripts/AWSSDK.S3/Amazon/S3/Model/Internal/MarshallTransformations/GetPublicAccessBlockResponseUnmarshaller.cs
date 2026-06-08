using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetPublicAccessBlockResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetPublicAccessBlockResponseUnmarshaller _instance;

		public static GetPublicAccessBlockResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetPublicAccessBlockResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetPublicAccessBlockResponse getPublicAccessBlockResponse = new GetPublicAccessBlockResponse();
			UnmarshallResult(context, getPublicAccessBlockResponse);
			return getPublicAccessBlockResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetPublicAccessBlockResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("PublicAccessBlockConfiguration", startingStackDepth))
					{
						response.PublicAccessBlockConfiguration = PublicAccessBlockConfigurationUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					break;
				}
			}
		}
	}
}
