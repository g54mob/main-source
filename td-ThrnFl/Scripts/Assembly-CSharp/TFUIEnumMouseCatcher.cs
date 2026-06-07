using System.Collections.Generic;
using UnityEngine;

public class TFUIEnumMouseCatcher : ThronefallUIElement
{
	public List<ThronefallUIElement> focusWhitelist = new List<ThronefallUIElement>();

	public GameObject buttons;

	private UIFrame targetFrame;

	protected override void OnApply()
	{
	}

	protected override void OnClear()
	{
	}

	protected override void OnFocus()
	{
		buttons.SetActive(value: true);
		targetFrame.onNewFocus.AddListener(ListenForUnfocus);
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

	private void Start()
	{
		targetFrame = GetComponentInParent<UIFrame>();
	}

	private void ListenForUnfocus()
	{
		if (!(targetFrame.CurrentFocus == this) && !focusWhitelist.Contains(targetFrame.CurrentFocus))
		{
			buttons.SetActive(value: false);
			targetFrame.onNewFocus.RemoveListener(ListenForUnfocus);
		}
	}
}
