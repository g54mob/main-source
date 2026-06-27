using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Views.DayEndWindow
{
	public class GUI_StampingStartTrigger : Selectable
	{
		public event Action OnTriggered;

		public event Action OnHighlighted;

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			this.OnHighlighted?.Invoke();
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			this.OnTriggered?.Invoke();
		}
	}
}
