using UnityEngine;
using UnityEngine.EventSystems;

public class ResizePanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
	public InfoWindow controller;

	public bool resizingActive;

	private Vector2 currentPointerPosition;

	private Vector2 previousPointerPosition;

	public Vector2 pivot;

	public void OnPointerDown(PointerEventData data)
	{
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	private void OnDisable()
	{
	}

	public void OnEndDrag(PointerEventData data)
	{
	}

	public void OnDrag(PointerEventData data)
	{
	}

	private void OnDestroy()
	{
	}
}
