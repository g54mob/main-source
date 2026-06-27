using System;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Views
{
	public class ToggleButton : Button
	{
		[SerializeField]
		private bool isSelected;

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				if (isSelected != value)
				{
					isSelected = value;
					this.IsSelectedChanged?.Invoke(isSelected);
				}
			}
		}

		public event Action<bool> IsSelectedChanged;
	}
}
