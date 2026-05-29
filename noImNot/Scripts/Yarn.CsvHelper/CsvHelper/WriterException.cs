using System;

namespace CsvHelper
{
	[Serializable]
	public class WriterException : CsvHelperException
	{
		public WriterException(WritingContext context)
		{
		}

		public WriterException(WritingContext context, string message)
		{
		}

		public WriterException(WritingContext context, string message, Exception innerException)
		{
		}
	}
}
