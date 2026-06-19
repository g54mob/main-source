using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Reflection;

namespace Sentry
{
	public sealed class SdkVersion : ISentryJsonSerializable
	{
		private static readonly Lazy<SdkVersion> InstanceLazy = new Lazy<SdkVersion>(() => new SdkVersion
		{
			Name = "sentry.dotnet",
			Version = typeof(ISentryClient).Assembly.GetVersion()
		});

		internal static SdkVersion Instance => InstanceLazy.Value;

		internal ConcurrentBag<SentryPackage> InternalPackages { get; set; } = new ConcurrentBag<SentryPackage>();

		internal ConcurrentBag<string> Integrations { get; set; } = new ConcurrentBag<string>();

		public IEnumerable<SentryPackage> Packages => InternalPackages;

		public string? Name
		{
			get; [EditorBrowsable(EditorBrowsableState.Never)]
			set;
		}

		public string? Version
		{
			get; [EditorBrowsable(EditorBrowsableState.Never)]
			set;
		}

		public void AddPackage(string name, string version)
		{
			AddPackage(new SentryPackage(name, version));
		}

		internal void AddPackage(SentryPackage package)
		{
			InternalPackages.Add(package);
		}

		public void AddIntegration(string integration)
		{
			Integrations.Add(integration);
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteArrayIfNotEmpty("packages", InternalPackages.Distinct(), logger);
			writer.WriteArrayIfNotEmpty("integrations", Integrations.Distinct(), logger);
			writer.WriteStringIfNotWhiteSpace("name", Name);
			writer.WriteStringIfNotWhiteSpace("version", Version);
			writer.WriteEndObject();
		}

		public static SdkVersion FromJson(JsonElement json)
		{
			JsonElement? propertyOrNull = json.GetPropertyOrNull("packages");
			SentryPackage[] collection = (propertyOrNull.HasValue ? propertyOrNull.GetValueOrDefault().EnumerateArray().Select(SentryPackage.FromJson)
				.ToArray() : null) ?? Array.Empty<SentryPackage>();
			propertyOrNull = json.GetPropertyOrNull("integrations");
			string[] collection2 = (propertyOrNull.HasValue ? (from element in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select element.ToString() ?? "").ToArray() : null) ?? Array.Empty<string>();
			string name = json.GetPropertyOrNull("name")?.GetString() ?? "dotnet.unknown";
			string version = json.GetPropertyOrNull("version")?.GetString() ?? "0.0.0";
			return new SdkVersion
			{
				InternalPackages = new ConcurrentBag<SentryPackage>(collection),
				Integrations = new ConcurrentBag<string>(collection2),
				Name = name,
				Version = version
			};
		}
	}
}
