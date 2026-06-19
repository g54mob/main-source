using System;

namespace SharpConfig
{
	[Serializable]
	public sealed class ParserException : Exception
	{
		internal ParserException(string message, int line)
			: base($"Line {line}: {message}")
		{
		}
	}
}
