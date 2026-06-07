using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class NonGenericListFormatter<T> : IJsonFormatter<T>, IJsonFormatter where T : class, IList, new()
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
