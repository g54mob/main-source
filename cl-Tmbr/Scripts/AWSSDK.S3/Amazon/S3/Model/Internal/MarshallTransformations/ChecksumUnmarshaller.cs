using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ChecksumUnmarshaller : IXmlUnmarshaller<Checksum, XmlUnmarshallerContext>
	{
		private static ChecksumUnmarshaller _instance = new ChecksumUnmarshaller();

		public static ChecksumUnmarshaller Instance => _instance;

		public Checksum Unmarshall(XmlUnmarshallerContext context)
		{
			Checksum checksum = new Checksum();
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
						checksum.ChecksumCRC32 = instance.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC32C", num))
					{
						StringUnmarshaller instance2 = StringUnmarshaller.Instance;
						checksum.ChecksumCRC32C = instance2.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumSHA1", num))
					{
						StringUnmarshaller instance3 = StringUnmarshaller.Instance;
						checksum.ChecksumSHA1 = instance3.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumSHA256", num))
					{
						StringUnmarshaller instance4 = StringUnmarshaller.Instance;
						checksum.ChecksumSHA256 = instance4.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumCRC64NVME", num))
					{
						StringUnmarshaller instance5 = StringUnmarshaller.Instance;
						checksum.ChecksumCRC64NVME = instance5.Unmarshall(context);
					}
					else if (context.TestExpression("ChecksumType", num))
					{
						StringUnmarshaller instance6 = StringUnmarshaller.Instance;
						checksum.ChecksumType = instance6.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return checksum;
				}
			}
			return checksum;
		}
	}
}
