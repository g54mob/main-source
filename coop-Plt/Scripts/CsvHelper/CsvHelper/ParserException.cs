using System;

namespace CsvHelper
{
	[Serializable]
	public class ParserException : CsvHelperException
	{
		public ParserException(CsvContext context)
			: base(context)
		{
		}

		public ParserException(CsvContext context, string message)
			: base(context, message)
		{
		}

		public ParserException(CsvContext context, string message, Exception innerException)
			: base(context, message, innerException)
		{
		}
	}
}
