using System;

namespace CsvHelper
{
	[Serializable]
	public class ReaderException : CsvHelperException
	{
		public ReaderException(ReadingContext context)
		{
		}

		public ReaderException(ReadingContext context, string message)
		{
		}

		public ReaderException(ReadingContext context, string message, Exception innerException)
		{
		}
	}
}
