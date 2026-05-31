using System;

namespace Codice.CmdRunner
{
	public class PlatformIdentifier
	{
		private static bool bIsWindowsInitialized;

		private static bool bIsWindows;

		private static bool bIsMacInitialized;

		private static bool bIsMac;

		public static bool IsWindows()
		{
			if (!bIsWindowsInitialized)
			{
				PlatformID platform = Environment.OSVersion.Platform;
				if ((uint)(platform - 1) <= 1u)
				{
					bIsWindows = true;
				}
				bIsWindowsInitialized = true;
			}
			return bIsWindows;
		}

		public static bool IsMac()
		{
			if (!bIsMacInitialized)
			{
				if (!IsWindows())
				{
					Version version = Environment.Version;
					int platform = (int)Environment.OSVersion.Platform;
					if ((version.Major >= 3 && version.Minor >= 5) || (IsRunningUnderMono() && version.Major >= 2 && version.Minor >= 2))
					{
						bIsMac = platform == 6;
					}
					else if (platform == 4 || platform == 128)
					{
						int major = Environment.OSVersion.Version.Major;
						bIsMac = 8 <= major && major <= 17;
					}
				}
				bIsMacInitialized = true;
			}
			return bIsMac;
		}

		private static bool IsRunningUnderMono()
		{
			return Type.GetType("Mono.Runtime") != null;
		}
	}
}
