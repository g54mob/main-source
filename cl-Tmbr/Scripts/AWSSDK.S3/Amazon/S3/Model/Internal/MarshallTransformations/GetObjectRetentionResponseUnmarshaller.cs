using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectRetentionResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetObjectRetentionResponseUnmarshaller _instance;

		public static GetObjectRetentionResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectRetentionResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetObjectRetentionResponse getObjectRetentionResponse = new GetObjectRetentionResponse();
			UnmarshallResult(context, getObjectRetentionResponse);
			return getObjectRetentionResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetObjectRetentionResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("Retention", startingStackDepth))
					{
						ObjectLockRetentionUnmarshaller instance = ObjectLockRetentionUnmarshaller.Instance;
						response.Retention = instance.Unmarshall(context);
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
