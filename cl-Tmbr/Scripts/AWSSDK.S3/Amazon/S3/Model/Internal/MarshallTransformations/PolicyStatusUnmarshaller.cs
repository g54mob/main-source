using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PolicyStatusUnmarshaller : IXmlUnmarshaller<PolicyStatus, XmlUnmarshallerContext>
	{
		private static PolicyStatusUnmarshaller _instance;

		public static PolicyStatusUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PolicyStatusUnmarshaller();
				}
				return _instance;
			}
		}

		public PolicyStatus Unmarshall(XmlUnmarshallerContext context)
		{
			PolicyStatus policyStatus = new PolicyStatus();
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
					if (context.TestExpression("IsPublic", num))
					{
						policyStatus.IsPublic = BoolUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return policyStatus;
				}
			}
			return policyStatus;
		}
	}
}
