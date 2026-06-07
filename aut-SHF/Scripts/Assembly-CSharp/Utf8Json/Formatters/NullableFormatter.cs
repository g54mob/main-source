namespace Utf8Json.Formatters
{
	public sealed class NullableFormatter<T> : IJsonFormatter<T?>, IJsonFormatter where T : struct
	{
		public void Serialize(ref JsonWriter writer, T? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
