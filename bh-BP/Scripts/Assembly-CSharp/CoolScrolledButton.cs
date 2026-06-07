using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoolScrolledButton : CoolButton, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	private ScrollRect _scrollRect;

	private bool _isDragging;

	private void OnTransformParentChanged()
	{
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnEndDrag(PointerEventData eventData)
	{
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public override void RunOnPointerUp(PointerEventData.InputButton btn)
	{
	}
}
