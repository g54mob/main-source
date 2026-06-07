using System;
using System.Runtime.Serialization;

namespace GenericParsing
{
	[Serializable]
	public class ParsingException : Exception
	{
		private const string SERIALIZATION_COLUMN_NUMBER = "ColumnNumber";

		private const string SERIALIZATION_FILE_ROW_NUMBER = "FileRowNumber";

		private int m_intFileRowNumber;

		private int m_intColumnNumber;

		public int FileRowNumber => 0;

		public int ColumnNumber => 0;

		public ParsingException()
		{
		}

		public ParsingException(string strMessage, int intFileRowNumber, int intColumnNumber)
		{
		}

		protected ParsingException(SerializationInfo sInfo, StreamingContext sContext)
		{
		}

		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
}
