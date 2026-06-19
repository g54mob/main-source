using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sentry.Internal.JsonConverters
{
	internal class SentryJsonConverter : JsonConverter<object?>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			if (!typeof(Type).IsAssignableFrom(typeToConvert))
			{
				return typeToConvert.FullName?.StartsWith("System.Reflection") ?? false;
			}
			return true;
		}

		public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return null;
		}

		public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
		{
			if (value is Type { FullName: not null } type)
			{
				writer.WriteStringValue(type.FullName);
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}
}
