using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class SentryException : ISentryJsonSerializable
	{
		public string? Type { get; set; }

		public string? Value { get; set; }

		public string? Module { get; set; }

		public int ThreadId { get; set; }

		public SentryStackTrace? Stacktrace { get; set; }

		public Mechanism? Mechanism { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringIfNotWhiteSpace("type", Type);
			writer.WriteStringIfNotWhiteSpace("value", Value);
			writer.WriteStringIfNotWhiteSpace("module", Module);
			writer.WriteNumberIfNotNull("thread_id", ThreadId.NullIfDefault());
			writer.WriteSerializableIfNotNull("stacktrace", Stacktrace, logger);
			Mechanism? mechanism = Mechanism;
			if (mechanism != null && !mechanism.IsDefaultOrEmpty())
			{
				writer.WriteSerializableIfNotNull("mechanism", Mechanism, logger);
			}
			writer.WriteEndObject();
		}

		public static SentryException FromJson(JsonElement json)
		{
			string type = json.GetPropertyOrNull("type")?.GetString();
			string value = json.GetPropertyOrNull("value")?.GetString();
			string module = json.GetPropertyOrNull("module")?.GetString();
			int threadId = json.GetPropertyOrNull("thread_id")?.GetInt32() ?? 0;
			SentryStackTrace stacktrace = json.GetPropertyOrNull("stacktrace")?.Pipe(SentryStackTrace.FromJson);
			Mechanism mechanism = json.GetPropertyOrNull("mechanism")?.Pipe(Sentry.Protocol.Mechanism.FromJson);
			if (mechanism != null && mechanism.IsDefaultOrEmpty())
			{
				mechanism = null;
			}
			return new SentryException
			{
				Type = type,
				Value = value,
				Module = module,
				ThreadId = threadId,
				Stacktrace = stacktrace,
				Mechanism = mechanism
			};
		}
	}
}
