using System;
using System.Text.Json;
using Sentry.Extensibility;

namespace Sentry
{
	public readonly struct SentryId : IEquatable<SentryId>, ISentryJsonSerializable
	{
		private readonly Guid _guid;

		public static readonly SentryId Empty;

		public SentryId(Guid guid)
		{
			_guid = guid;
		}

		public override string ToString()
		{
			return _guid.ToString("n");
		}

		public bool Equals(SentryId other)
		{
			return _guid.Equals(other._guid);
		}

		public override bool Equals(object? obj)
		{
			if (obj is SentryId other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _guid.GetHashCode();
		}

		public static SentryId Create()
		{
			return new SentryId(Guid.NewGuid());
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStringValue(ToString());
		}

		public static SentryId Parse(string value)
		{
			return new SentryId(Guid.Parse(value));
		}

		public static SentryId FromJson(JsonElement json)
		{
			string value = json.GetString();
			if (string.IsNullOrWhiteSpace(value))
			{
				return Empty;
			}
			return Parse(value);
		}

		public static bool operator ==(SentryId left, SentryId right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(SentryId left, SentryId right)
		{
			return !(left == right);
		}

		public static implicit operator Guid(SentryId sentryId)
		{
			return sentryId._guid;
		}

		public static implicit operator SentryId(Guid guid)
		{
			return new SentryId(guid);
		}
	}
}
