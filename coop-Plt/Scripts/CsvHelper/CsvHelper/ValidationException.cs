using System;

namespace CsvHelper
{
	[Serializable]
	public abstract class ValidationException : CsvHelperException
	{
		public ValidationException(CsvContext context)
			: base(context)
		{
		}

		public ValidationException(CsvContext context, string message)
			: base(context, message)
		{
		}

		public ValidationException(CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
		}
	}
}
