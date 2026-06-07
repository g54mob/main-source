using System;

namespace CsvHelper
{
	[Serializable]
	public class CsvHelperException : Exception
	{
		[NonSerialized]
		private readonly ReadingContext readingContext;

		[NonSerialized]
		private readonly WritingContext writingContext;

		public ReadingContext ReadingContext => null;

		public WritingContext WritingContext => null;

		protected internal CsvHelperException()
		{
		}

		protected internal CsvHelperException(string message)
		{
		}

		protected internal CsvHelperException(string message, Exception innerException)
		{
		}

		public CsvHelperException(ReadingContext context)
		{
		}

		public CsvHelperException(WritingContext context)
		{
		}

		public CsvHelperException(ReadingContext context, string message)
		{
		}

		public CsvHelperException(ReadingContext context, string message, Exception innerException)
		{
		}

		public CsvHelperException(WritingContext context, string message)
		{
		}

		public CsvHelperException(WritingContext context, string message, Exception innerException)
		{
		}
	}
}
