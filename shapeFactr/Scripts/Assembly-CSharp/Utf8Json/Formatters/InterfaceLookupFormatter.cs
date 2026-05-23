using System.Linq;

namespace Utf8Json.Formatters
{
	public sealed class InterfaceLookupFormatter<TKey, TElement> : IJsonFormatter<ILookup<TKey, TElement>>, IJsonFormatter
	{
		public void Serialize(ref JsonWriter writer, ILookup<TKey, TElement> value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ILookup<TKey, TElement> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
