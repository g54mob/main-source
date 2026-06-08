namespace CsvHelper
{
	public readonly struct BadDataFoundArgs
	{
		public readonly string Field;

		public readonly string RawRecord;

		public readonly CsvContext Context;

		public BadDataFoundArgs(string field, string rawRecord, CsvContext context)
		{
			Field = field;
			RawRecord = rawRecord;
			Context = context;
		}
	}
}
