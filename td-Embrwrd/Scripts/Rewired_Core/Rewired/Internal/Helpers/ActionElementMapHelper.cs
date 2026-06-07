using System.ComponentModel;

namespace Rewired.Internal.Helpers
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class ActionElementMapHelper
	{
		public static bool TryGetSplitAxisMaps(ActionElementMap fullAxisMap, out ActionElementMap negativeResult, out ActionElementMap positiveResult)
		{
			negativeResult = null;
			positiveResult = null;
			return false;
		}
	}
}
