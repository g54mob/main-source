using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class UserFeedback : ISentryJsonSerializable
	{
		public SentryId EventId { get; }

		public string? Name { get; }

		public string? Email { get; }

		public string? Comments { get; }

		public UserFeedback(SentryId eventId, string? name, string? email, string? comments)
		{
			EventId = eventId;
			Name = name;
			Email = email;
			Comments = comments;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteSerializable("event_id", EventId, logger);
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("email", Email);
			writer.WriteStringIfNotWhiteSpace("comments", Comments);
			writer.WriteEndObject();
		}

		public static UserFeedback FromJson(JsonElement json)
		{
			SentryId eventId = json.GetPropertyOrNull("event_id")?.Pipe(SentryId.FromJson) ?? SentryId.Empty;
			string name = json.GetPropertyOrNull("name")?.GetString();
			string email = json.GetPropertyOrNull("email")?.GetString();
			string comments = json.GetPropertyOrNull("comments")?.GetString();
			return new UserFeedback(eventId, name, email, comments);
		}
	}
}
