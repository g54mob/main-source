using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class SentryThread : ISentryJsonSerializable
	{
		public int? Id { get; set; }

		public string? Name { get; set; }

		public bool? Crashed { get; set; }

		public bool? Current { get; set; }

		public SentryStackTrace? Stacktrace { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteNumberIfNotNull("id", Id);
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteBooleanIfNotNull("crashed", Crashed);
			writer.WriteBooleanIfNotNull("current", Current);
			writer.WriteSerializableIfNotNull("stacktrace", Stacktrace, logger);
			writer.WriteEndObject();
		}

		public static SentryThread FromJson(JsonElement json)
		{
			int? id = json.GetPropertyOrNull("id")?.GetInt32();
			string name = json.GetPropertyOrNull("name")?.GetString();
			bool? crashed = json.GetPropertyOrNull("crashed")?.GetBoolean();
			bool? current = json.GetPropertyOrNull("current")?.GetBoolean();
			SentryStackTrace stacktrace = json.GetPropertyOrNull("stacktrace")?.Pipe(SentryStackTrace.FromJson);
			return new SentryThread
			{
				Id = id,
				Name = name,
				Crashed = crashed,
				Current = current,
				Stacktrace = stacktrace
			};
		}
	}
}
