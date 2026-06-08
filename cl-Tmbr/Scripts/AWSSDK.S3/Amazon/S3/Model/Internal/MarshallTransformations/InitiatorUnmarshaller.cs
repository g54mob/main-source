using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class InitiatorUnmarshaller : IXmlUnmarshaller<Initiator, XmlUnmarshallerContext>
	{
		private static InitiatorUnmarshaller _instance;

		public static InitiatorUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new InitiatorUnmarshaller();
				}
				return _instance;
			}
		}

		public Initiator Unmarshall(XmlUnmarshallerContext context)
		{
			Initiator initiator = new Initiator();
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
					if (context.TestExpression("DisplayName", num))
					{
						initiator.DisplayName = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ID", num))
					{
						initiator.Id = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return initiator;
				}
			}
			return initiator;
		}
	}
}
