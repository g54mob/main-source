using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ReplicationTimeValueUnmarshaller : IXmlUnmarshaller<ReplicationTimeValue, XmlUnmarshallerContext>
	{
		private static ReplicationTimeValueUnmarshaller _instance;

		public static ReplicationTimeValueUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ReplicationTimeValueUnmarshaller();
				}
				return _instance;
			}
		}

		public ReplicationTimeValue Unmarshall(XmlUnmarshallerContext context)
		{
			ReplicationTimeValue replicationTimeValue = new ReplicationTimeValue();
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
					if (context.TestExpression("EventThreshold", num))
					{
						replicationTimeValue.Minutes = IntUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return replicationTimeValue;
				}
			}
			return replicationTimeValue;
		}
	}
}
