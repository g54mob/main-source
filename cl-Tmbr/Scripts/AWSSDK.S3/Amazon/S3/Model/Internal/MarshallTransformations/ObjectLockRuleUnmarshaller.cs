using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ObjectLockRuleUnmarshaller : IXmlUnmarshaller<ObjectLockRule, XmlUnmarshallerContext>
	{
		private static ObjectLockRuleUnmarshaller _instance;

		public static ObjectLockRuleUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ObjectLockRuleUnmarshaller();
				}
				return _instance;
			}
		}

		public ObjectLockRule Unmarshall(XmlUnmarshallerContext context)
		{
			ObjectLockRule objectLockRule = new ObjectLockRule();
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
					if (context.TestExpression("DefaultRetention", num))
					{
						DefaultRetentionUnmarshaller instance = DefaultRetentionUnmarshaller.Instance;
						objectLockRule.DefaultRetention = instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return objectLockRule;
				}
			}
			return objectLockRule;
		}
	}
}
