using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class NonGenericInterfaceCollectionFormatter : IJsonFormatter<ICollection>, IJsonFormatter
	{
		public static readonly IJsonFormatter<ICollection> Default;

		public void Serialize(ref JsonWriter writer, ICollection value, IJsonFormatterResolver formatterResolver)
		{
		}

		public ICollection Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
