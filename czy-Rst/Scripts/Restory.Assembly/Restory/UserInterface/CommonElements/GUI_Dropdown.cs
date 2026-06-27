using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_Dropdown : Dropdown
	{
		[Serializable]
		public class BoolDropdownEvent : UnityEvent<Dropdown, bool>
		{
		}

		private bool isShown;

		[SerializeField]
		private BoolDropdownEvent isShownChanged;

		public bool IsShown
		{
			get
			{
				return isShown;
			}
			protected set
			{
				isShown = value;
				isShownChanged?.Invoke(this, isShown);
			}
		}

		public event UnityAction<Dropdown, bool> IsShownChanged
		{
			add
			{
				isShownChanged.AddListener(value);
			}
			remove
			{
				isShownChanged.RemoveListener(value);
			}
		}

		protected override void DestroyBlocker(GameObject blocker)
		{
			base.DestroyBlocker(blocker);
			IsShown = false;
		}

		protected override GameObject CreateBlocker(Canvas rootCanvas)
		{
			GameObject result = base.CreateBlocker(rootCanvas);
			IsShown = true;
			return result;
		}
	}
}
