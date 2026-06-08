using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class SSES3Unmarshaller : IXmlUnmarshaller<SSES3, XmlUnmarshallerContext>
	{
		private static SSES3Unmarshaller _instance;

		public static SSES3Unmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SSES3Unmarshaller();
				}
				return _instance;
			}
		}

		public SSES3 Unmarshall(XmlUnmarshallerContext context)
		{
			SSES3 result = new SSES3();
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (!context.IsStartElement && !context.IsAttribute && context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return result;
				}
			}
			return result;
		}
	}
}
