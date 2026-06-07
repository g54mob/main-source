using System;
using System.Net;
using Coherence.Log;

namespace Coherence.Runtime
{
	public class RequestException : Exception
	{
		private readonly bool isGenericError;

		public HttpStatusCode HttpStatusCode { get; }

		public int StatusCode => 0;

		public ErrorCode ErrorCode { get; }

		public string UserMessage { get; }

		public override string Message => null;

		public RequestException(HttpStatusCode statusCode, string userMessage)
		{
		}

		public RequestException(ErrorCode errorCode, HttpStatusCode statusCode = (HttpStatusCode)0, string userMessage = null)
		{
		}

		public RequestException(int statusCode, string userMessage)
		{
		}

		public RequestException(ErrorCode errorCode, int statusCode, string userMessage = null)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private static string GetSchemaNotFoundMessage()
		{
			return null;
		}

		public static bool TryParse(string response, int statusCode, out RequestException requestException, Logger logger)
		{
			requestException = null;
			return false;
		}
	}
}
