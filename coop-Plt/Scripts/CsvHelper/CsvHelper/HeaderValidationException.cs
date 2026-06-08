using System;

namespace CsvHelper
{
	public class HeaderValidationException : ValidationException
	{
		public InvalidHeader[] InvalidHeaders { get; private set; }

		public HeaderValidationException(CsvContext context, InvalidHeader[] invalidHeaders)
			: base(context)
		{
			InvalidHeaders = invalidHeaders;
		}

		public HeaderValidationException(CsvContext context, InvalidHeader[] invalidHeaders, string message)
			: base(context, message)
		{
			InvalidHeaders = invalidHeaders;
		}

		public HeaderValidationException(CsvContext context, InvalidHeader[] invalidHeaders, string message, Exception innerException)
			: base(context, message, innerException)
		{
			InvalidHeaders = invalidHeaders;
		}
	}
}
