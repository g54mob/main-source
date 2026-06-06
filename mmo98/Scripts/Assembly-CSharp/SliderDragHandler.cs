using System;
using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
public class SliderDragHandler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	public bool IsDragging { get; private set; }

	public event Action OnPointerReleased;

	public void OnPointerDown(PointerEventData eventData)
	{
		IsDragging = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		IsDragging = false;
		this.OnPointerReleased?.Invoke();
	}
}
