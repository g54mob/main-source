using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSEipix.View.UI
{
	public class CustomUiButton : Button
	{
		public event Action<CustomUiButton> OnUnInteractableClick;

		public void ClearClickEvents()
		{
			this.OnUnInteractableClick = null;
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
			if (!IsInteractable())
			{
				this.OnUnInteractableClick?.Invoke(this);
			}
			else if (eventData.button == PointerEventData.InputButton.Right)
			{
				base.onClick?.Invoke();
			}
		}
	}
}
