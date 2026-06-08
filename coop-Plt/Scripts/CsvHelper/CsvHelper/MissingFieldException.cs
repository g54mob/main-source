using System;

namespace CsvHelper
{
	[Serializable]
	public class MissingFieldException : ReaderException
	{
		public MissingFieldException(CsvContext context)
			: base(context)
		{
		}

		public MissingFieldException(CsvContext context, string message)
			: base(context, message)
		{
		}

		public MissingFieldException(CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
		}
	}
}
