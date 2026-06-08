namespace CsvHelper
{
	public readonly struct ShouldSkipRecordArgs
	{
		public readonly string[] Record;

		public ShouldSkipRecordArgs(string[] record)
		{
			Record = record;
		}
	}
}
