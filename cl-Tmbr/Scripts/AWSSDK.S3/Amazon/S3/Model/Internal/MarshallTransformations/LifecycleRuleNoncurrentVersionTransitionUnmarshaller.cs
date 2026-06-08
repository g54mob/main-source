using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class LifecycleRuleNoncurrentVersionTransitionUnmarshaller : IXmlUnmarshaller<LifecycleRuleNoncurrentVersionTransition, XmlUnmarshallerContext>
	{
		private static LifecycleRuleNoncurrentVersionTransitionUnmarshaller _instance;

		public static LifecycleRuleNoncurrentVersionTransitionUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new LifecycleRuleNoncurrentVersionTransitionUnmarshaller();
				}
				return _instance;
			}
		}

		public LifecycleRuleNoncurrentVersionTransition Unmarshall(XmlUnmarshallerContext context)
		{
			LifecycleRuleNoncurrentVersionTransition lifecycleRuleNoncurrentVersionTransition = new LifecycleRuleNoncurrentVersionTransition();
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
						lifecycleRuleNoncurrentVersionTransition.NewerNoncurrentVersions = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("NoncurrentDays", num))
					{
						lifecycleRuleNoncurrentVersionTransition.NoncurrentDays = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("StorageClass", num))
					{
						lifecycleRuleNoncurrentVersionTransition.StorageClass = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return lifecycleRuleNoncurrentVersionTransition;
				}
			}
			return lifecycleRuleNoncurrentVersionTransition;
		}
	}
}
