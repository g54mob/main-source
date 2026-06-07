using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class InGameUpgradesMenuUI : HUDMenu
{
	[SerializeField]
	private Transform[] playerUpgradeUIContainers;

	[Header("Tier 2")]
	[SerializeField]
	private Transform tier2UpgradesContainer;

	[SerializeField]
	private Transform tier2UnlockUpgradeContainer;

	[SerializeField]
	private PlayerUpgradeUI tier2UnlockUpgrade;

	[Header("Tier 3")]
	[SerializeField]
	private Transform tier3UpgradesContainer;

	[SerializeField]
	private Transform tier3UnlockUpgradeContainer;

	[SerializeField]
	private PlayerUpgradeUI tier3UnlockUpgrade;

	[Header("Selected upgrade info")]
	[SerializeField]
	private GameObject selectedUpgradePanel;

	[SerializeField]
	private TextMeshProUGUI selectedUpgradeName;

	[SerializeField]
	private Image selectedUpgradeImage;

	[SerializeField]
	private TextMeshProUGUI selectedUpgradeDescription;

	[SerializeField]
	private GameObject selectedUpgradeCostGroup;

	[SerializeField]
	private TextMeshProUGUI selectedUpgradeCostText;

	[SerializeField]
	private GameObject buyUpgradeButton;

	[SerializeField]
	private AudioClip buyUpgradeSound;

	[SerializeField]
	private GameObject cantAffordText;

	[SerializeField]
	private GameObject alreadyOwnedObject;

	[SerializeField]
	private GameObject lockedObject;

	[SerializeField]
	private GameObject notAvailableInDemoText;

	private PlayerUpgradeUI selectedPlayerUpgradeUI;

	protected override void Awake()
	{
		base.Awake();
		Transform[] array = playerUpgradeUIContainers;
		for (int i = 0; i < array.Length; i++)
		{
			PlayerUpgradeUI[] componentsInChildren = array[i].GetComponentsInChildren<PlayerUpgradeUI>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].onPlayerUpgradeUIPressed += OnPlayerUpgradeUIPressed;
			}
		}
	}

	private void OnEnable()
	{
		UnselectPlayerUpgrade();
		UpdateTiersVisibility();
	}

	public override bool BackButtonPressed()
	{
		if (base.BackButtonPressed())
		{
			OnBackButtonPressed();
			return true;
		}
		return false;
	}

	private void SelectPlayerUpgrade(PlayerUpgradeUI playerUpgradeUI)
	{
		selectedPlayerUpgradeUI = playerUpgradeUI;
		selectedUpgradePanel.SetActive(value: true);
		selectedUpgradeCostGroup.SetActive(value: true);
		selectedUpgradeName.text = selectedPlayerUpgradeUI.PlayerUpgrade.DisplayName;
		selectedUpgradeDescription.text = selectedPlayerUpgradeUI.PlayerUpgrade.Description;
		selectedUpgradeCostText.text = selectedPlayerUpgradeUI.PlayerUpgrade.Cost + " <sprite=\"TMPSprites_coin\" index=0>";
		selectedUpgradeImage.sprite = selectedPlayerUpgradeUI.PlayerUpgrade.Icon;
		if (false && !playerUpgradeUI.availableInDemo)
		{
			notAvailableInDemoText.SetActive(value: true);
			buyUpgradeButton.gameObject.SetActive(value: false);
			lockedObject.SetActive(value: false);
			alreadyOwnedObject.SetActive(value: false);
			cantAffordText.SetActive(value: false);
		}
		else
		{
			notAvailableInDemoText.SetActive(value: false);
			buyUpgradeButton.gameObject.SetActive(value: false);
			lockedObject.SetActive(value: false);
			alreadyOwnedObject.SetActive(value: false);
			cantAffordText.SetActive(value: false);
			if (playerUpgradeUI.IsUnlocked())
			{
				alreadyOwnedObject.SetActive(value: true);
				selectedUpgradeCostGroup.SetActive(value: false);
			}
			else if (!playerUpgradeUI.AreRequiredUpgradesUnlocked())
			{
				lockedObject.SetActive(value: true);
			}
			else if (!playerUpgradeUI.CanAfford())
			{
				cantAffordText.SetActive(value: true);
			}
			else if (playerUpgradeUI.CanBuy())
			{
				buyUpgradeButton.gameObject.SetActive(value: true);
			}
		}
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void UnselectPlayerUpgrade()
	{
		selectedPlayerUpgradeUI = null;
		selectedUpgradePanel.SetActive(value: false);
	}

	private void RefundUpgrades()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().RefundUpgrades();
		UnselectPlayerUpgrade();
		Transform[] array = playerUpgradeUIContainers;
		for (int i = 0; i < array.Length; i++)
		{
			PlayerUpgradeUI[] componentsInChildren = array[i].GetComponentsInChildren<PlayerUpgradeUI>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].UpdateInfo();
			}
		}
		UpdateTiersVisibility();
		AudioSystem.Instance.PlaySound2DOneShot(buyUpgradeSound, AudioSystem.EAudioMixerGroup.UI);
	}

	private void OnPlayerUpgradeUIPressed(PlayerUpgradeUI playerUpgradeUI)
	{
		SelectPlayerUpgrade(playerUpgradeUI);
	}

	public void OnBuyUpgradeButtonPressed()
	{
		if (!selectedPlayerUpgradeUI.CanBuy())
		{
			return;
		}
		selectedPlayerUpgradeUI.UnlockUpgrade();
		buyUpgradeButton.gameObject.SetActive(value: false);
		selectedUpgradeCostGroup.SetActive(value: false);
		alreadyOwnedObject.SetActive(value: true);
		Transform[] array = playerUpgradeUIContainers;
		for (int i = 0; i < array.Length; i++)
		{
			PlayerUpgradeUI[] componentsInChildren = array[i].GetComponentsInChildren<PlayerUpgradeUI>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].UpdateInfo();
			}
		}
		UpdateTiersVisibility();
		AudioSystem.Instance.PlaySound2DOneShot(buyUpgradeSound, AudioSystem.EAudioMixerGroup.UI);
	}

	private void UpdateTiersVisibility()
	{
		if ((bool)tier2UnlockUpgrade)
		{
			bool flag = tier2UnlockUpgrade.IsUnlocked();
			tier2UnlockUpgradeContainer.gameObject.SetActive(!flag);
			tier2UpgradesContainer.gameObject.SetActive(flag);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
		if ((bool)tier3UnlockUpgrade)
		{
			bool flag2 = tier3UnlockUpgrade.IsUnlocked();
			tier3UnlockUpgradeContainer.gameObject.SetActive(!flag2);
			tier3UpgradesContainer.gameObject.SetActive(flag2);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
	}

	public void OnRefundUpgradesButtonPressed()
	{
		PlayerUpgradesManager playerUpgradesManager = LTFunctionLibrary.GetPlayerUpgradesManager();
		int num = Mathf.RoundToInt(FunctionLibrary.RoundToDecimals(playerUpgradesManager.RefundMultiplier, 2) * 100f);
		int totalUnlockedUpgradesCost = playerUpgradesManager.GetTotalUnlockedUpgradesCost(applyRefundMultiplier: true);
		string bodyMessage = string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_UpgradesMenu", "UI_UpgradesMenu_modalWindow_refund_message", null, FallbackBehavior.UseProjectSettings), num, totalUnlockedUpgradesCost);
		Action yesAction = delegate
		{
			RefundUpgrades();
		};
		base.Hud.ShowModalWindowTwoButtons(bodyMessage, "", null, yesAction, null);
	}

	public void OnBackButtonPressed()
	{
		if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Victory)
		{
			(base.Hud as LTHUD).ShowEndGameUI();
		}
		else if (LTFunctionLibrary.GetLTGameManager().GameState == LTGameManager.EGameState.Defeat)
		{
			(base.Hud as LTHUD).ShowGameOverUI();
		}
	}
}
