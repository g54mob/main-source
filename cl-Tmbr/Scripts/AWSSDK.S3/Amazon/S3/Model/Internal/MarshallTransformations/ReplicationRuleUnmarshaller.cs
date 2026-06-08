using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ReplicationRuleUnmarshaller : IXmlUnmarshaller<ReplicationRule, XmlUnmarshallerContext>
	{
		private static ReplicationRuleUnmarshaller _instance;

		public static ReplicationRuleUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ReplicationRuleUnmarshaller();
				}
				return _instance;
			}
		}

		public ReplicationRule Unmarshall(XmlUnmarshallerContext context)
		{
			ReplicationRule replicationRule = new ReplicationRule();
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
					if (context.TestExpression("ID", num))
					{
						replicationRule.Id = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Priority", num))
					{
						replicationRule.Priority = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Filter", num))
					{
						replicationRule.Filter = ReplicationRuleFilterUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("Status", num))
					{
						replicationRule.Status = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Destination", num))
					{
						replicationRule.Destination = ReplicationDestinationUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("SourceSelectionCriteria", num))
					{
						replicationRule.SourceSelectionCriteria = SourceSelectionCriteriaUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("ExistingObjectReplication", num))
					{
						replicationRule.ExistingObjectReplication = ExistingObjectReplicationUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("DeleteMarkerReplication", num))
					{
						replicationRule.DeleteMarkerReplication = DeleteMarkerReplicationUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return replicationRule;
				}
			}
			return replicationRule;
		}
	}
}
