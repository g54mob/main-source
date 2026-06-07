using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropDownItemMouseEvents : MonoBehaviour
{
	[Serializable]
	public class OnPointerEnterEvent : UnityEvent<string>
	{
	}

	[Serializable]
	public class OnPointerExitEvent : UnityEvent<string>
	{
	}

	public Text text;

	public OnPointerEnterEvent onPointerEnter;

	public OnPointerExitEvent onPointerExit;

	public void OnMouseEnterDropdownItem(BaseEventData bed)
	{
	}

	public void OnMouseExitDropdownItem(BaseEventData bed)
	{
	}
}
