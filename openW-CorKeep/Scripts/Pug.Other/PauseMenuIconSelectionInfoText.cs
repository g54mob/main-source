using System.Collections.Generic;
using UnityEngine;

public class PauseMenuIconSelectionInfoText : MonoBehaviour
{
	public PugText text;

	public List<Option> options = new List<Option>();

	private bool currentlyHasSelection;

	public void OnEnable()
	{
		currentlyHasSelection = false;
		text.gameObject.SetActive(value: false);
		text.MarkUIComponentAsDirty(render: true);
	}

	private void Update()
	{
		UpdateText();
	}

	public void UpdateText()
	{
		bool flag = false;
		bool flag2 = false;
		foreach (Option option in options)
		{
			if (option.option.IsSelected())
			{
				flag = true;
				string mTerm = option.on.mTerm;
				if (!option.option.IsOn())
				{
					mTerm = option.off.mTerm;
				}
				if (text.GetText() != mTerm)
				{
					text.SetText(mTerm);
					flag2 = true;
				}
				break;
			}
		}
		if (currentlyHasSelection != flag || flag2)
		{
			currentlyHasSelection = flag;
			text.MarkUIComponentAsDirty(render: true);
			text.gameObject.SetActive(flag);
		}
		if (flag2)
		{
			text.Render();
		}
	}
}
