using UnityEngine.Scripting;

namespace Gh.Tk
{
	[Preserve]
	public class StaffHappinessLowAlertBadge : AlertBadgeBase
	{
		private const string _staffHappinessHandbookEntry = "hb-staff-happiness";

		protected override bool UpdateInternal()
		{
			return false;
		}

		private Staff[] GetUnhappyStaff()
		{
			return null;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
