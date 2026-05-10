using System;

namespace Yarn.Markup
{
	[Serializable]
	public class MarkupParseException : Exception
	{
		internal MarkupParseException()
		{
		}

		internal MarkupParseException(string message)
		{
		}

		internal MarkupParseException(string message, Exception inner)
		{
		}
	}
}
