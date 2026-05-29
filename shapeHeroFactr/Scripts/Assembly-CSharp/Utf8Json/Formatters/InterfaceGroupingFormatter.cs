using System.Linq;

namespace Utf8Json.Formatters
{
	public sealed class InterfaceGroupingFormatter<TKey, TElement> : IJsonFormatter<IGrouping<TKey, TElement>>, IJsonFormatter
	{
		public void Serialize(ref JsonWriter writer, IGrouping<TKey, TElement> value, IJsonFormatterResolver formatterResolver)
		{
		}

		public IGrouping<TKey, TElement> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
