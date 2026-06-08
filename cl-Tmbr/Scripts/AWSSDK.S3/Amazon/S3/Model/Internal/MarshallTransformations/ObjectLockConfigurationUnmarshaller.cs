using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ObjectLockConfigurationUnmarshaller : IXmlUnmarshaller<ObjectLockConfiguration, XmlUnmarshallerContext>
	{
		private static ObjectLockConfigurationUnmarshaller _instance;

		public static ObjectLockConfigurationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ObjectLockConfigurationUnmarshaller();
				}
				return _instance;
			}
		}

		public ObjectLockConfiguration Unmarshall(XmlUnmarshallerContext context)
		{
			ObjectLockConfiguration objectLockConfiguration = new ObjectLockConfiguration();
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
					if (context.TestExpression("ObjectLockEnabled", num))
					{
						StringUnmarshaller instance = StringUnmarshaller.Instance;
						objectLockConfiguration.ObjectLockEnabled = instance.Unmarshall(context);
					}
					else if (context.TestExpression("Rule", num))
					{
						ObjectLockRuleUnmarshaller instance2 = ObjectLockRuleUnmarshaller.Instance;
						objectLockConfiguration.Rule = instance2.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return objectLockConfiguration;
				}
			}
			return objectLockConfiguration;
		}
	}
}
