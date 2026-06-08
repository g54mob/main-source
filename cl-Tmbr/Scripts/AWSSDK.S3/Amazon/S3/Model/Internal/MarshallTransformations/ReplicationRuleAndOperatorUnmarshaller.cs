using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ReplicationRuleAndOperatorUnmarshaller : IXmlUnmarshaller<ReplicationRuleAndOperator, XmlUnmarshallerContext>
	{
		private static ReplicationRuleAndOperatorUnmarshaller _instance;

		public static ReplicationRuleAndOperatorUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ReplicationRuleAndOperatorUnmarshaller();
				}
				return _instance;
			}
		}

		public ReplicationRuleAndOperator Unmarshall(XmlUnmarshallerContext context)
		{
			ReplicationRuleAndOperator replicationRuleAndOperator = new ReplicationRuleAndOperator();
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
						replicationRuleAndOperator.Prefix = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Tag", num))
					{
						if (replicationRuleAndOperator.Tags == null)
						{
							replicationRuleAndOperator.Tags = new List<Tag>();
						}
						replicationRuleAndOperator.Tags.Add(TagUnmarshaller.Instance.Unmarshall(context));
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return replicationRuleAndOperator;
				}
			}
			return replicationRuleAndOperator;
		}
	}
}
