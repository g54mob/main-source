using System;
using UnityEngine;

namespace Gh.Tk
{
	public class GameItemStockContextMenuItem : ButtonContextMenuItem
	{
		private string _gameItemKey;

		public GameItemStockContextMenuItem(string labelKey, string gameItemKey, Action execute, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
			: base(null, null, null, null, null, null, null)
		{
		}

		public override GameObject CreateGameObject(Transform where)
		{
			return null;
		}

		private static GameObject GetGameItemIcon(GameItemTemplate itemTemplate)
		{
			return null;
		}
	}
}
