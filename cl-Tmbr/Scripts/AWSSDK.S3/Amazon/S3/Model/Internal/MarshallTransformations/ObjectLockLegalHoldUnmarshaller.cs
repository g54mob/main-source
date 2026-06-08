using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ObjectLockLegalHoldUnmarshaller : IXmlUnmarshaller<ObjectLockLegalHold, XmlUnmarshallerContext>
	{
		private static ObjectLockLegalHoldUnmarshaller _instance;

		public static ObjectLockLegalHoldUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ObjectLockLegalHoldUnmarshaller();
				}
				return _instance;
			}
		}

		public ObjectLockLegalHold Unmarshall(XmlUnmarshallerContext context)
		{
			ObjectLockLegalHold objectLockLegalHold = new ObjectLockLegalHold();
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
						StringUnmarshaller instance = StringUnmarshaller.Instance;
						objectLockLegalHold.Status = instance.Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return objectLockLegalHold;
				}
			}
			return objectLockLegalHold;
		}
	}
}
