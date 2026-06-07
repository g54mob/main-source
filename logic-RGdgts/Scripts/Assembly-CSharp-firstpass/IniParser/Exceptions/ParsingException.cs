using System;

namespace IniParser.Exceptions
{
	public class ParsingException : Exception
	{
		public Version LibVersion { get; }

		public uint LineNumber { get; }

		public string LineContents { get; }

		public ParsingException(string msg, uint lineNumber)
		{
		}

		public ParsingException(string msg, Exception innerException)
		{
		}

		public ParsingException(string msg, uint lineNumber, string lineContents)
		{
		}

		public ParsingException(string msg, uint lineNumber, string lineContents, Exception innerException)
		{
		}

		private Version GetAssemblyVersion()
		{
			return null;
		}
	}
}
