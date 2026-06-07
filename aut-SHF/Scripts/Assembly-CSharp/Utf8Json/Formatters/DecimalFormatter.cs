namespace Utf8Json.Formatters
{
	public sealed class DecimalFormatter : IJsonFormatter<decimal>, IJsonFormatter
	{
		public static readonly IJsonFormatter<decimal> Default;

		private readonly bool serializeAsString;

		public DecimalFormatter()
		{
		}

		public DecimalFormatter(bool serializeAsString)
		{
		}

		public void Serialize(ref JsonWriter writer, decimal value, IJsonFormatterResolver formatterResolver)
		{
		}

		public decimal Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(decimal);
		}
	}
}
