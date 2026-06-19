using System.ComponentModel;
using System.Reflection;

namespace Sentry.Reflection
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class AssemblyExtensions
	{
		public static SdkVersion GetNameAndVersion(this Assembly asm)
		{
			return new SdkVersion
			{
				Name = asm.GetName().Name,
				Version = asm.GetVersion()
			};
		}

		internal static string? GetVersion(this Assembly assembly)
		{
			try
			{
				string text = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
				if (!string.IsNullOrEmpty(text))
				{
					return text;
				}
			}
			catch
			{
			}
			return assembly.GetName().Version?.ToString();
		}
	}
}
