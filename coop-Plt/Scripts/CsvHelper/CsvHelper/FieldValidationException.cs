using System;

namespace CsvHelper
{
	public class FieldValidationException : ValidationException
	{
		public string Field { get; private set; }

		public FieldValidationException(CsvContext context, string field)
			: base(context)
		{
			Field = field;
		}

		public FieldValidationException(CsvContext context, string field, string message)
			: base(context, message)
		{
			Field = field;
		}

		public FieldValidationException(CsvContext context, string field, string message, Exception innerException)
			: base(context, message, innerException)
		{
			Field = field;
		}
	}
}
