namespace CsvHelper
{
	public readonly struct MissingFieldFoundArgs
	{
		public readonly string[] HeaderNames;

		public readonly int Index;

		public readonly CsvContext Context;

		public MissingFieldFoundArgs(string[] headerNames, int index, CsvContext context)
		{
			HeaderNames = headerNames;
			Index = index;
			Context = context;
		}
	}
}
