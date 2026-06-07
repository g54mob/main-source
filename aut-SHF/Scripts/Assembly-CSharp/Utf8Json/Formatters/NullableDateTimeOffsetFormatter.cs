using System;

namespace Utf8Json.Formatters
{
	public sealed class NullableDateTimeOffsetFormatter : IJsonFormatter<DateTimeOffset?>, IJsonFormatter
	{
		private readonly DateTimeOffsetFormatter innerFormatter;

		public NullableDateTimeOffsetFormatter()
		{
		}

		public NullableDateTimeOffsetFormatter(string formatString)
		{
		}

		public void Serialize(ref JsonWriter writer, DateTimeOffset? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTimeOffset? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
