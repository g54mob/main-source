using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class MetricsUnmarshaller : IXmlUnmarshaller<Metrics, XmlUnmarshallerContext>
	{
		private static MetricsUnmarshaller _instance;

		public static MetricsUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MetricsUnmarshaller();
				}
				return _instance;
			}
		}

		public Metrics Unmarshall(XmlUnmarshallerContext context)
		{
			Metrics metrics = new Metrics();
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
						metrics.Status = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("EventThreshold", num))
					{
						metrics.EventThreshold = ReplicationTimeValueUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return metrics;
				}
			}
			return metrics;
		}
	}
}
