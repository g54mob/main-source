using System;

namespace CsvHelper
{
	[Serializable]
	public class BadDataException : CsvHelperException
	{
		public BadDataException(ReadingContext context)
		{
		}

		public BadDataException(ReadingContext context, string message)
		{
		}

		public BadDataException(ReadingContext context, string message, Exception innerException)
		{
		}
	}
}
