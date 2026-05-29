using System;

namespace CsvHelper
{
	public class HeaderValidationException : ValidationException
	{
		public string[] HeaderNames { get; private set; }

		public int? HeaderNameIndex { get; private set; }

		public HeaderValidationException(ReadingContext context, string[] headerNames, int? headerNameIndex)
			: base(null)
		{
		}

		public HeaderValidationException(ReadingContext context, string[] headerNames, int? headerNameIndex, string message)
			: base(null)
		{
		}

		public HeaderValidationException(ReadingContext context, string[] headerNames, int? headerNameIndex, string message, Exception innerException)
			: base(null)
		{
		}
	}
}
