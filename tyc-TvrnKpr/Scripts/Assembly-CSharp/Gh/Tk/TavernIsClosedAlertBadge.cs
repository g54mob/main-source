using UnityEngine.Scripting;

namespace Gh.Tk
{
	[Preserve]
	public class TavernIsClosedAlertBadge : AlertBadgeBase
	{
		protected override bool UpdateInternal()
		{
			return false;
		}
	}
}
