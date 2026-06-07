using System;

namespace Utf8Json.Formatters
{
	public sealed class VersionFormatter : IJsonFormatter<Version>, IJsonFormatter
	{
		public static readonly IJsonFormatter<Version> Default;

		public void Serialize(ref JsonWriter writer, Version value, IJsonFormatterResolver formatterResolver)
		{
		}

		public Version Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			return null;
		}
	}
}
