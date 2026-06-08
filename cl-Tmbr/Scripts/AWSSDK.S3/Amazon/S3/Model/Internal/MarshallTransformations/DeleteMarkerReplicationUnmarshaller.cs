using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class DeleteMarkerReplicationUnmarshaller : IXmlUnmarshaller<DeleteMarkerReplication, XmlUnmarshallerContext>
	{
		private static DeleteMarkerReplicationUnmarshaller _instance;

		public static DeleteMarkerReplicationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteMarkerReplicationUnmarshaller();
				}
				return _instance;
			}
		}

		public DeleteMarkerReplication Unmarshall(XmlUnmarshallerContext context)
		{
			DeleteMarkerReplication deleteMarkerReplication = new DeleteMarkerReplication();
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
					if (context.TestExpression("Status", num))
					{
						deleteMarkerReplication.Status = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return deleteMarkerReplication;
				}
			}
			return deleteMarkerReplication;
		}
	}
}
