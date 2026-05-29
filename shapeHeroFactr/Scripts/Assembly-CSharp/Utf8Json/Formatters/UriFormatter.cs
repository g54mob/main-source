using System;

namespace Utf8Json.Formatters
{
	public sealed class UriFormatter : IJsonFormatter<Uri>, IJsonFormatter
	{
		public static readonly IJsonFormatter<Uri> Default;

		public void Serialize(ref JsonWriter writer, Uri value, IJsonFormatterResolver formatterResolver)
		{
		}

		public Uri Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
