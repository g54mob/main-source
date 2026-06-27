using System;
using TMPro;
using UnityEngine.EventSystems;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_RestoryDropdown : TMP_Dropdown
	{
		public event Action OnDropdownMenuOpen;

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			this.OnDropdownMenuOpen?.Invoke();
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
			this.OnDropdownMenuOpen?.Invoke();
		}
	}
}
