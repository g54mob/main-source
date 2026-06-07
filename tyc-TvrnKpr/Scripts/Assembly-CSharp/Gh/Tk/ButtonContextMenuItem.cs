using System;
using UnityEngine;

namespace Gh.Tk
{
	public class ButtonContextMenuItem : ContextMenuItem
	{
		public string LabelKey;

		protected ButtonContextMenuItem(string labelKey, string prefabName, Action execute, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
			: base(null)
		{
		}

		public ButtonContextMenuItem(string labelKey, Action execute, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
			: base(null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
