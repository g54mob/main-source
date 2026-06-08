using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class EncryptionConfigurationUnmarshaller : IXmlUnmarshaller<EncryptionConfiguration, XmlUnmarshallerContext>
	{
		private static EncryptionConfigurationUnmarshaller _instance;

		public static EncryptionConfigurationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new EncryptionConfigurationUnmarshaller();
				}
				return _instance;
			}
		}

		public EncryptionConfiguration Unmarshall(XmlUnmarshallerContext context)
		{
			EncryptionConfiguration encryptionConfiguration = new EncryptionConfiguration();
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
					if (context.TestExpression("ReplicaKmsKeyID", num))
					{
						encryptionConfiguration.ReplicaKmsKeyID = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return encryptionConfiguration;
				}
			}
			return encryptionConfiguration;
		}
	}
}
