namespace CsvHelper
{
	public readonly struct ValidateArgs
	{
		public readonly string Field;

		public ValidateArgs(string field)
		{
			Field = field;
		}
	}
}
