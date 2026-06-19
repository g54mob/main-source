using System.Linq;
using System.Reflection;

namespace Sentry
{
	internal static class AttributeReader
	{
		public static string? TryGetProjectDirectory(Assembly assembly)
		{
			return assembly.GetCustomAttributes<AssemblyMetadataAttribute>().FirstOrDefault((AssemblyMetadataAttribute x) => x.Key == "Sentry.ProjectDirectory")?.Value;
		}
	}
}
