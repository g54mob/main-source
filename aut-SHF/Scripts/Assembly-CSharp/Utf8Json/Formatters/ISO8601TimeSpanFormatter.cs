using System;

namespace Utf8Json.Formatters
{
	public sealed class ISO8601TimeSpanFormatter : IJsonFormatter<TimeSpan>, IJsonFormatter
	{
		public static readonly IJsonFormatter<TimeSpan> Default;

		private static byte[] minValue;

		public void Serialize(ref JsonWriter writer, TimeSpan value, IJsonFormatterResolver formatterResolver)
		{
		}

		public TimeSpan Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(TimeSpan);
		}
	}
}
