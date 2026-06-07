using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUIFrameHelper : MonoBehaviour
{
	public static int CurrentSelectionIndex;

	public UIFrame frame;

	public GridLayoutGroup choicesParent;

	public TFUIUpgradeChoice upgradeChoiceButtonPrefab;

	public TextMeshProUGUI choiceTitle;

	public TextMeshProUGUI choiceDescription;

	private List<TFUIUpgradeChoice> choices = new List<TFUIUpgradeChoice>();

	public void OnShow()
	{
		choices.Clear();
		foreach (Transform item in choicesParent.transform)
		{
			Object.Destroy(item.gameObject);
		}
		if (ChoiceManager.instance.availableChoices.Count > 4)
		{
			choicesParent.constraintCount = 3;
		}
		else
		{
			choicesParent.constraintCount = 4;
		}
		foreach (Choice availableChoice in ChoiceManager.instance.availableChoices)
		{
			AddChoiceTFUI(choicesParent, availableChoice);
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		RecomputeNavigation();
	}

	private void AddChoiceTFUI(LayoutGroup parent, Choice _choice)
	{
		TFUIUpgradeChoice component = Object.Instantiate(upgradeChoiceButtonPrefab, parent.transform).GetComponent<TFUIUpgradeChoice>();
		component.SetData(_choice);
		choices.Add(component);
	}

	private void RecomputeNavigation()
	{
		int constraintCount = choicesParent.constraintCount;
		for (int i = 0; i < choices.Count; i++)
		{
			TFUIUpgradeChoice tFUIUpgradeChoice = choices[i];
			if (i <= 0)
			{
				tFUIUpgradeChoice.leftNav = choices[choices.Count - 1];
			}
			else
			{
				tFUIUpgradeChoice.leftNav = choices[i - 1];
			}
			if (i >= choices.Count - 1)
			{
				tFUIUpgradeChoice.rightNav = choices[0];
			}
			else
			{
				tFUIUpgradeChoice.rightNav = choices[i + 1];
			}
			if (choices.Count <= constraintCount)
			{
				continue;
			}
			int num = i - constraintCount;
			int num2 = i + constraintCount;
			if (num < 0)
			{
				num = choices.Count - Mathf.Abs(num);
				if (num < 0)
				{
					num = choices.Count - 1;
				}
			}
			if (num2 >= choices.Count)
			{
				num2 -= choices.Count;
				if (num2 >= choices.Count)
				{
					num2 = 0;
				}
			}
			tFUIUpgradeChoice.topNav = choices[num];
			tFUIUpgradeChoice.botNav = choices[num2];
		}
		frame.firstSelected = choices[0];
	}

	public void UpdateSelectedChoice()
	{
		TFUIUpgradeChoice tFUIUpgradeChoice = null;
		if (frame.CurrentFocus != null)
		{
			tFUIUpgradeChoice = frame.CurrentFocus as TFUIUpgradeChoice;
		}
		if (tFUIUpgradeChoice == null && frame.CurrentSelection != null)
		{
			tFUIUpgradeChoice = frame.CurrentSelection as TFUIUpgradeChoice;
		}
		if (tFUIUpgradeChoice != null)
		{
			if (tFUIUpgradeChoice.Data.disabledInThisMode)
			{
				choiceTitle.text = TextTranslator.Translate("Menu/Locked");
				choiceDescription.text = TextTranslator.Translate("Menu/Locked Choice Mini Mode Description");
			}
			else if (!tFUIUpgradeChoice.Locked)
			{
				BuildSlot currentOriginBuildSlot = ChoiceManager.instance.currentOriginBuildSlot;
				choiceTitle.text = TextTranslator.Translate(currentOriginBuildSlot.GET_LOCIDENTIFIER_CHOICENAME(tFUIUpgradeChoice.Data));
				choiceDescription.text = TextTranslator.Translate(currentOriginBuildSlot.GET_LOCIDENTIFIER_CHOICEDESCRIPTION(tFUIUpgradeChoice.Data));
			}
			else
			{
				choiceTitle.text = TextTranslator.Translate("Menu/Locked");
				choiceDescription.text = tFUIUpgradeChoice.Data.requiresUnlocked.GetLockedTooltip();
			}
		}
		for (int i = 0; i < choices.Count; i++)
		{
			if (choices[i] == tFUIUpgradeChoice)
			{
				CurrentSelectionIndex = i;
			}
		}
	}

	public void OnApply()
	{
		TFUIUpgradeChoice tFUIUpgradeChoice = frame.LastApplied as TFUIUpgradeChoice;
		if (!(tFUIUpgradeChoice == null) && !tFUIUpgradeChoice.Locked)
		{
			ChoiceManager.instance.choiceToReturn = tFUIUpgradeChoice.Data;
			UIFrameManager.instance.CloseActiveFrame();
		}
	}
}
