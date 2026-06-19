using System;

namespace Sentry.PlatformAbstractions
{
	public class FrameworkInstallation
	{
		public string? ShortName { get; set; }

		public Version? Version { get; set; }

		public int? ServicePack { get; set; }

		public FrameworkProfile? Profile { get; set; }

		public int? Release { get; set; }

		public override string ToString()
		{
			Version? version = Version;
			if ((object)version == null || version.Build <= 0)
			{
				return $"{Version?.Major ?? 0}.{Version?.Minor ?? 0}";
			}
			return $"{Version.Major}.{Version.Minor}.{Version.Build}";
		}
	}
}
