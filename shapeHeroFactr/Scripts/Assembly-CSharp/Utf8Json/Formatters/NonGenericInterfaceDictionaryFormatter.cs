using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class NonGenericInterfaceDictionaryFormatter : IJsonFormatter<IDictionary>, IJsonFormatter
	{
		public static readonly IJsonFormatter<IDictionary> Default;

		public void Serialize(ref JsonWriter writer, IDictionary value, IJsonFormatterResolver formatterResolver)
		{
		}

		public IDictionary Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
