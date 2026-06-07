using System.Collections;

namespace Utf8Json.Formatters
{
	public sealed class NonGenericInterfaceListFormatter : IJsonFormatter<IList>, IJsonFormatter
	{
		public static readonly IJsonFormatter<IList> Default;

		public void Serialize(ref JsonWriter writer, IList value, IJsonFormatterResolver formatterResolver)
		{
		}

		public IList Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
