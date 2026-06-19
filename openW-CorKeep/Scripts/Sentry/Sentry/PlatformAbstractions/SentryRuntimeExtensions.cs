using System;
using System.ComponentModel;

namespace Sentry.PlatformAbstractions
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class SentryRuntimeExtensions
	{
		public static bool IsNetFx(this SentryRuntime runtime)
		{
			return runtime.StartsWith(".NET Framework");
		}

		public static bool IsNetCore(this SentryRuntime runtime)
		{
			if (!runtime.StartsWith(".NET Core"))
			{
				if (runtime.StartsWith(".NET"))
				{
					return !runtime.StartsWith(".NET Framework");
				}
				return false;
			}
			return true;
		}

		public static bool IsMono(this SentryRuntime runtime)
		{
			return runtime.StartsWith("Mono");
		}

		internal static bool IsBrowserWasm(this SentryRuntime runtime)
		{
			return runtime.Identifier == "browser-wasm";
		}

		private static bool StartsWith(this SentryRuntime? runtime, string runtimeName)
		{
			if (runtime == null || runtime.Name?.StartsWith(runtimeName, StringComparison.OrdinalIgnoreCase) != true)
			{
				if (runtime == null)
				{
					return false;
				}
				return runtime.Raw?.StartsWith(runtimeName, StringComparison.OrdinalIgnoreCase) == true;
			}
			return true;
		}
	}
}
