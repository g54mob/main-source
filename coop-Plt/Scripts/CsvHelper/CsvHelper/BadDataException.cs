using System;

namespace CsvHelper
{
	[Serializable]
	public class BadDataException : CsvHelperException
	{
		public BadDataException(CsvContext context)
			: base(context)
		{
		}

		public BadDataException(CsvContext context, string message)
			: base(context, message)
		{
		}

		public BadDataException(CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
		}
	}
}
