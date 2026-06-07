using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollRectNoDragging : ScrollRect
{
	protected override void Start()
	{
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
	}

	public override void OnDrag(PointerEventData eventData)
	{
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
	}

	public void ResizeToFitContent()
	{
	}
}
