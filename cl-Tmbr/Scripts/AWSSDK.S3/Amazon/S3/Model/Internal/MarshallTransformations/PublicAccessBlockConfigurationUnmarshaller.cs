using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PublicAccessBlockConfigurationUnmarshaller : IXmlUnmarshaller<PublicAccessBlockConfiguration, XmlUnmarshallerContext>
	{
		private static PublicAccessBlockConfigurationUnmarshaller _instance;

		public static PublicAccessBlockConfigurationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PublicAccessBlockConfigurationUnmarshaller();
				}
				return _instance;
			}
		}

		public PublicAccessBlockConfiguration Unmarshall(XmlUnmarshallerContext context)
		{
			PublicAccessBlockConfiguration publicAccessBlockConfiguration = new PublicAccessBlockConfiguration();
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
					if (context.TestExpression("BlockPublicAcls", num))
					{
						publicAccessBlockConfiguration.BlockPublicAcls = BoolUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("IgnorePublicAcls", num))
					{
						publicAccessBlockConfiguration.IgnorePublicAcls = BoolUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("BlockPublicPolicy", num))
					{
						publicAccessBlockConfiguration.BlockPublicPolicy = BoolUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("RestrictPublicBuckets", num))
					{
						publicAccessBlockConfiguration.RestrictPublicBuckets = BoolUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return publicAccessBlockConfiguration;
				}
			}
			return publicAccessBlockConfiguration;
		}
	}
}
