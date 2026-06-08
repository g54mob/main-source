using UnityEngine;

namespace Timberborn.PlatformUtilities
{
	public static class ApplicationPlatform
	{
		public static bool IsMacOS()
		{
			RuntimePlatform platform = Application.platform;
			return platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer;
		}

		public static bool IsWindows()
		{
			RuntimePlatform platform = Application.platform;
			return platform == RuntimePlatform.WindowsEditor || platform == RuntimePlatform.WindowsPlayer;
		}
	}
}
