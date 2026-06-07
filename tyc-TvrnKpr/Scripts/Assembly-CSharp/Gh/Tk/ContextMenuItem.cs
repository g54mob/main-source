using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class ContextMenuItem
	{
		protected static Dictionary<string, GameObject> Prefabs;

		private string _prefabName;

		public string codexTooltip;

		public TooltipData TooltipData;

		public string tag;

		protected Action _execute;

		public Func<bool> canExecute;

		protected Func<bool> _isSelected;

		public Func<bool> _isVisible;

		public string Id { get; private set; }

		public static ContextMenuItem GenerateYesNoContextMenu(string label, Action<bool> callback, string yesLabel = "Yes", string noLabel = "No")
		{
			return null;
		}

		protected ContextMenuItem(string prefabName, Action execute = null, Func<bool> canExecute = null, Func<bool> isSelected = null, Func<bool> isVisible = null, TooltipData tooltipData = null)
		{
		}

		public void Execute()
		{
		}

		public bool CanExecute()
		{
			return false;
		}

		public bool IsSelected()
		{
			return false;
		}

		public bool IsVisible()
		{
			return false;
		}

		public virtual GameObject CreateGameObject(Transform where)
		{
			return null;
		}
	}
}
