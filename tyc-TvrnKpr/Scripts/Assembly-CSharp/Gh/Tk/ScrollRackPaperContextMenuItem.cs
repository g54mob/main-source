using System;
using UnityEngine;

namespace Gh.Tk
{
	public class ScrollRackPaperContextMenuItem : ButtonContextMenuItem
	{
		private string _icon;

		private int _cost;

		public ScrollRackPaperContextMenuItem(string labelKey, int cost, string icon, Action execute, Func<bool> canExecute, Func<bool> isSelected)
			: base(null, null, null, null, null, null, null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
