using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class StaffSicknessAlertBadge : AlertBadgeBase
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

		protected override bool UpdateInternal()
		{
			return false;
		}

		private IEnumerable<Staff> GetSickStaff()
		{
			return null;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
