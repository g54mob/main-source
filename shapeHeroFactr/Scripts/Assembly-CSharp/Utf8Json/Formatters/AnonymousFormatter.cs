namespace Utf8Json.Formatters
{
	public sealed class AnonymousFormatter<T> : IJsonFormatter<T>, IJsonFormatter
	{
		private readonly JsonSerializeAction<T> serialize;

		private readonly JsonDeserializeFunc<T> deserialize;

		public AnonymousFormatter(JsonSerializeAction<T> serialize, JsonDeserializeFunc<T> deserialize)
		{
		}

		public void Serialize(ref JsonWriter writer, T value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(T);
		}
	}
}
