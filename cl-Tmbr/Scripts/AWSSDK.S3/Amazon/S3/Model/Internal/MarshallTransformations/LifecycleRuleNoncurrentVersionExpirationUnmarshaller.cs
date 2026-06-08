using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class LifecycleRuleNoncurrentVersionExpirationUnmarshaller : IXmlUnmarshaller<LifecycleRuleNoncurrentVersionExpiration, XmlUnmarshallerContext>
	{
		private static LifecycleRuleNoncurrentVersionExpirationUnmarshaller _instance;

		public static LifecycleRuleNoncurrentVersionExpirationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new LifecycleRuleNoncurrentVersionExpirationUnmarshaller();
				}
				return _instance;
			}
		}

		public LifecycleRuleNoncurrentVersionExpiration Unmarshall(XmlUnmarshallerContext context)
		{
			LifecycleRuleNoncurrentVersionExpiration lifecycleRuleNoncurrentVersionExpiration = new LifecycleRuleNoncurrentVersionExpiration();
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
					if (context.TestExpression("NewerNoncurrentVersions", num))
					{
						lifecycleRuleNoncurrentVersionExpiration.NewerNoncurrentVersions = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("NoncurrentDays", num))
					{
						lifecycleRuleNoncurrentVersionExpiration.NoncurrentDays = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return lifecycleRuleNoncurrentVersionExpiration;
				}
			}
			return lifecycleRuleNoncurrentVersionExpiration;
		}
	}
}
