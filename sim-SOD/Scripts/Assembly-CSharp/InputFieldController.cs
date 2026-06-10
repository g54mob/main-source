using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public ButtonController inputNameButton;

	public ButtonController selectButton;

	public TextMeshProUGUI titleText;

	public Image checkbox;

	public Sprite tickSprite;

	public Sprite crossSprite;

	public Sprite emptySprite;

	public ProgressBarController progress;

	public RectTransform rewardedGraphic;

	[Header("State")]
	public bool resultsMode;

	public Case belongsToCase;

	public Case.ResolveQuestion question;

	[NonSerialized]
	public Evidence inputtedEvidence;

	public Color invalidInputColor;

	public Color validInputColor;

	public void Setup(Case.ResolveQuestion newQuestion, Case newCase, bool newResultsMode = false)
	{
	}

	public void ProgressChange(Case.ResolveQuestion q)
	{
	}

	public void OpenTextInputButton()
	{
	}

	public void OnInputTextPopupCancel()
	{
	}

	public void OnInputTextPopupConfirm()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnInputEdited()
	{
	}

	public void UpdateCheckbox()
	{
	}

	public void OnSelectButton()
	{
	}

	public void SetSelectedEvidence(Evidence newI)
	{
	}

	public void OnPick(Evidence newSelection, List<Evidence.DataKey> keys)
	{
	}
}
