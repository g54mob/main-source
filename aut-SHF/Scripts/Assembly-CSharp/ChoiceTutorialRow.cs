using TMPro;
using UI;
using UnityEngine;

public class ChoiceTutorialRow : ChoiceMenuButtonBase
{
	[SerializeField]
	private GameObject checkmark;

	[SerializeField]
	private TMP_Text title;

	[SerializeField]
	private GameObject highlightImage;

	public void Init(bool isClear, string title)
	{
	}

	public override void OnFocus()
	{
	}

	public override void OnBlur()
	{
	}
}
