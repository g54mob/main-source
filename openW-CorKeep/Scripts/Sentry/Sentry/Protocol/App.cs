using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class App : ISentryJsonSerializable, ICloneable<App>, IUpdatable<App>, IUpdatable
	{
		public const string Type = "app";

		public string? Identifier { get; set; }

		public DateTimeOffset? StartTime { get; set; }

		public string? Hash { get; set; }

		public string? BuildType { get; set; }

		public string? Name { get; set; }

		public string? Version { get; set; }

		public string? Build { get; set; }

		public bool? InForeground { get; set; }

		internal App Clone()
		{
			return ((ICloneable<App>)this).Clone();
		}

		App ICloneable<App>.Clone()
		{
			return new App
			{
				Identifier = Identifier,
				StartTime = StartTime,
				Hash = Hash,
				BuildType = BuildType,
				Name = Name,
				Version = Version,
				Build = Build,
				InForeground = InForeground
			};
		}

		internal void UpdateFrom(App source)
		{
			((IUpdatable<App>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is App source2)
			{
				((IUpdatable<App>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<App>.UpdateFrom(App source)
		{
			if (Identifier == null)
			{
				string text = (Identifier = source.Identifier);
			}
			if (!StartTime.HasValue)
			{
				DateTimeOffset? dateTimeOffset = (StartTime = source.StartTime);
			}
			if (Hash == null)
			{
				string text = (Hash = source.Hash);
			}
			if (BuildType == null)
			{
				string text = (BuildType = source.BuildType);
			}
			if (Name == null)
			{
				string text = (Name = source.Name);
			}
			if (Version == null)
			{
				string text = (Version = source.Version);
			}
			if (Build == null)
			{
				string text = (Build = source.Build);
			}
			if (!InForeground.HasValue)
			{
				bool? flag = (InForeground = source.InForeground);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "app");
			writer.WriteStringIfNotWhiteSpace("app_identifier", Identifier);
			writer.WriteStringIfNotNull("app_start_time", StartTime);
			writer.WriteStringIfNotWhiteSpace("device_app_hash", Hash);
			writer.WriteStringIfNotWhiteSpace("build_type", BuildType);
			writer.WriteStringIfNotWhiteSpace("app_name", Name);
			writer.WriteStringIfNotWhiteSpace("app_version", Version);
			writer.WriteStringIfNotWhiteSpace("app_build", Build);
			writer.WriteBooleanIfNotNull("in_foreground", InForeground);
			writer.WriteEndObject();
		}

		public static App FromJson(JsonElement json)
		{
			string identifier = json.GetPropertyOrNull("app_identifier")?.GetString();
			DateTimeOffset? startTime = json.GetPropertyOrNull("app_start_time")?.GetDateTimeOffset();
			string hash = json.GetPropertyOrNull("device_app_hash")?.GetString();
			string buildType = json.GetPropertyOrNull("build_type")?.GetString();
			string name = json.GetPropertyOrNull("app_name")?.GetString();
			string version = json.GetPropertyOrNull("app_version")?.GetString();
			string build = json.GetPropertyOrNull("app_build")?.GetString();
			bool? inForeground = json.GetPropertyOrNull("in_foreground")?.GetBoolean();
			return new App
			{
				Identifier = identifier,
				StartTime = startTime,
				Hash = hash,
				BuildType = buildType,
				Name = name,
				Version = version,
				Build = build,
				InForeground = inForeground
			};
		}
	}
}
