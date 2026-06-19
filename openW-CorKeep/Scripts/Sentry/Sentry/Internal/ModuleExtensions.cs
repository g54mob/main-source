using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Sentry.Internal
{
	internal static class ModuleExtensions
	{
		internal const string UnknownLocation = "<Unknown>";

		[UnconditionalSuppressMessage("SingleFile", "IL3002:Avoid calling members marked with 'RequiresAssemblyFilesAttribute' when publishing as a single-file", Justification = "Non-trimmable code is avoided at runtime")]
		public static string? GetNameOrScopeName(this Module module)
		{
			if (module?.Name != null && !module.Name.Equals("<Unknown>"))
			{
				return module?.Name;
			}
			return module?.ScopeName;
		}
	}
}
