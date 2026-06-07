using System;

namespace LitJson
{
	public class JsonException : Exception
	{
		public JsonException()
		{
		}

		internal JsonException(ParserToken token)
		{
		}

		internal JsonException(ParserToken token, Exception inner)
		{
		}

		internal JsonException(int c)
		{
		}

		internal JsonException(int c, Exception inner)
		{
		}

		public JsonException(string message)
		{
		}

		public JsonException(string message, Exception inner)
		{
		}
	}
}
