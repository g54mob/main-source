using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class TieringUnmarshaller : IXmlUnmarshaller<Tiering, XmlUnmarshallerContext>
	{
		private static TieringUnmarshaller _instance;

		public static TieringUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TieringUnmarshaller();
				}
				return _instance;
			}
		}

		public Tiering Unmarshall(XmlUnmarshallerContext context)
		{
			Tiering tiering = new Tiering();
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
					if (context.TestExpression("Days", num))
					{
						tiering.Days = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("AccessTier", num))
					{
						tiering.AccessTier = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return tiering;
				}
			}
			return tiering;
		}
	}
}
