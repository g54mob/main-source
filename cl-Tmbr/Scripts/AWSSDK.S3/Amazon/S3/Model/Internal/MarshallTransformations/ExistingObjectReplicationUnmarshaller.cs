using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ExistingObjectReplicationUnmarshaller : IXmlUnmarshaller<ExistingObjectReplication, XmlUnmarshallerContext>
	{
		private static ExistingObjectReplicationUnmarshaller _instance;

		public static ExistingObjectReplicationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ExistingObjectReplicationUnmarshaller();
				}
				return _instance;
			}
		}

		public ExistingObjectReplication Unmarshall(XmlUnmarshallerContext context)
		{
			ExistingObjectReplication existingObjectReplication = new ExistingObjectReplication();
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
					if (context.TestExpression("ExistingObjectReplicationStatus", num))
					{
						existingObjectReplication.Status = StringUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return existingObjectReplication;
				}
			}
			return existingObjectReplication;
		}
	}
}
