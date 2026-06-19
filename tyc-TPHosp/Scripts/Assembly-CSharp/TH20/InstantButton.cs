using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class InstantButton : Button
	{
		public Action OnDown;

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (base.interactable)
			{
				OnDown.InvokeSafe();
				if (base.onClick != null)
				{
					base.onClick.Invoke();
				}
			}
		}
	}
}
