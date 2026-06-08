using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class RestoreStatusUnmarshaller : IXmlUnmarshaller<RestoreStatus, XmlUnmarshallerContext>
	{
		private static RestoreStatusUnmarshaller _instance = new RestoreStatusUnmarshaller();

		public static RestoreStatusUnmarshaller Instance => _instance;

		public RestoreStatus Unmarshall(XmlUnmarshallerContext context)
		{
			RestoreStatus restoreStatus = new RestoreStatus();
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
					if (context.TestExpression("IsRestoreInProgress", num))
					{
						BoolUnmarshaller instance = BoolUnmarshaller.Instance;
						restoreStatus.IsRestoreInProgress = instance.Unmarshall(context);
					}
					else if (context.TestExpression("RestoreExpiryDate", num))
					{
						DateTimeUnmarshaller instance2 = DateTimeUnmarshaller.Instance;
						restoreStatus.RestoreExpiryDate = instance2.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return restoreStatus;
				}
			}
			return restoreStatus;
		}
	}
}
