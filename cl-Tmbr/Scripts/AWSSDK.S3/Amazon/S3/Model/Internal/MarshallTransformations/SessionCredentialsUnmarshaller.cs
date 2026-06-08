using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class SessionCredentialsUnmarshaller : IXmlUnmarshaller<SessionCredentials, XmlUnmarshallerContext>
	{
		private static SessionCredentialsUnmarshaller _instance = new SessionCredentialsUnmarshaller();

		public static SessionCredentialsUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SessionCredentialsUnmarshaller();
				}
				return _instance;
			}
		}

		public SessionCredentials Unmarshall(XmlUnmarshallerContext context)
		{
			SessionCredentials sessionCredentials = new SessionCredentials();
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("AccessKeyId", num))
					{
						StringUnmarshaller instance = StringUnmarshaller.Instance;
						sessionCredentials.AccessKeyId = instance.Unmarshall(context);
					}
					else if (context.TestExpression("Expiration", num))
					{
						DateTimeUnmarshaller instance2 = DateTimeUnmarshaller.Instance;
						sessionCredentials.Expiration = instance2.Unmarshall(context);
					}
					else if (context.TestExpression("SecretAccessKey", num))
					{
						StringUnmarshaller instance3 = StringUnmarshaller.Instance;
						sessionCredentials.SecretAccessKey = instance3.Unmarshall(context);
					}
					else if (context.TestExpression("SessionToken", num))
					{
						StringUnmarshaller instance4 = StringUnmarshaller.Instance;
						sessionCredentials.SessionToken = instance4.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return sessionCredentials;
				}
			}
			return sessionCredentials;
		}
	}
}
