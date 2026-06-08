using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class OwnershipControlsRuleUnmarshaller : IXmlUnmarshaller<OwnershipControlsRule, XmlUnmarshallerContext>
	{
		private static OwnershipControlsRuleUnmarshaller _instance;

		public static OwnershipControlsRuleUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new OwnershipControlsRuleUnmarshaller();
				}
				return _instance;
			}
		}

		public OwnershipControlsRule Unmarshall(XmlUnmarshallerContext context)
		{
			OwnershipControlsRule ownershipControlsRule = new OwnershipControlsRule();
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
					if (context.TestExpression("ObjectOwnership", num))
					{
						ownershipControlsRule.ObjectOwnership = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return ownershipControlsRule;
				}
			}
			return ownershipControlsRule;
		}
	}
}
