using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class NonGenericInterfaceEnumerableFormatter : IJsonFormatter<IEnumerable>, IJsonFormatter
	{
		public static readonly IJsonFormatter<IEnumerable> Default;

		public void Serialize(ref JsonWriter writer, IEnumerable value, IJsonFormatterResolver formatterResolver)
		{
		}

		public IEnumerable Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
