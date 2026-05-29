using System;

namespace CsvHelper.Expressions
{
	public class PrimitiveRecordWriter : RecordWriter
	{
		public PrimitiveRecordWriter(CsvWriter writer)
			: base(null)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			return null;
		}
	}
}
