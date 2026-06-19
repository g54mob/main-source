using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Runtime : ISentryJsonSerializable, ICloneable<Runtime>, IUpdatable<Runtime>, IUpdatable
	{
		public const string Type = "runtime";

		public string? Name { get; set; }

		public string? Version { get; set; }

		public string? RawDescription { get; set; }

		public string? Identifier { get; set; }

		public string? Build { get; set; }

		internal Runtime Clone()
		{
			return ((ICloneable<Runtime>)this).Clone();
		}

		Runtime ICloneable<Runtime>.Clone()
		{
			return new Runtime
			{
				Name = Name,
				Version = Version,
				Identifier = Identifier,
				Build = Build,
				RawDescription = RawDescription
			};
		}

		internal void UpdateFrom(Runtime source)
		{
			((IUpdatable<Runtime>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is Runtime source2)
			{
				((IUpdatable<Runtime>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<Runtime>.UpdateFrom(Runtime source)
		{
			if (Name == null)
			{
				string text = (Name = source.Name);
			}
			if (Version == null)
			{
				string text = (Version = source.Version);
			}
			if (Identifier == null)
			{
				string text = (Identifier = source.Identifier);
			}
			if (Build == null)
			{
				string text = (Build = source.Build);
			}
			if (RawDescription == null)
			{
				string text = (RawDescription = source.RawDescription);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "runtime");
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("version", Version);
			writer.WriteStringIfNotWhiteSpace("raw_description", RawDescription);
			writer.WriteStringIfNotWhiteSpace("identifier", Identifier);
			writer.WriteStringIfNotWhiteSpace("build", Build);
			writer.WriteEndObject();
		}

		public static Runtime FromJson(JsonElement json)
		{
			string name = json.GetPropertyOrNull("name")?.GetString();
			string version = json.GetPropertyOrNull("version")?.GetString();
			string rawDescription = json.GetPropertyOrNull("raw_description")?.GetString();
			string identifier = json.GetPropertyOrNull("identifier")?.GetString();
			string build = json.GetPropertyOrNull("build")?.GetString();
			return new Runtime
			{
				Name = name,
				Version = version,
				RawDescription = rawDescription,
				Identifier = identifier,
				Build = build
			};
		}
	}
}
