using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomScrollRect : ScrollRect
{
	public bool rightMouseScroll;

	public bool leftMouseScroll;

	public bool isScrolling;

	public void ScrollZoom(Vector2 deltaPos)
	{
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public void SetAnchorPos(Vector2 position)
	{
	}
}
