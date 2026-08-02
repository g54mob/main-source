using System.Collections.Generic;

namespace GRP
{
	public class SnapController
	{
		public PartView lastPart;

		public SnapResult lastSnap;

		public List<SnapResult> lastResults;

		public bool DoSnap(PartView partView, bool sticky, out SnapResult result, out List<SnapResult> results)
		{
			result = default(SnapResult);
			results = null;
			return false;
		}

		public bool Snap(PartView partView, bool sticky)
		{
			return false;
		}

		public bool Snap(PartView partView, bool sticky, out SnapResult result, out List<SnapResult> results)
		{
			result = default(SnapResult);
			results = null;
			return false;
		}

		public void CancelSticky()
		{
		}
	}
}
