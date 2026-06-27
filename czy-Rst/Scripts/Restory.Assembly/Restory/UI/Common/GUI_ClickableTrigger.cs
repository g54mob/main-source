using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Common
{
	public class GUI_ClickableTrigger : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public event Action OnClick;

		public event Action OnPointerEntered;

		public event Action OnPointerExited;

		public void OnPointerClick(PointerEventData eventData)
		{
			this.OnClick?.Invoke();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.OnPointerEntered?.Invoke();
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			this.OnPointerExited?.Invoke();
		}
	}
}
