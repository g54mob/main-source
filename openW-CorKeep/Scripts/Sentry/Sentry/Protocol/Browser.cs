using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Browser : ISentryJsonSerializable, ICloneable<Browser>, IUpdatable<Browser>, IUpdatable
	{
		public const string Type = "browser";

		public string? Name { get; set; }

		public string? Version { get; set; }

		internal Browser Clone()
		{
			return ((ICloneable<Browser>)this).Clone();
		}

		Browser ICloneable<Browser>.Clone()
		{
			return new Browser
			{
				Name = Name,
				Version = Version
			};
		}

		internal void UpdateFrom(Browser source)
		{
			((IUpdatable<Browser>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is Browser source2)
			{
				((IUpdatable<Browser>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<Browser>.UpdateFrom(Browser source)
		{
			if (Name == null)
			{
				string text = (Name = source.Name);
			}
			if (Version == null)
			{
				string text = (Version = source.Version);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "browser");
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("version", Version);
			writer.WriteEndObject();
		}

		public static Browser FromJson(JsonElement json)
		{
			string name = json.GetPropertyOrNull("name")?.GetString();
			string version = json.GetPropertyOrNull("version")?.GetString();
			return new Browser
			{
				Name = name,
				Version = version
			};
		}
	}
}
