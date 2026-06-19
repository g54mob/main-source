namespace Sentry.PlatformAbstractions
{
	internal static class FrameworkInstallationExtensions
	{
		internal static string? GetVersionNumber(this FrameworkInstallation? frameworkInstall)
		{
			object obj = frameworkInstall?.ShortName;
			if (obj == null)
			{
				if (!(frameworkInstall?.Version != null))
				{
					return null;
				}
				obj = $"v{frameworkInstall.Version}";
			}
			return (string?)obj;
		}
	}
}
