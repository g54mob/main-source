using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class EventBridgeConfigurationUnmarshaller : IXmlUnmarshaller<EventBridgeConfiguration, XmlUnmarshallerContext>
	{
		private static EventBridgeConfigurationUnmarshaller _instance = new EventBridgeConfigurationUnmarshaller();

		public static EventBridgeConfigurationUnmarshaller Instance => _instance;

		public EventBridgeConfiguration Unmarshall(XmlUnmarshallerContext context)
		{
			EventBridgeConfiguration result = new EventBridgeConfiguration();
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (!context.IsStartElement && !context.IsAttribute && context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return result;
				}
			}
			return result;
		}
	}
}
