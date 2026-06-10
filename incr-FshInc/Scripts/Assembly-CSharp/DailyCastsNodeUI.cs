using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyCastsNodeUI : SkillNodeUI
{
	[Header("Daily Casts Specific")]
	public GameObject lockedPanel;

	public GameObject unlockedPanel;

	public Button minusButton;

	public Button plusButton;

	public TMP_Text castAmountText;

	protected override void Initialize()
	{
		base.Initialize();
		if (minusButton != null)
		{
			minusButton.onClick.AddListener(MinusClicked);
		}
		if (plusButton != null)
		{
			plusButton.onClick.AddListener(PlusClicked);
		}
	}

	public override void UpdateVisualState()
	{
		base.UpdateVisualState();
		if (skillData == null || !Application.isPlaying)
		{
			return;
		}
		if (SkillManager.Instance.IsSkillUnlocked(skillData.ID))
		{
			if (lockedPanel != null)
			{
				lockedPanel.SetActive(value: false);
			}
			if (unlockedPanel != null)
			{
				unlockedPanel.SetActive(value: true);
			}
			UpdateCastAmountText();
		}
		else
		{
			if (lockedPanel != null)
			{
				lockedPanel.SetActive(value: true);
			}
			if (unlockedPanel != null)
			{
				unlockedPanel.SetActive(value: false);
			}
		}
	}

	private void UpdateCastAmountText()
	{
		int chosenMaxEnergy = PlayerManager.GetChosenMaxEnergy();
		int num = ((PlayerStats.Instance != null) ? PlayerStats.Instance.absoluteMaxDailyCasts : 10);
		if (castAmountText != null)
		{
			castAmountText.text = chosenMaxEnergy.ToString();
		}
		if (minusButton != null)
		{
			minusButton.interactable = chosenMaxEnergy > 1;
		}
		if (plusButton != null)
		{
			plusButton.interactable = chosenMaxEnergy < num;
		}
	}

	private void MinusClicked()
	{
		int chosenMaxEnergy = PlayerManager.GetChosenMaxEnergy();
		if (chosenMaxEnergy > 1)
		{
			PlayerManager.SetChosenMaxEnergy(chosenMaxEnergy - 1);
			UpdateCastAmountText();
			SoundManager.PlaySound("Click");
		}
	}

	private void PlusClicked()
	{
		int chosenMaxEnergy = PlayerManager.GetChosenMaxEnergy();
		int num = ((PlayerStats.Instance != null) ? PlayerStats.Instance.absoluteMaxDailyCasts : 10);
		if (chosenMaxEnergy < num)
		{
			PlayerManager.SetChosenMaxEnergy(chosenMaxEnergy + 1);
			UpdateCastAmountText();
			SoundManager.PlaySound("Click");
		}
	}
}
