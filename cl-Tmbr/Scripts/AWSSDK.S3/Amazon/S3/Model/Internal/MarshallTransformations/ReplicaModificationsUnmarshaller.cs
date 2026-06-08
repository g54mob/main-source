using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ReplicaModificationsUnmarshaller : IXmlUnmarshaller<ReplicaModifications, XmlUnmarshallerContext>
	{
		private static ReplicaModificationsUnmarshaller _instance;

		public static ReplicaModificationsUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ReplicaModificationsUnmarshaller();
				}
				return _instance;
			}
		}

		public ReplicaModifications Unmarshall(XmlUnmarshallerContext context)
		{
			ReplicaModifications replicaModifications = new ReplicaModifications();
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
						replicaModifications.Status = StringUnmarshaller.Instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return replicaModifications;
				}
			}
			return replicaModifications;
		}
	}
}
