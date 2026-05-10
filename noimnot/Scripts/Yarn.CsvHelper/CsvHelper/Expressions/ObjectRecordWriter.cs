using System;

namespace CsvHelper.Expressions
{
	public class ObjectRecordWriter : RecordWriter
	{
		public ObjectRecordWriter(CsvWriter writer)
			: base(null)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			return null;
		}
	}
}
