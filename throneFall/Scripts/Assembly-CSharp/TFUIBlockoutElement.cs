using System;

public class TFUIBlockoutElement : ThronefallUIElement
{
	public ThronefallUIElement target;

	private void OnEnable()
	{
		botNav = target.botNav;
		topNav = target.topNav;
		rightNav = target.rightNav;
		leftNav = target.leftNav;
	}

	protected override void OnApply()
	{
		target.Apply();
	}

	protected override void OnClear()
	{
		target.Clear();
	}

	protected override void OnFocus()
	{
		target.Focus();
	}

	protected override void OnFocusAndSelect()
	{
		target.FocusAndSelect();
	}

	protected override void OnHardStateSet(SelectionState selectionState)
	{
		throw new NotImplementedException();
	}

	protected override void OnSelect()
	{
		target.Select();
	}
}
