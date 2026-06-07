using UnityEngine.Scripting;

namespace Gh.Tk
{
	[Preserve]
	public class TavernTemporarilyClosedAlertBadge : AlertBadgeBase
	{
		protected override bool UpdateInternal()
		{
			return false;
		}
	}
}
