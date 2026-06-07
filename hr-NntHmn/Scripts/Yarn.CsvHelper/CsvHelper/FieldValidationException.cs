using System;

namespace CsvHelper
{
	public class FieldValidationException : ValidationException
	{
		public string Field { get; private set; }

		public FieldValidationException(ReadingContext context, string field)
			: base(null)
		{
		}

		public FieldValidationException(ReadingContext context, string field, string message)
			: base(null)
		{
		}

		public FieldValidationException(ReadingContext context, string field, string message, Exception innerException)
			: base(null)
		{
		}
	}
}
