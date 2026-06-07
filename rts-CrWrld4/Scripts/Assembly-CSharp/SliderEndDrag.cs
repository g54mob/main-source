using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SliderEndDrag : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
{
	[Serializable]
	public class OnSliderEndDragEvent : UnityEvent<float>
	{
	}

	[Serializable]
	public class OnSliderBeginDragEvent : UnityEvent<float>
	{
	}

	public OnSliderEndDragEvent onSliderEndDrag;

	public OnSliderBeginDragEvent onSliderBeginDrag;

	public void OnPointerDown(PointerEventData data)
	{
	}

	public void OnPointerUp(PointerEventData data)
	{
	}
}
