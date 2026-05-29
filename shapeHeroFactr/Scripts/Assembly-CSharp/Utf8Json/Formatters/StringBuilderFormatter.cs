using System.Text;

namespace Utf8Json.Formatters
{
	public sealed class StringBuilderFormatter : IJsonFormatter<StringBuilder>, IJsonFormatter
	{
		public static readonly IJsonFormatter<StringBuilder> Default;

		public void Serialize(ref JsonWriter writer, StringBuilder value, IJsonFormatterResolver formatterResolver)
		{
		}

		public StringBuilder Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
