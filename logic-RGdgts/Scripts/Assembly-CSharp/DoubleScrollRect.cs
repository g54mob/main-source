using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleScrollRect : ScrollRect
{
	private bool routeToParent;

	private void DoForParents<T>(Action<T> action) where T : IEventSystemHandler
	{
	}

	public override void OnInitializePotentialDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}
}
