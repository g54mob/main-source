using UnityEngine.Scripting;

namespace Gh.Tk
{
	[Preserve]
	public class NoTaproomAllowsDrinksAlertBadge : AlertBadgeBase
	{
		protected override bool UpdateInternal()
		{
			return false;
		}
	}
}
