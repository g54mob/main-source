using System;
using System.IO;
using System.Text.Json;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class JsonErrorResponseUnmarshaller : IJsonUnmarshaller<ErrorResponse, JsonUnmarshallerContext>
	{
		private static JsonErrorResponseUnmarshaller instance;

		public ErrorResponse Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			for (int i = 0; i < context.ResponseBody.Length; i++)
			{
				if (context.ResponseBody[i] != ' ')
				{
					if (context.ResponseBody[i] != '<')
					{
						break;
					}
					XmlErrorResponseUnmarshaller xmlErrorResponseUnmarshaller = new XmlErrorResponseUnmarshaller();
					using MemoryStream responseStream = new MemoryStream(context.GetResponseBodyBytes());
					XmlUnmarshallerContext context2 = new XmlUnmarshallerContext(responseStream, maintainResponseBody: false, null);
					return xmlErrorResponseUnmarshaller.Unmarshall(context2);
				}
			}
			string requestId = null;
			GetValuesFromJsonIfPossible(context, ref reader, out var type, out var message, out var code);
			if (string.IsNullOrEmpty(type) && context.ResponseData.IsHeaderPresent("x-amzn-ErrorType"))
			{
				string headerValue = context.ResponseData.GetHeaderValue("x-amzn-ErrorType");
				if (!string.IsNullOrEmpty(headerValue))
				{
					type = ParseType(headerValue);
				}
			}
			if (context.ResponseData.IsHeaderPresent("x-amzn-error-message"))
			{
				string headerValue2 = context.ResponseData.GetHeaderValue("x-amzn-error-message");
				if (!string.IsNullOrEmpty(headerValue2))
				{
					message = headerValue2;
				}
			}
			if (string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(code))
			{
				type = code;
			}
			type = ((type == null) ? null : ParseType(type.Substring(type.LastIndexOf("#", StringComparison.Ordinal) + 1)));
			if (string.IsNullOrEmpty(message))
			{
				message = (string.IsNullOrEmpty(type) ? ((!string.IsNullOrEmpty(context.ResponseBody)) ? ("The service returned an error with HTTP Body: " + context.ResponseBody) : "The service returned an error. See inner exception for details.") : ((!string.IsNullOrEmpty(context.ResponseBody)) ? ("The service returned an error with Error Code " + type + " and HTTP Body: " + context.ResponseBody) : ("The service returned an error with Error Code " + type + ".")));
			}
			if (context.ResponseData.IsHeaderPresent("x-amzn-RequestId"))
			{
				requestId = context.ResponseData.GetHeaderValue("x-amzn-RequestId");
			}
			return new ErrorResponse
			{
				Code = type,
				Message = message,
				Type = ErrorType.Unknown,
				RequestId = requestId
			};
		}

		private static string ParseType(string type)
		{
			int num = type.IndexOf(":", StringComparison.Ordinal);
			if (num != -1)
			{
				type = type.Substring(0, num);
			}
			return type;
		}

		private static void GetValuesFromJsonIfPossible(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader, out string type, out string message, out string code)
		{
			code = null;
			type = null;
			message = null;
			while (TryReadContext(context, ref reader))
			{
				if (context.TestExpression("__type"))
				{
					type = StringUnmarshaller.GetInstance().Unmarshall(context, ref reader);
				}
				else if (context.TestExpression("message"))
				{
					message = StringUnmarshaller.GetInstance().Unmarshall(context, ref reader);
				}
				else if (context.TestExpression("code"))
				{
					code = StringUnmarshaller.GetInstance().Unmarshall(context, ref reader);
				}
			}
		}

		private static bool TryReadContext(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			try
			{
				return context.Read(ref reader);
			}
			catch (JsonException)
			{
				return false;
			}
		}

		public static JsonErrorResponseUnmarshaller GetInstance()
		{
			if (instance == null)
			{
				instance = new JsonErrorResponseUnmarshaller();
			}
			return instance;
		}
	}
}
