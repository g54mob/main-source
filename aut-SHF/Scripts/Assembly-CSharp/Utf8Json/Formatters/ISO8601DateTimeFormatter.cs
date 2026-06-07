using System;

namespace Utf8Json.Formatters
{
	public sealed class ISO8601DateTimeFormatter : IJsonFormatter<DateTime>, IJsonFormatter
	{
		public static readonly IJsonFormatter<DateTime> Default;

		public void Serialize(ref JsonWriter writer, DateTime value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTime Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(DateTime);
		}
	}
}
