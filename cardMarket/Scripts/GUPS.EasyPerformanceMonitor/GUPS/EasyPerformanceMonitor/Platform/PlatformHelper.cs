using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Platform
{
	public static class PlatformHelper
	{
		public static EPlatform GetCurrentPlatform()
		{
			switch (Application.platform)
			{
			case RuntimePlatform.OSXEditor:
			case RuntimePlatform.OSXPlayer:
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.WindowsEditor:
			case RuntimePlatform.LinuxPlayer:
			case RuntimePlatform.LinuxEditor:
				return EPlatform.Desktop;
			case RuntimePlatform.IPhonePlayer:
			case RuntimePlatform.Android:
				return EPlatform.Mobile;
			case RuntimePlatform.PS4:
			case RuntimePlatform.XboxOne:
			case RuntimePlatform.Switch:
				return EPlatform.Console;
			default:
				return EPlatform.Unknown;
			}
		}
	}
}
