namespace LINQtoCSV
{
	public class CsvColumnAttributeRequiredException : LINQtoCSVException
	{
		public CsvColumnAttributeRequiredException()
			: base("CsvFileDescription.EnforceCsvColumnAttribute is false, but needs to be true because CsvFileDescription.FirstLineHasColumnNames is false. See the description for CsvColumnAttributeRequiredException.")
		{
		}
	}
}
