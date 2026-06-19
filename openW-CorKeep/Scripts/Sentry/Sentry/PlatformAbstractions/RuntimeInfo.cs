using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Sentry.PlatformAbstractions
{
	internal static class RuntimeInfo
	{
		private static readonly Regex RuntimeParseRegex = new Regex("^(?<name>(?:[A-Za-z.]\\S*\\s?)*)(?:\\s|^|$)(?<version>\\d\\S*)?", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		internal static SentryRuntime GetRuntime()
		{
			SentryRuntime sentryRuntime = GetFromRuntimeInformation();
			if (sentryRuntime == null)
			{
				sentryRuntime = GetFromMonoRuntime();
			}
			if (sentryRuntime == null)
			{
				sentryRuntime = GetFromEnvironmentVariable();
			}
			return sentryRuntime.WithAdditionalProperties();
		}

		internal static SentryRuntime WithAdditionalProperties(this SentryRuntime runtime)
		{
			string version = runtime.Version ?? GetNetCoreVersion(runtime);
			return new SentryRuntime(runtime.Name, version, runtime.Raw);
		}

		internal static SentryRuntime? Parse(string? rawRuntimeDescription, string? name = null)
		{
			if (rawRuntimeDescription == null)
			{
				if (name != null)
				{
					return new SentryRuntime(name);
				}
				return null;
			}
			Match match = RuntimeParseRegex.Match(rawRuntimeDescription);
			if (match.Success)
			{
				return new SentryRuntime(name ?? ((match.Groups["name"].Value == string.Empty) ? null : match.Groups["name"].Value.Trim()), (match.Groups["version"].Value == string.Empty) ? null : match.Groups["version"].Value.Trim(), rawRuntimeDescription);
			}
			return new SentryRuntime(name, null, rawRuntimeDescription);
		}

		private static string? GetNetCoreVersion(SentryRuntime runtime)
		{
			string frameworkDescription = RuntimeInformation.FrameworkDescription;
			return RemovePrefixOrNull(frameworkDescription, ".NET Core") ?? RemovePrefixOrNull(frameworkDescription, ".NET Framework") ?? RemovePrefixOrNull(frameworkDescription, ".NET Native") ?? RemovePrefixOrNull(frameworkDescription, ".NET");
			static string? RemovePrefixOrNull(string? value, string prefix)
			{
				if (value == null || !value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
				{
					return null;
				}
				return value.Substring(prefix.Length);
			}
		}

		private static SentryRuntime? GetFromRuntimeInformation()
		{
			try
			{
				return Parse(RuntimeInformation.FrameworkDescription);
			}
			catch
			{
				return null;
			}
		}

		private static SentryRuntime? GetFromMonoRuntime()
		{
			if (!(Type.GetType("Mono.Runtime", throwOnError: false)?.GetMethod("GetDisplayName", BindingFlags.Static | BindingFlags.NonPublic)?.Invoke(null, null) is string rawRuntimeDescription))
			{
				return null;
			}
			return Parse(rawRuntimeDescription, "Mono");
		}

		private static SentryRuntime GetFromEnvironmentVariable()
		{
			Version version = Environment.Version;
			string text = ((version.Major != 1) ? version.ToString() : "");
			string version2 = text;
			return new SentryRuntime(".NET Framework", version2, "Environment.Version=" + version);
		}
	}
}
