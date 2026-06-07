using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class NonGenericDictionaryFormatter<T> : IJsonFormatter<T>, IJsonFormatter where T : class, IDictionary, new()
	{
		public void Serialize(ref JsonWriter writer, T value, IJsonFormatterResolver formatterResolver)
		{
		}

		public T Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
