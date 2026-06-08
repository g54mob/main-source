using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ReplicationRuleFilterUnmarshaller : IXmlUnmarshaller<ReplicationRuleFilter, XmlUnmarshallerContext>
	{
		private static ReplicationRuleFilterUnmarshaller _instance;

		public static ReplicationRuleFilterUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ReplicationRuleFilterUnmarshaller();
				}
				return _instance;
			}
		}

		public ReplicationRuleFilter Unmarshall(XmlUnmarshallerContext context)
		{
			ReplicationRuleFilter replicationRuleFilter = new ReplicationRuleFilter();
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
					if (context.TestExpression("Prefix", num))
					{
						replicationRuleFilter.Prefix = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Tag", num))
					{
						replicationRuleFilter.Tag = TagUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("And", num))
					{
						replicationRuleFilter.And = ReplicationRuleAndOperatorUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return replicationRuleFilter;
				}
			}
			return replicationRuleFilter;
		}
	}
}
