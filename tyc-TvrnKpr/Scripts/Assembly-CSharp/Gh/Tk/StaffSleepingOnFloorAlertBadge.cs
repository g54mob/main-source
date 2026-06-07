using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class StaffSleepingOnFloorAlertBadge : AlertBadgeBase
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Reset()
		{
		}

		private void Invalidate()
		{
		}

		private bool IsSleepingOnTheFloor(Sleep_Job target)
		{
			return false;
		}

		protected override bool UpdateInternal()
		{
			return false;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
