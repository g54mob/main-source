using System;
using System.Xml;

namespace Amazon.Runtime.Internal.Transform
{
	public class XmlErrorResponseUnmarshaller : IXmlUnmarshaller<ErrorResponse, XmlUnmarshallerContext>
	{
		private static XmlErrorResponseUnmarshaller instance;

		public ErrorResponse Unmarshall(XmlUnmarshallerContext context)
		{
			ErrorResponse errorResponse = new ErrorResponse
			{
				Type = ErrorType.Unknown
			};
			PopulateErrorResponseFromXmlIfPossible(context, errorResponse);
			if (string.IsNullOrEmpty(errorResponse.Message))
			{
				if (string.IsNullOrEmpty(errorResponse.Code))
				{
					if (string.IsNullOrEmpty(context.ResponseBody))
					{
						errorResponse.Message = "The service returned an error. See inner exception for details.";
					}
					else
					{
						errorResponse.Message = "The service returned an error with HTTP Body: " + context.ResponseBody;
					}
				}
				else
				{
					errorResponse.Message = "The service returned an error with Error Code " + errorResponse.Code + " and HTTP Body: " + context.ResponseBody;
				}
			}
			return errorResponse;
		}

		private static void PopulateErrorResponseFromXmlIfPossible(XmlUnmarshallerContext context, ErrorResponse response)
		{
			while (TryReadContext(context))
			{
				if (!context.IsStartElement)
				{
					continue;
				}
				if (context.TestExpression("Error/Type"))
				{
					try
					{
						response.Type = (ErrorType)Enum.Parse(typeof(ErrorType), StringUnmarshaller.GetInstance().Unmarshall(context), ignoreCase: true);
					}
					catch (ArgumentException)
					{
						response.Type = ErrorType.Unknown;
					}
				}
				else if (context.TestExpression("Error/Code"))
				{
					response.Code = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
				else if (context.TestExpression("Error/Message"))
				{
					response.Message = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
				else if (context.TestExpression("RequestId"))
				{
					response.RequestId = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
			}
		}

		private static bool TryReadContext(XmlUnmarshallerContext context)
		{
			try
			{
				return context.Read();
			}
			catch (XmlException)
			{
				return false;
			}
		}

		public static XmlErrorResponseUnmarshaller GetInstance()
		{
			if (instance == null)
			{
				instance = new XmlErrorResponseUnmarshaller();
			}
			return instance;
		}
	}
}
