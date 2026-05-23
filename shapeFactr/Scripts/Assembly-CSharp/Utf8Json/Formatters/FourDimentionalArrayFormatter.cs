namespace Utf8Json.Formatters
{
	public sealed class FourDimentionalArrayFormatter<T> : IJsonFormatter<T[,,,]>, IJsonFormatter
	{
		public void Serialize(ref JsonWriter writer, T[,,,] value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T[,,,] Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
