using UnityEngine;

namespace LaundryBear.PlatformServices
{
	public static class Utilities
	{
		public const string DELAY_SHUTDOWN_OFF_MAIN_THREAD_DEBUG_MSG = "Platform IO:: Calls which write to SaveData must be called from the main Unity thread (aka Qud UI thread). This is because you must notify the console on its main thread to not shutdown during a save operation or risk corruption. If necessary game-code can circumvent this restriction by: 1) using DelayShutdownScope on the main thread 2) make the I/O calls on any thread 3) then disposing DelayShutdownScope.";

		public static Platform GetCurrentPlatform()
		{
			return Application.platform switch
			{
				RuntimePlatform.IPhonePlayer => Platform.iOS, 
				RuntimePlatform.Android => Platform.Android, 
				RuntimePlatform.PS4 => Platform.PS4, 
				RuntimePlatform.Switch => Platform.Switch, 
				RuntimePlatform.OSXPlayer => Platform.MacOS, 
				RuntimePlatform.GameCoreXboxSeries => Platform.GameCoreXboxSeries, 
				RuntimePlatform.GameCoreXboxOne => Platform.GameCoreXboxOne, 
				RuntimePlatform.PS5 => Platform.PS5, 
				_ => Platform.Windows, 
			};
		}
	}
}
