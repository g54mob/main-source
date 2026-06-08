using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ReplicationTimeUnmarshaller : IXmlUnmarshaller<ReplicationTime, XmlUnmarshallerContext>
	{
		private static ReplicationTimeUnmarshaller _instance;

		public static ReplicationTimeUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ReplicationTimeUnmarshaller();
				}
				return _instance;
			}
		}

		public ReplicationTime Unmarshall(XmlUnmarshallerContext context)
		{
			ReplicationTime replicationTime = new ReplicationTime();
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
					if (context.TestExpression("Status", num))
					{
						replicationTime.Status = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("EventThreshold", num))
					{
						replicationTime.Time = ReplicationTimeValueUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return replicationTime;
				}
			}
			return replicationTime;
		}
	}
}
