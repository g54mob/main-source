using MPUIKIT;
using UnityEngine;

public class TFUICheckboxMouseCatcher : ThronefallUIElement
{
	public Checkbox target;

	public MPImageBasic targetGraphic;

	public Color defaultColor;

	public Color highlightColor;

	protected override void OnApply()
	{
		target.Toggle();
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
