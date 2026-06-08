namespace CsvHelper
{
	public readonly struct ConvertFromStringArgs
	{
		public readonly IReaderRow Row;

		public ConvertFromStringArgs(IReaderRow row)
		{
			Row = row;
		}
	}
}
