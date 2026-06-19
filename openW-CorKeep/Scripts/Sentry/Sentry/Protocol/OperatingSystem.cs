using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class OperatingSystem : ISentryJsonSerializable, ICloneable<OperatingSystem>, IUpdatable<OperatingSystem>, IUpdatable
	{
		public const string Type = "os";

		public string? Name { get; set; }

		public string? Version { get; set; }

		public string? RawDescription { get; set; }

		public string? Build { get; set; }

		public string? KernelVersion { get; set; }

		public bool? Rooted { get; set; }

		internal OperatingSystem Clone()
		{
			return ((ICloneable<OperatingSystem>)this).Clone();
		}

		OperatingSystem ICloneable<OperatingSystem>.Clone()
		{
			return new OperatingSystem
			{
				Name = Name,
				Version = Version,
				RawDescription = RawDescription,
				Build = Build,
				KernelVersion = KernelVersion,
				Rooted = Rooted
			};
		}

		internal void UpdateFrom(OperatingSystem source)
		{
			((IUpdatable<OperatingSystem>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is OperatingSystem source2)
			{
				((IUpdatable<OperatingSystem>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<OperatingSystem>.UpdateFrom(OperatingSystem source)
		{
			if (Name == null)
			{
				string text = (Name = source.Name);
			}
			if (Version == null)
			{
				string text = (Version = source.Version);
			}
			if (RawDescription == null)
			{
				string text = (RawDescription = source.RawDescription);
			}
			if (Build == null)
			{
				string text = (Build = source.Build);
			}
			if (KernelVersion == null)
			{
				string text = (KernelVersion = source.KernelVersion);
			}
			if (!Rooted.HasValue)
			{
				bool? flag = (Rooted = source.Rooted);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? _)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "os");
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("version", Version);
			writer.WriteStringIfNotWhiteSpace("raw_description", RawDescription);
			writer.WriteStringIfNotWhiteSpace("build", Build);
			writer.WriteStringIfNotWhiteSpace("kernel_version", KernelVersion);
			writer.WriteBooleanIfNotNull("rooted", Rooted);
			writer.WriteEndObject();
		}

		public static OperatingSystem FromJson(JsonElement json)
		{
			string name = json.GetPropertyOrNull("name")?.GetString();
			string version = json.GetPropertyOrNull("version")?.GetString();
			string rawDescription = json.GetPropertyOrNull("raw_description")?.GetString();
			string build = json.GetPropertyOrNull("build")?.GetString();
			string kernelVersion = json.GetPropertyOrNull("kernel_version")?.GetString();
			bool? rooted = json.GetPropertyOrNull("rooted")?.GetBoolean();
			return new OperatingSystem
			{
				Name = name,
				Version = version,
				RawDescription = rawDescription,
				Build = build,
				KernelVersion = kernelVersion,
				Rooted = rooted
			};
		}
	}
}
