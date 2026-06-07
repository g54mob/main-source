using System;

namespace Utf8Json.Formatters
{
	public sealed class GuidFormatter : IJsonFormatter<Guid>, IJsonFormatter, IObjectPropertyNameFormatter<Guid>
	{
		public static readonly IJsonFormatter<Guid> Default;

		public void Serialize(ref JsonWriter writer, Guid value, IJsonFormatterResolver formatterResolver)
		{
		}

		public Guid Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(Guid);
		}

		public void SerializeToPropertyName(ref JsonWriter writer, Guid value, IJsonFormatterResolver formatterResolver)
		{
		}

		public Guid DeserializeFromPropertyName(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return default(Guid);
		}
	}
}
