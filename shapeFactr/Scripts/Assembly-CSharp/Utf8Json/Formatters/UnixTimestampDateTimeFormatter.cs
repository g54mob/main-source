using System;

namespace Utf8Json.Formatters
{
	public sealed class UnixTimestampDateTimeFormatter : IJsonFormatter<DateTime>, IJsonFormatter
	{
		private static readonly DateTime UnixEpoch;

		public void Serialize(ref JsonWriter writer, DateTime value, IJsonFormatterResolver formatterResolver)
		{
		}

		public DateTime Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(DateTime);
		}
	}
}
