namespace CsvHelper
{
	public readonly struct HeaderValidatedArgs
	{
		public readonly InvalidHeader[] InvalidHeaders;

		public readonly CsvContext Context;

		public HeaderValidatedArgs(InvalidHeader[] invalidHeaders, CsvContext context)
		{
			InvalidHeaders = invalidHeaders;
			Context = context;
		}
	}
}
