using System;

namespace Utf8Json.Formatters
{
	public sealed class NullableTimeSpanFormatter : IJsonFormatter<TimeSpan?>, IJsonFormatter
	{
		private readonly TimeSpanFormatter innerFormatter;

		public void Serialize(ref JsonWriter writer, TimeSpan? value, IJsonFormatterResolver formatterResolver)
		{
		}

		public TimeSpan? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
