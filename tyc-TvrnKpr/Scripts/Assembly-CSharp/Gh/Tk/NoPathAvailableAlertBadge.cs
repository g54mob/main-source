using System.Collections.Generic;

namespace Gh.Tk
{
	public class NoPathAvailableAlertBadge : AlertBadgeBase
	{
		protected override bool UpdateInternal()
		{
			return false;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}

		private IEnumerable<Actor> GetActorsWithNoPathIssues()
		{
			return null;
		}
	}
}
