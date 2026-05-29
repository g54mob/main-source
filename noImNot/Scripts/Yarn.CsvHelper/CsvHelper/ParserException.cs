using System;

namespace CsvHelper
{
	[Serializable]
	public class ParserException : CsvHelperException
	{
		public ParserException(ReadingContext context)
		{
		}

		public ParserException(ReadingContext context, string message)
		{
		}

		public ParserException(ReadingContext context, string message, Exception innerException)
		{
		}
	}
}
