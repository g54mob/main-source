namespace CsvHelper
{
	public readonly struct GetDynamicPropertyNameArgs
	{
		public readonly int FieldIndex;

		public readonly CsvContext Context;

		public GetDynamicPropertyNameArgs(int fieldIndex, CsvContext context)
		{
			FieldIndex = fieldIndex;
			Context = context;
		}
	}
}
