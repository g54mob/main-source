using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ObjectPartUnmarshaller : IXmlUnmarshaller<ObjectPart, XmlUnmarshallerContext>
	{
		private static ObjectPartUnmarshaller _instance = new ObjectPartUnmarshaller();

		public static ObjectPartUnmarshaller Instance => _instance;

		public ObjectPart Unmarshall(XmlUnmarshallerContext context)
		{
			ObjectPart objectPart = new ObjectPart();
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
					if (context.TestExpression("ChecksumCRC32", num))
					{
						StringUnmarshaller instance = StringUnmarshaller.Instance;
						objectPart.ChecksumCRC32 = instance.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC32C", num))
					{
						StringUnmarshaller instance2 = StringUnmarshaller.Instance;
						objectPart.ChecksumCRC32C = instance2.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC64NVME", num))
					{
						StringUnmarshaller instance3 = StringUnmarshaller.Instance;
						objectPart.ChecksumCRC64NVME = instance3.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumSHA1", num))
					{
						StringUnmarshaller instance4 = StringUnmarshaller.Instance;
						objectPart.ChecksumSHA1 = instance4.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumSHA256", num))
					{
						StringUnmarshaller instance5 = StringUnmarshaller.Instance;
						objectPart.ChecksumSHA256 = instance5.Unmarshall(context);
					}
					else if (context.TestExpression("PartNumber", num))
					{
						IntUnmarshaller instance6 = IntUnmarshaller.Instance;
						objectPart.PartNumber = instance6.Unmarshall(context);
					}
					else if (context.TestExpression("Size", num))
					{
						LongUnmarshaller instance7 = LongUnmarshaller.Instance;
						objectPart.Size = instance7.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return objectPart;
				}
			}
			return objectPart;
		}
	}
}
