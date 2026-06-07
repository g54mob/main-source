using MPUIKIT;
using UnityEngine;

public class TFUIEnumSelectorButton : ThronefallUIElement
{
	public MPImage targetGraphic;

	public Color defaultColor;

	public Color highlightColor;

	protected override void OnApply()
	{
		targetGraphic.color = highlightColor;
	}

	protected override void OnClear()
	{
		targetGraphic.color = defaultColor;
	}

	protected override void OnFocus()
	{
		targetGraphic.color = highlightColor;
	}

	protected override void OnFocusAndSelect()
	{
		targetGraphic.color = highlightColor;
	}

	protected override void OnHardStateSet(SelectionState selectionState)
	{
	}

	protected override void OnSelect()
	{
		targetGraphic.color = highlightColor;
	}
}
