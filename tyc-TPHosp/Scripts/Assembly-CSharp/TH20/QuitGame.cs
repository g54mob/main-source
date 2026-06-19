#define LOG_LEVEL_VERBOSE
using UnityEngine;

namespace TH20
{
	public static class QuitGame
	{
		public static bool applicationQuitCalled { get; private set; }

		public static void Quit()
		{
			Logging.AlwaysLog(LogChannels.GameFlow, "Quitting");
			applicationQuitCalled = true;
			Application.Quit();
		}
	}
}
