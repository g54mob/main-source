using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class SimplePrefixUnmarshaller : IXmlUnmarshaller<SimplePrefix, XmlUnmarshallerContext>
	{
		private static SimplePrefixUnmarshaller _instance = new SimplePrefixUnmarshaller();

		public static SimplePrefixUnmarshaller Instance => _instance;

		public SimplePrefix Unmarshall(XmlUnmarshallerContext context)
		{
			SimplePrefix result = new SimplePrefix();
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
