using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PG
{
	public class ButtonCustom : Button
	{
		public bool PointerEnter { get; private set; }

		public bool Pressed { get; private set; }

		public Action OnPointerEnterAction { get; set; }

		public Action OnPointerExitAction { get; set; }

		public Action OnPointerDownAction { get; set; }

		public Action OnPointerUpAction { get; set; }

		public override void OnPointerEnter(PointerEventData eventData)
		{
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
