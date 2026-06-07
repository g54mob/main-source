using MPUIKIT;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkSelectionTooltipHelper : MonoBehaviour
{
	public UIFrame targetFrame;

	public TextMeshProUGUI selectionTitle;

	public TextMeshProUGUI selectionDescription;

	public Image selectionIcon;

	public MPImageBasic background;

	public MPImageBasic eliteBackground;

	public UIParentResizer sizer;

	public bool disableOnNullSelect;

	public GameObject tooltipParent;

	public MPImageBasic enemyNumberBg;

	public TextMeshProUGUI enemyNumberText;

	private TFUIEquippable currentEquippableElement;

	private TFUIEnemy currentEnemyElement;

	private TFUIIncomeDisplay currentIncomeDisplay;

	public void OnSelection()
	{
		if (targetFrame.CurrentSelection == null)
		{
			return;
		}
		TFUIEquippable tFUIEquippable = targetFrame.CurrentSelection as TFUIEquippable;
		TFUIEnemy tFUIEnemy = targetFrame.CurrentSelection as TFUIEnemy;
		TFUIIncomeDisplay tFUIIncomeDisplay = targetFrame.CurrentSelection as TFUIIncomeDisplay;
		if (tFUIEquippable == null && tFUIEnemy == null && tFUIIncomeDisplay == null)
		{
			if (disableOnNullSelect)
			{
				tooltipParent.SetActive(value: false);
			}
			return;
		}
		if ((bool)tooltipParent)
		{
			tooltipParent.SetActive(value: true);
		}
		currentEquippableElement = tFUIEquippable;
		currentEnemyElement = tFUIEnemy;
		currentIncomeDisplay = tFUIIncomeDisplay;
		UpdateTooltip();
	}

	public void OnFocus()
	{
		if (targetFrame.CurrentFocus == null)
		{
			OnSelection();
			return;
		}
		if ((bool)tooltipParent)
		{
			tooltipParent.SetActive(value: true);
		}
		TFUIEquippable tFUIEquippable = targetFrame.CurrentFocus as TFUIEquippable;
		TFUIEnemy tFUIEnemy = targetFrame.CurrentFocus as TFUIEnemy;
		TFUIIncomeDisplay tFUIIncomeDisplay = targetFrame.CurrentFocus as TFUIIncomeDisplay;
		if (tFUIEquippable == null && tFUIEnemy == null && tFUIIncomeDisplay == null)
		{
			if (disableOnNullSelect)
			{
				tooltipParent.SetActive(value: false);
			}
		}
		else
		{
			currentEquippableElement = tFUIEquippable;
			currentEnemyElement = tFUIEnemy;
			currentIncomeDisplay = tFUIIncomeDisplay;
			UpdateTooltip();
		}
	}

	public void UpdateTooltip()
	{
		if (currentEquippableElement == null && currentEnemyElement == null && currentIncomeDisplay == null)
		{
			return;
		}
		string text = "";
		string text2 = "";
		if (currentEquippableElement != null)
		{
			Equippable data = currentEquippableElement.Data;
			if (currentEquippableElement.Locked)
			{
				text = TextTranslator.Translate("Menu/Locked");
				text2 = data.GetLockedTooltip();
				selectionIcon.sprite = currentEquippableElement.IconImg.sprite;
			}
			else
			{
				text = TextTranslator.Translate(data.LOCIDENTIFIER_NAME);
				text2 = TextTranslator.Translate(data.LOCIDENTIFIER_DESCRIPTION);
				selectionIcon.sprite = data.icon;
			}
			background.OutlineColor = currentEquippableElement.GetDefaultOutlineColor();
			background.color = currentEquippableElement.GetBackgroundColor;
			selectionIcon.color = currentEquippableElement.GetIconColor;
			background.enabled = true;
			if (eliteBackground != null)
			{
				eliteBackground.enabled = false;
			}
			if (enemyNumberBg != null)
			{
				enemyNumberBg.gameObject.SetActive(value: false);
			}
		}
		else if (currentEnemyElement != null)
		{
			WaveEnemyInfo data2 = currentEnemyElement.Data;
			text = data2.enemyName;
			if (data2.eliteEnemy)
			{
				text = TextTranslator.Translate("Menu/Elite Prefix") + " " + text;
			}
			text2 = data2.enemyDescription;
			selectionIcon.sprite = data2.enemyIcon;
			background.OutlineColor = currentEnemyElement.GetDefaultOutlineColor();
			background.color = currentEnemyElement.GetBackgroundColor;
			background.enabled = !data2.eliteEnemy;
			if (eliteBackground != null)
			{
				eliteBackground.OutlineColor = background.OutlineColor;
				eliteBackground.color = background.color;
				eliteBackground.enabled = data2.eliteEnemy;
			}
			selectionIcon.color = currentEnemyElement.GetIconColor;
			if (enemyNumberBg != null)
			{
				enemyNumberBg.gameObject.SetActive(value: true);
				enemyNumberBg.color = background.OutlineColor;
				enemyNumberText.text = data2.enemyCount.ToString();
			}
		}
		else if (currentIncomeDisplay != null)
		{
			text = currentIncomeDisplay.GetTitle();
			text2 = currentIncomeDisplay.GetDescription();
			selectionIcon.sprite = currentIncomeDisplay.iconImg.sprite;
			background.OutlineColor = currentIncomeDisplay.GetDefaultOutlineColor();
			background.color = currentIncomeDisplay.backgroundImg.color;
			selectionIcon.color = currentIncomeDisplay.iconImg.color;
			if (enemyNumberBg != null)
			{
				enemyNumberBg.gameObject.SetActive(value: true);
				enemyNumberBg.color = background.OutlineColor;
				enemyNumberText.text = currentIncomeDisplay.CurrentIncome.ToString();
			}
		}
		selectionTitle.text = text;
		selectionDescription.text = text2;
		sizer.Trigger();
	}
}
