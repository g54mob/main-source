using System;

namespace Utf8Json.Formatters
{
	public sealed class DateTimeFormatter : IJsonFormatter<DateTime>, IJsonFormatter
	{
		private readonly string formatString;

		public DateTimeFormatter()
		{
		}

		public DateTimeFormatter(string formatString)
		{
		}

		public void Serialize(ref JsonWriter writer, DateTime value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTime Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(DateTime);
		}
	}
}
