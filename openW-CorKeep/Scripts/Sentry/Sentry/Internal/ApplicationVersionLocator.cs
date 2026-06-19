using System.Reflection;
using Sentry.Reflection;

namespace Sentry.Internal
{
	internal static class ApplicationVersionLocator
	{
		internal static string? GetCurrent(Assembly? asm)
		{
			if ((object)asm == null)
			{
				return null;
			}
			string name = asm.GetName().Name;
			string version = asm.GetVersion();
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(version))
			{
				return null;
			}
			if (PolyfillExtensions.Contains(version, '@'))
			{
				return version;
			}
			return name + "@" + version;
		}
	}
}
