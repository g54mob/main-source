using UnityEngine;

public class TFUIScrollBar : ThronefallUIElement
{
	public ScrollArea target;

	private bool focussed;

	public override bool dragable => true;

	protected override void OnApply()
	{
	}

	protected override void OnClear()
	{
		focussed = false;
	}

	protected override void OnFocus()
	{
		focussed = true;
	}

	protected override void OnFocusAndSelect()
	{
	}

	protected override void OnHardStateSet(SelectionState selectionState)
	{
	}

	protected override void OnSelect()
	{
	}

	public override void OnDragStart()
	{
		target.OnDragStart();
	}

	public override void OnDrag(Vector2 mousePosition)
	{
		target.OnDrag(mousePosition);
	}

	public override void OnDragEnd()
	{
		target.OnDragEnd();
	}
}
