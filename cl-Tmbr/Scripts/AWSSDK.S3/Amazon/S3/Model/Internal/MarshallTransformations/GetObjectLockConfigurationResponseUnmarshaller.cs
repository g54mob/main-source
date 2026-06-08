using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectLockConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetObjectLockConfigurationResponseUnmarshaller _instance;

		public static GetObjectLockConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectLockConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetObjectLockConfigurationResponse getObjectLockConfigurationResponse = new GetObjectLockConfigurationResponse();
			UnmarshallResult(context, getObjectLockConfigurationResponse);
			return getObjectLockConfigurationResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetObjectLockConfigurationResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("ObjectLockConfiguration", startingStackDepth))
					{
						ObjectLockConfigurationUnmarshaller instance = ObjectLockConfigurationUnmarshaller.Instance;
						response.ObjectLockConfiguration = instance.Unmarshall(context);
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
