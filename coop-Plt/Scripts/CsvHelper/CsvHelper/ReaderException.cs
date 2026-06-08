using System;

namespace CsvHelper
{
	[Serializable]
	public class ReaderException : CsvHelperException
	{
		public ReaderException(CsvContext context)
			: base(context)
		{
		}

		public ReaderException(CsvContext context, string message)
			: base(context, message)
		{
		}

		public ReaderException(CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
		}
	}
}
