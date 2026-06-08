namespace CsvHelper
{
	public readonly struct ConvertToStringArgs<TClass>
	{
		public readonly TClass Value;

		public ConvertToStringArgs(TClass value)
		{
			Value = value;
		}
	}
}
