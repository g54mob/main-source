using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ErrorUnmarshaller : IXmlUnmarshaller<ErrorDetails, XmlUnmarshallerContext>
	{
		private static ErrorUnmarshaller _instance;

		public static ErrorUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ErrorUnmarshaller();
				}
				return _instance;
			}
		}

		public ErrorDetails Unmarshall(XmlUnmarshallerContext context)
		{
			ErrorDetails errorDetails = new ErrorDetails();
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
					if (context.TestExpression("ErrorMessage", num))
					{
						errorDetails.ErrorMessage = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ErrorCode", num))
					{
						errorDetails.ErrorCode = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return errorDetails;
				}
			}
			return errorDetails;
		}
	}
}
