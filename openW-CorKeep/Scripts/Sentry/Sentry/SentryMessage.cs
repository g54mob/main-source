using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class SentryMessage : ISentryJsonSerializable
	{
		public string? Message { get; set; }

		public IEnumerable<object>? Params { get; set; }

		public string? Formatted { get; set; }

		public static implicit operator SentryMessage(string? message)
		{
			return new SentryMessage
			{
				Message = message
			};
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringIfNotWhiteSpace("message", Message);
			writer.WriteArrayIfNotEmpty("params", Params, logger);
			writer.WriteStringIfNotWhiteSpace("formatted", Formatted);
			writer.WriteEndObject();
		}

		public static SentryMessage FromJson(JsonElement json)
		{
			string message = json.GetPropertyOrNull("message")?.GetString();
			JsonElement? propertyOrNull = json.GetPropertyOrNull("params");
			object[] array = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetDynamicOrNull() into o
				where o != null
				select o).ToArray() : null);
			string formatted = json.GetPropertyOrNull("formatted")?.GetString();
			return new SentryMessage
			{
				Message = message,
				Params = array,
				Formatted = formatted
			};
		}
	}
}
