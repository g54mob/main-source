using System;

namespace Utf8Json.Formatters
{
	public sealed class DateTimeOffsetFormatter : IJsonFormatter<DateTimeOffset>, IJsonFormatter
	{
		private readonly string formatString;

		public DateTimeOffsetFormatter()
		{
		}

		public DateTimeOffsetFormatter(string formatString)
		{
		}

		public void Serialize(ref JsonWriter writer, DateTimeOffset value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTimeOffset Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(DateTimeOffset);
		}
	}
}
