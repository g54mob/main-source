using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public class SessionUpdate : ISentrySession, ISentryJsonSerializable
	{
		public SentryId Id { get; }

		public string? DistinctId { get; }

		public DateTimeOffset StartTimestamp { get; }

		public string Release { get; }

		public string? Environment { get; }

		public string? IpAddress { get; }

		public string? UserAgent { get; }

		public int ErrorCount { get; }

		public bool IsInitial { get; }

		public DateTimeOffset Timestamp { get; }

		public int SequenceNumber { get; }

		public TimeSpan Duration => Timestamp - StartTimestamp;

		public SessionEndStatus? EndStatus { get; }

		public SessionUpdate(SentryId id, string? distinctId, DateTimeOffset startTimestamp, string release, string? environment, string? ipAddress, string? userAgent, int errorCount, bool isInitial, DateTimeOffset timestamp, int sequenceNumber, SessionEndStatus? endStatus)
		{
			Id = id;
			DistinctId = distinctId;
			StartTimestamp = startTimestamp;
			Release = release;
			Environment = environment;
			IpAddress = ipAddress;
			UserAgent = userAgent;
			ErrorCount = errorCount;
			IsInitial = isInitial;
			Timestamp = timestamp;
			SequenceNumber = sequenceNumber;
			EndStatus = endStatus;
		}

		public SessionUpdate(ISentrySession session, bool isInitial, DateTimeOffset timestamp, int sequenceNumber, SessionEndStatus? endStatus)
			: this(session.Id, session.DistinctId, session.StartTimestamp, session.Release, session.Environment, session.IpAddress, session.UserAgent, session.ErrorCount, isInitial, timestamp, sequenceNumber, endStatus)
		{
		}

		public SessionUpdate(SessionUpdate sessionUpdate, bool isInitial, SessionEndStatus? endStatus)
			: this(sessionUpdate, isInitial, sessionUpdate.Timestamp, sessionUpdate.SequenceNumber, endStatus)
		{
		}

		public SessionUpdate(SessionUpdate sessionUpdate, bool isInitial)
			: this(sessionUpdate, isInitial, sessionUpdate.EndStatus)
		{
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteSerializable("sid", Id, logger);
			writer.WriteStringIfNotWhiteSpace("did", DistinctId);
			writer.WriteBoolean("init", IsInitial);
			writer.WriteString("started", StartTimestamp);
			writer.WriteString("timestamp", Timestamp);
			writer.WriteNumber("seq", SequenceNumber);
			writer.WriteNumber("duration", (int)Duration.TotalSeconds);
			writer.WriteNumber("errors", ErrorCount);
			writer.WriteStringIfNotWhiteSpace("status", EndStatus?.ToString().ToSnakeCase());
			writer.WriteStartObject("attrs");
			writer.WriteString("release", Release);
			writer.WriteStringIfNotWhiteSpace("environment", Environment);
			writer.WriteStringIfNotWhiteSpace("ip_address", IpAddress);
			writer.WriteStringIfNotWhiteSpace("user_agent", UserAgent);
			writer.WriteEndObject();
			writer.WriteEndObject();
		}

		public static SessionUpdate FromJson(JsonElement json)
		{
			SentryId id = json.GetProperty("sid").GetStringOrThrow().Pipe(SentryId.Parse);
			string distinctId = json.GetPropertyOrNull("did")?.GetString();
			DateTimeOffset dateTimeOffset = json.GetProperty("started").GetDateTimeOffset();
			string stringOrThrow = json.GetProperty("attrs").GetProperty("release").GetStringOrThrow();
			string environment = json.GetProperty("attrs").GetPropertyOrNull("environment")?.GetString();
			string ipAddress = json.GetProperty("attrs").GetPropertyOrNull("ip_address")?.GetString();
			string userAgent = json.GetProperty("attrs").GetPropertyOrNull("user_agent")?.GetString();
			int errorCount = json.GetPropertyOrNull("errors")?.GetInt32() ?? 0;
			bool isInitial = json.GetPropertyOrNull("init")?.GetBoolean() ?? false;
			DateTimeOffset dateTimeOffset2 = json.GetProperty("timestamp").GetDateTimeOffset();
			int @int = json.GetProperty("seq").GetInt32();
			SessionEndStatus? endStatus = json.GetPropertyOrNull("status")?.GetString()?.ParseEnum<SessionEndStatus>();
			return new SessionUpdate(id, distinctId, dateTimeOffset, stringOrThrow, environment, ipAddress, userAgent, errorCount, isInitial, dateTimeOffset2, @int, endStatus);
		}
	}
}
