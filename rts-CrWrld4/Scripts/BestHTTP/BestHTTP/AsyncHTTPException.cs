using System;

namespace BestHTTP
{
	public sealed class AsyncHTTPException : Exception
	{
		public int StatusCode;

		public string Content;

		public AsyncHTTPException(string message)
		{
		}

		public AsyncHTTPException(string message, Exception innerException)
		{
		}

		public AsyncHTTPException(int statusCode, string message, string content)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
