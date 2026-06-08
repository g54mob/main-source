using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectLegalHoldResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetObjectLegalHoldResponseUnmarshaller _instance;

		public static GetObjectLegalHoldResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectLegalHoldResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetObjectLegalHoldResponse getObjectLegalHoldResponse = new GetObjectLegalHoldResponse();
			UnmarshallResult(context, getObjectLegalHoldResponse);
			return getObjectLegalHoldResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetObjectLegalHoldResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("LegalHold", startingStackDepth))
					{
						ObjectLockLegalHoldUnmarshaller instance = ObjectLockLegalHoldUnmarshaller.Instance;
						response.LegalHold = instance.Unmarshall(context);
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
