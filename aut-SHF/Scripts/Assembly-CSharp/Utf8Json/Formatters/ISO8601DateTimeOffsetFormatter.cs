using System;

namespace Utf8Json.Formatters
{
	public sealed class ISO8601DateTimeOffsetFormatter : IJsonFormatter<DateTimeOffset>, IJsonFormatter
	{
		public static readonly IJsonFormatter<DateTimeOffset> Default;

		public void Serialize(ref JsonWriter writer, DateTimeOffset value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTimeOffset Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(DateTimeOffset);
		}
	}
}
