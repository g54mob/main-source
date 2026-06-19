using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public sealed class SentryPackage : ISentryJsonSerializable
	{
		public string Name { get; }

		public string Version { get; }

		public SentryPackage(string name, string version)
		{
			Name = name;
			Version = version;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("version", Version);
			writer.WriteEndObject();
		}

		public static SentryPackage FromJson(JsonElement json)
		{
			string stringOrThrow = json.GetProperty("name").GetStringOrThrow();
			string stringOrThrow2 = json.GetProperty("version").GetStringOrThrow();
			return new SentryPackage(stringOrThrow, stringOrThrow2);
		}

		public override int GetHashCode()
		{
			return (Name.GetHashCode() * 397) ^ Version.GetHashCode();
		}

		public override bool Equals(object? obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj is SentryPackage sentryPackage)
			{
				if (Name == sentryPackage.Name)
				{
					return Version == sentryPackage.Version;
				}
				return false;
			}
			return false;
		}
	}
}
