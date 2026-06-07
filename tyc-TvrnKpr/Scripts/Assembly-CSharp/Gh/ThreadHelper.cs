using Gh.Tk;
using UnityEngine.Scripting;

namespace Gh
{
	[InitializeOnGameStarted]
	public static class ThreadHelper
	{
		private static int _mainThreadId;

		public static bool IsMainThread => false;

		[Preserve]
		private static void OnGameStarted()
		{
		}
	}
}
