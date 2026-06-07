using System.Collections.Generic;

namespace Utf8Json.Formatters
{
	public sealed class KeyValuePairFormatter<TKey, TValue> : IJsonFormatter<KeyValuePair<TKey, TValue>>, IJsonFormatter
	{
		public void Serialize(ref JsonWriter writer, KeyValuePair<TKey, TValue> value, IJsonFormatterResolver formatterResolver)
		{
		}

		public KeyValuePair<TKey, TValue> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(KeyValuePair<TKey, TValue>);
		}
	}
}
