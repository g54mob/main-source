using System;

namespace CsvHelper
{
	[Serializable]
	public class MissingFieldException : ReaderException
	{
		public MissingFieldException(ReadingContext context)
			: base(null)
		{
		}

		public MissingFieldException(ReadingContext context, string message)
			: base(null)
		{
		}

		public MissingFieldException(ReadingContext context, string message, Exception innerException)
			: base(null)
		{
		}
	}
}
