using System;

namespace Utf8Json.Formatters
{
	public sealed class NullableDateTimeFormatter : IJsonFormatter<DateTime?>, IJsonFormatter
	{
		private readonly DateTimeFormatter innerFormatter;

		public NullableDateTimeFormatter()
		{
		}

		public NullableDateTimeFormatter(string formatString)
		{
		}

		public void Serialize(ref JsonWriter writer, DateTime? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTime? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
