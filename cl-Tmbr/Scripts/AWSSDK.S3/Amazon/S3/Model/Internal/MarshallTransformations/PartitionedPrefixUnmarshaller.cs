using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PartitionedPrefixUnmarshaller : IXmlUnmarshaller<PartitionedPrefix, XmlUnmarshallerContext>
	{
		private static PartitionedPrefixUnmarshaller _instance = new PartitionedPrefixUnmarshaller();

		public static PartitionedPrefixUnmarshaller Instance => _instance;

		public PartitionedPrefix Unmarshall(XmlUnmarshallerContext context)
		{
			PartitionedPrefix partitionedPrefix = new PartitionedPrefix();
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
					if (context.TestExpression("PartitionDateSource", num))
					{
						StringUnmarshaller instance = StringUnmarshaller.Instance;
						partitionedPrefix.PartitionDateSource = instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return partitionedPrefix;
				}
			}
			return partitionedPrefix;
		}
	}
}
