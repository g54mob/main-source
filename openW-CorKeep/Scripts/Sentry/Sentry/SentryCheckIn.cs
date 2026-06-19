using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public class SentryCheckIn : ISentryJsonSerializable
	{
		public SentryId Id { get; }

		public string MonitorSlug { get; }

		public CheckInStatus Status { get; }

		public TimeSpan? Duration { get; set; }

		public string? Release { get; set; }

		public string? Environment { get; set; }

		internal SentryId? TraceId { get; set; }

		internal SentryMonitorOptions? MonitorOptions { get; set; }

		public SentryCheckIn(string monitorSlug, CheckInStatus status, SentryId? sentryId = null)
		{
			MonitorSlug = monitorSlug;
			Status = status;
			Id = sentryId ?? SentryId.Create();
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteSerializable("check_in_id", Id, logger);
			writer.WriteString("monitor_slug", MonitorSlug);
			writer.WriteString("status", ToSnakeCase(Status));
			writer.WriteNumberIfNotNull("duration", Duration?.TotalSeconds);
			writer.WriteStringIfNotWhiteSpace("release", Release);
			writer.WriteStringIfNotWhiteSpace("environment", Environment);
			if (TraceId.HasValue)
			{
				writer.WriteStartObject("contexts");
				writer.WriteStartObject("trace");
				writer.WriteStringIfNotWhiteSpace("trace_id", TraceId.ToString());
				writer.WriteEndObject();
				writer.WriteEndObject();
			}
			MonitorOptions?.WriteTo(writer, logger);
			writer.WriteEndObject();
		}

		private static string ToSnakeCase(CheckInStatus status)
		{
			return status switch
			{
				CheckInStatus.InProgress => "in_progress", 
				CheckInStatus.Ok => "ok", 
				CheckInStatus.Error => "error", 
				_ => throw new ArgumentException($"Unsupported CheckInStatus: '{status}'."), 
			};
		}
	}
}
