using System;

namespace Gh.Tk
{
	public class SelectionButtonContextMenuItem : ButtonContextMenuItem
	{
		protected SelectionButtonContextMenuItem(string labelKey, string prefabName, Action execute, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
			: base(null, null, null, null, null, null, null)
		{
		}

		public SelectionButtonContextMenuItem(string labelKey, Action execute, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
			: base(null, null, null, null, null, null, null)
		{
		}
	}
}
