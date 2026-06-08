using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DefaultRetentionUnmarshaller : IXmlUnmarshaller<DefaultRetention, XmlUnmarshallerContext>
	{
		private static DefaultRetentionUnmarshaller _instance;

		public static DefaultRetentionUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DefaultRetentionUnmarshaller();
				}
				return _instance;
			}
		}

		public DefaultRetention Unmarshall(XmlUnmarshallerContext context)
		{
			DefaultRetention defaultRetention = new DefaultRetention();
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
					if (context.TestExpression("Days", num))
					{
						IntUnmarshaller instance = IntUnmarshaller.Instance;
						defaultRetention.Days = instance.Unmarshall(context);
					}
					else if (context.TestExpression("Mode", num))
					{
						StringUnmarshaller instance2 = StringUnmarshaller.Instance;
						defaultRetention.Mode = instance2.Unmarshall(context);
					}
					else if (context.TestExpression("Years", num))
					{
						IntUnmarshaller instance3 = IntUnmarshaller.Instance;
						defaultRetention.Years = instance3.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return defaultRetention;
				}
			}
			return defaultRetention;
		}
	}
}
