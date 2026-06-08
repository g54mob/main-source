using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class TargetObjectKeyFormatUnmarshaller : IXmlUnmarshaller<TargetObjectKeyFormat, XmlUnmarshallerContext>
	{
		private static TargetObjectKeyFormatUnmarshaller _instance = new TargetObjectKeyFormatUnmarshaller();

		public static TargetObjectKeyFormatUnmarshaller Instance => _instance;

		public TargetObjectKeyFormat Unmarshall(XmlUnmarshallerContext context)
		{
			TargetObjectKeyFormat targetObjectKeyFormat = new TargetObjectKeyFormat();
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
					if (context.TestExpression("PartitionedPrefix", num))
					{
						PartitionedPrefixUnmarshaller instance = PartitionedPrefixUnmarshaller.Instance;
						targetObjectKeyFormat.PartitionedPrefix = instance.Unmarshall(context);
					}
					else if (context.TestExpression("SimplePrefix", num))
					{
						SimplePrefixUnmarshaller instance2 = SimplePrefixUnmarshaller.Instance;
						targetObjectKeyFormat.SimplePrefix = instance2.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return targetObjectKeyFormat;
				}
			}
			return targetObjectKeyFormat;
		}
	}
}
