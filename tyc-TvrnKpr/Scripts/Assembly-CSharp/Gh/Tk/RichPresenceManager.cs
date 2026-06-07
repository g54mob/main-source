using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public static class RichPresenceManager
	{
		private static (string, string) _lastState;

		private const string _starsRepeated = "⭐⭐⭐⭐⭐";

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void UpdateState()
		{
		}

		private static (string, string) GetRichPresenceStateAndDetails()
		{
			return default((string, string));
		}

		public static void Init()
		{
		}

		public static void Shutdown()
		{
		}
	}
}
