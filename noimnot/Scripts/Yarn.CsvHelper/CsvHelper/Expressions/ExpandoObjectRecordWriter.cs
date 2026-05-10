using System;

namespace CsvHelper.Expressions
{
	public class ExpandoObjectRecordWriter : RecordWriter
	{
		public ExpandoObjectRecordWriter(CsvWriter writer)
			: base(null)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			return null;
		}
	}
}
