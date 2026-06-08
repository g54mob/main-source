using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ObjectLockRetentionUnmarshaller : IXmlUnmarshaller<ObjectLockRetention, XmlUnmarshallerContext>
	{
		private static ObjectLockRetentionUnmarshaller _instance;

		public static ObjectLockRetentionUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ObjectLockRetentionUnmarshaller();
				}
				return _instance;
			}
		}

		public ObjectLockRetention Unmarshall(XmlUnmarshallerContext context)
		{
			ObjectLockRetention objectLockRetention = new ObjectLockRetention();
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
					if (context.TestExpression("Mode", num))
					{
						StringUnmarshaller instance = StringUnmarshaller.Instance;
						objectLockRetention.Mode = instance.Unmarshall(context);
					}
					else if (context.TestExpression("RetainUntilDate", num))
					{
						DateTimeUnmarshaller instance2 = DateTimeUnmarshaller.Instance;
						objectLockRetention.RetainUntilDate = instance2.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return objectLockRetention;
				}
			}
			return objectLockRetention;
		}
	}
}
