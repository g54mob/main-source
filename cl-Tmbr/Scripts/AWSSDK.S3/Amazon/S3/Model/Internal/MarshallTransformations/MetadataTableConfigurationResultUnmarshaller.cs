using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class MetadataTableConfigurationResultUnmarshaller : IXmlUnmarshaller<MetadataTableConfigurationResult, XmlUnmarshallerContext>
	{
		private static MetadataTableConfigurationResultUnmarshaller _instance;

		public static MetadataTableConfigurationResultUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new MetadataTableConfigurationResultUnmarshaller();
				}
				return _instance;
			}
		}

		public MetadataTableConfigurationResult Unmarshall(XmlUnmarshallerContext context)
		{
			MetadataTableConfigurationResult metadataTableConfigurationResult = new MetadataTableConfigurationResult();
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
					if (context.TestExpression("S3TablesDestinationResult", num))
					{
						metadataTableConfigurationResult.S3TablesDestinationResult = S3TablesDestinationResultUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return metadataTableConfigurationResult;
				}
			}
			return metadataTableConfigurationResult;
		}
	}
}
