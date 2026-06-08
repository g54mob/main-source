using System;

namespace CsvHelper
{
	[Serializable]
	public class WriterException : CsvHelperException
	{
		public WriterException(CsvContext context)
			: base(context)
		{
		}

		public WriterException(CsvContext context, string message)
			: base(context, message)
		{
		}

		public WriterException(CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
		}
	}
}
