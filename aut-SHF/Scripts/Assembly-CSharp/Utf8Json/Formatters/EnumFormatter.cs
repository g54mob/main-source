using System.Collections.Generic;
using Utf8Json.Internal;

namespace Utf8Json.Formatters
{
	public class EnumFormatter<T> : IJsonFormatter<T>, IJsonFormatter, IObjectPropertyNameFormatter<T>
	{
		private static readonly ByteArrayStringHashTable<T> nameValueMapping;

		private static readonly Dictionary<T, string> valueNameMapping;

		private static readonly JsonSerializeAction<T> defaultSerializeByUnderlyingValue;

		private static readonly JsonDeserializeFunc<T> defaultDeserializeByUnderlyingValue;

		private readonly bool serializeByName;

		private readonly JsonSerializeAction<T> serializeByUnderlyingValue;

		private readonly JsonDeserializeFunc<T> deserializeByUnderlyingValue;

		static EnumFormatter()
		{
		}

		public EnumFormatter(bool serializeByName)
		{
		}

		public EnumFormatter(JsonSerializeAction<T> valueSerializeAction, JsonDeserializeFunc<T> valueDeserializeAction)
		{
		}

		public void Serialize(ref JsonWriter writer, T value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(T);
		}

		public void SerializeToPropertyName(ref JsonWriter writer, T value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(T);
		}
	}
}
