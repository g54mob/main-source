namespace CsvHelper
{
	public readonly struct PrepareHeaderForMatchArgs
	{
		public readonly string Header;

		public readonly int FieldIndex;

		public PrepareHeaderForMatchArgs(string header, int fieldIndex)
		{
			Header = header;
			FieldIndex = fieldIndex;
		}
	}
}
