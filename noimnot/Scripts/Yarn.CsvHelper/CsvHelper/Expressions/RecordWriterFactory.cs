namespace CsvHelper.Expressions
{
	public class RecordWriterFactory
	{
		private readonly CsvWriter writer;

		public RecordWriterFactory(CsvWriter writer)
		{
		}

		public virtual RecordWriter MakeRecordWriter<T>(T record)
		{
			return null;
		}
	}
}
