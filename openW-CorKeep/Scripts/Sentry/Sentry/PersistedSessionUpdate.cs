using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	internal class PersistedSessionUpdate : ISentryJsonSerializable
	{
		public SessionUpdate Update { get; }

		public DateTimeOffset? PauseTimestamp { get; }

		public PersistedSessionUpdate(SessionUpdate update, DateTimeOffset? pauseTimestamp)
		{
			Update = update;
			PauseTimestamp = pauseTimestamp;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteSerializable("update", Update, logger);
			DateTimeOffset? pauseTimestamp = PauseTimestamp;
			if (pauseTimestamp.HasValue)
			{
				DateTimeOffset valueOrDefault = pauseTimestamp.GetValueOrDefault();
				writer.WriteString("paused", valueOrDefault);
			}
			writer.WriteEndObject();
		}

		public static PersistedSessionUpdate FromJson(JsonElement json)
		{
			SessionUpdate update = SessionUpdate.FromJson(json.GetProperty("update"));
			DateTimeOffset? pauseTimestamp = json.GetPropertyOrNull("paused")?.GetDateTimeOffset();
			return new PersistedSessionUpdate(update, pauseTimestamp);
		}
	}
}
