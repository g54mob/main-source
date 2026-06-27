using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Popups
{
	public class GUI_HackingDecisionButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler
	{
		[SerializeField]
		private GameObject buttonOutline;

		public event Action<GUI_HackingDecisionButton> OnSelected;

		public event Action<GUI_HackingDecisionButton> OnClick;

		public void OnPointerEnter(PointerEventData eventData)
		{
			this.OnSelected?.Invoke(this);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			this.OnClick?.Invoke(this);
		}

		public void Select()
		{
			buttonOutline.SetActive(value: true);
		}

		public void Deselect()
		{
			buttonOutline.SetActive(value: false);
		}
	}
}
