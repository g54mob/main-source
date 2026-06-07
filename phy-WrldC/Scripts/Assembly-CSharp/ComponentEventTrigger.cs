using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComponentEventTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public event Action<PointerEventData> OnPointerEnterEvent;

	public event Action<PointerEventData> OnPointerExitEvent;

	public void OnPointerEnter(PointerEventData eventData)
	{
		this.OnPointerEnterEvent?.Invoke(eventData);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		this.OnPointerExitEvent?.Invoke(eventData);
	}
}
