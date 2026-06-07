namespace Utf8Json.Resolvers.Internal
{
	internal class DynamicMethodAnonymousFormatter<T> : IJsonFormatter<T>, IJsonFormatter
	{
		private readonly byte[][] stringByteKeysField;

		private readonly object[] serializeCustomFormatters;

		private readonly object[] deserializeCustomFormatters;

		private readonly AnonymousJsonSerializeAction<T> serialize;

		private readonly AnonymousJsonDeserializeFunc<T> deserialize;

		public DynamicMethodAnonymousFormatter(byte[][] stringByteKeysField, object[] serializeCustomFormatters, object[] deserializeCustomFormatters, AnonymousJsonSerializeAction<T> serialize, AnonymousJsonDeserializeFunc<T> deserialize)
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
