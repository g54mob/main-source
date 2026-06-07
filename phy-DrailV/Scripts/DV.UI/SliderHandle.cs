using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderHandle : MonoBehaviour
{
	public bool IsGrabbed { get; private set; }

	public event Action HandleGrabbed;

	public event Action HandleReleased;

	public void OnPointerDown(PointerEventData eventData)
	{
		this.HandleGrabbed?.Invoke();
		Debug.Log("Grabbed", this);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		this.HandleReleased?.Invoke();
		Debug.Log("Ungrabbed", this);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("BEGIN DRAG", this);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("end DRAG", this);
	}

	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("ON DRAG", this);
	}
}
