using System;

namespace CsvHelper
{
	[Serializable]
	public abstract class ValidationException : CsvHelperException
	{
		public ValidationException(ReadingContext context)
		{
		}

		public ValidationException(ReadingContext context, string message)
		{
		}

		public ValidationException(ReadingContext context, string message, Exception innerException)
		{
		}
	}
}
