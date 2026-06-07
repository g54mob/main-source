using System.Collections.Generic;

namespace Gh.Tk
{
	public class StaffFlashMessageAlertBadge : AlertBadgeBase
	{
		protected IEnumerable<Staff> GetStaffWithFlashMessage()
		{
			return null;
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
