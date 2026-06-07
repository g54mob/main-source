using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class GameModifierAlertBadge : AlertBadgeBase
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		public static void Reset()
		{
		}

		public override void LateRestoreState(IDataStore data)
		{
		}

		private void Invalidate()
		{
		}

		protected override bool UpdateInternal()
		{
			return false;
		}
	}
}
