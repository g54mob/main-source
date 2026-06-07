using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	public Action<PointerEventData> beginDragAction;

	public Action<PointerEventData> endDragAction;

	private static Vector2? screenCenter;

	private void Start()
	{
		if (!screenCenter.HasValue)
		{
			screenCenter = new Vector2(Screen.width, Screen.height) / 2f;
		}
	}

	public virtual void OnBeginDrag(PointerEventData eventData)
	{
		if (beginDragAction != null)
		{
			beginDragAction(eventData);
		}
	}

	public virtual void OnDrag(PointerEventData pointerEventData)
	{
		Camera main = Camera.main;
		Vector2 delta = pointerEventData.delta;
		Vector2? vector = screenCenter;
		Vector3 vector2 = main.ScreenToWorldPoint((delta + vector).Value);
		vector2.z = 0f;
		base.transform.position += vector2;
	}

	public virtual void OnEndDrag(PointerEventData eventData)
	{
		if (endDragAction != null)
		{
			endDragAction(eventData);
		}
	}
}
