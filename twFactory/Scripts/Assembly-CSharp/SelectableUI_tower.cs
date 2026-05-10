using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SelectableUI_tower : SelectableUI
{
	[SerializeField]
	private TextMeshProUGUI towerNameText;

	[Header("Stats")]
	[SerializeField]
	private TextMeshProUGUI damageStatText;

	[SerializeField]
	private TextMeshProUGUI attackSpeedStatText;

	[SerializeField]
	private TextMeshProUGUI rangeStatText;

	[SerializeField]
	private GameObject enemyTypeGroundGO;

	[SerializeField]
	private GameObject enemyTypeFlyingGO;

	[Header("Damage multipliers")]
	[SerializeField]
	private GameObject damageMultiplierLowPrefab;

	[SerializeField]
	private GameObject damageMultiplierNormalPrefab;

	[SerializeField]
	private GameObject damageMultiplierHighPrefab;

	[SerializeField]
	private Transform damageMultiplierHealthContainer;

	[SerializeField]
	private Transform damageMultiplierArmorContainer;

	[SerializeField]
	private Transform damageMultiplierShieldContainer;

	[Header("Target priority")]
	[SerializeField]
	private Image firstTargetProviderImage;

	[SerializeField]
	private Image secondTargetProviderImage;

	[SerializeField]
	private UIList targetProvidersList;

	[SerializeField]
	private ContextWindowUI targetProvidersContextWindow;

	[Header("Keep target")]
	[SerializeField]
	private Toggle keepTargetToggle;

	[Header("Effects")]
	[SerializeField]
	private UIList effectsList;

	[Header("Tower Upgrades")]
	[SerializeField]
	private UIList towerUpgradesList;

	[SerializeField]
	private FillBar towerUpgradeFillBar;

	[SerializeField]
	private TextMeshProUGUI towerUpgradePercentageText;

	[SerializeField]
	private Image towerUpgradedImage;

	[SerializeField]
	private Color towerUpgradeFullColor;

	[Header("Gems")]
	[SerializeField]
	private UIList equippedGemsList;

	[SerializeField]
	private UIList gemsList;

	[SerializeField]
	private ContextWindowUI gemsContextWindow;

	[SerializeField]
	private GameObject noGemsObject;

	[Header("Tooltips")]
	[SerializeField]
	private TooltipComponent_text validEnemyTypesTooltip;

	[SerializeField]
	private TooltipComponent_text damageMultiplierHealthTooltip;

	[SerializeField]
	private TooltipComponent_text damageMultiplierArmorTooltip;

	[SerializeField]
	private TooltipComponent_text damageMultiplierShieldTooltip;

	[SerializeField]
	private TooltipComponent_text firstTargetProviderTooltip;

	[SerializeField]
	private TooltipComponent_text secondTargetProviderTooltip;

	[SerializeField]
	private TooltipComponent_text sellTooltip;

	[Header("Misc")]
	[SerializeField]
	private WorldObjectUI towerTargetPrefab;

	private WorldObjectUI towerTarget;

	private Tower tower;

	private GameplayObjectData towerData;

	private TowerController towerController;

	private int editingTargetProviderIdx;

	private int editingGemSlotIdx;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			if (SelectedObject != null)
			{
				Tower.StatsComponent.onStatChanged -= OnStatChanged;
				Tower.GameplayEffectsComponent.onEffectAdded -= OnEffectsChanged;
				Tower.GameplayEffectsComponent.onEffectRemoved -= OnEffectsChanged;
				Tower.onTargetChanged -= OnTargetChanged;
				Tower.GemsComponent.onMaxGemsChanged -= OnTowerMaxGemsChanged;
				Tower.GemsComponent.onGemAdded -= OnGemAddedOrRemoved;
				Tower.GemsComponent.onGemRemoved -= OnGemAddedOrRemoved;
				if (!Tower.GameplayObject.ObjectData.IsUpgrade())
				{
					Tower.onExperienceChanged -= OnExperienceChanged;
				}
			}
			base.SelectedObject = value;
			Tower = SelectedObject as Tower;
			towerData = Tower.GetComponent<GameplayObject>().ObjectData;
			towerController = Tower.Controller as TowerController;
			Tower.StatsComponent.onStatChanged += OnStatChanged;
			Tower.GameplayEffectsComponent.onEffectAdded += OnEffectsChanged;
			Tower.GameplayEffectsComponent.onEffectRemoved += OnEffectsChanged;
			Tower.onTargetChanged += OnTargetChanged;
			Tower.GemsComponent.onMaxGemsChanged += OnTowerMaxGemsChanged;
			Tower.GemsComponent.onGemAdded += OnGemAddedOrRemoved;
			Tower.GemsComponent.onGemRemoved += OnGemAddedOrRemoved;
			if (!Tower.GameplayObject.ObjectData.IsUpgrade())
			{
				Tower.onExperienceChanged += OnExperienceChanged;
			}
			UpdateAll();
		}
	}

	public Tower Tower
	{
		get
		{
			return tower;
		}
		private set
		{
			tower = value;
		}
	}

	public override void Start()
	{
		base.Start();
		towerTarget = UnityEngine.Object.Instantiate(towerTargetPrefab);
		UpdateTargetMark(Tower.Target);
	}

	private void OnDestroy()
	{
		if ((bool)Tower)
		{
			Tower.StatsComponent.onStatChanged -= OnStatChanged;
			Tower.GameplayEffectsComponent.onEffectAdded -= OnEffectsChanged;
			Tower.GameplayEffectsComponent.onEffectRemoved -= OnEffectsChanged;
			Tower.onTargetChanged -= OnTargetChanged;
			Tower.GemsComponent.onMaxGemsChanged -= OnTowerMaxGemsChanged;
			Tower.GemsComponent.onGemAdded -= OnGemAddedOrRemoved;
			Tower.GemsComponent.onGemRemoved -= OnGemAddedOrRemoved;
			if (!Tower.GameplayObject.ObjectData.IsUpgrade())
			{
				Tower.onExperienceChanged -= OnExperienceChanged;
			}
		}
		UnityEngine.Object.Destroy(towerTarget.gameObject);
	}

	private void UpdateAll()
	{
		towerNameText.text = towerData.DisplayName;
		UpdateTowerStats();
		UpdateTowerDamageMultipliers();
		UpdateTargetProviders();
		UpdateKeepTarget();
		UpdateEffects();
		UpdateTowerUpgrades();
		UpdateExperienceBar(Tower.Experience / LTFunctionLibrary.GetLTGameManager().TowerExperienceToUpgrade);
		UpdateSellTooltip();
		UpdateTargetMark(Tower.Target);
		UpdateGems();
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void UpdateTowerStats()
	{
		damageStatText.text = FunctionLibrary.RoundToDecimals(Tower.StatsComponent.GetStat(EStats.BaseDamage), 2).ToString();
		attackSpeedStatText.text = FunctionLibrary.RoundToDecimals(1f / Tower.StatsComponent.GetStat(EStats.AttackSpeed), 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
		rangeStatText.text = FunctionLibrary.RoundToDecimals(Tower.StatsComponent.GetStat(EStats.Range), 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_meter_short").Entry.GetLocalizedString();
		bool flag = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Ground, Tower.CombatComponent);
		bool flag2 = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Flying, Tower.CombatComponent);
		enemyTypeGroundGO.SetActive(flag);
		enemyTypeFlyingGO.SetActive(flag2);
		validEnemyTypesTooltip.TooltipText = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_store_towerInfo_label_canTarget").Entry.GetLocalizedString();
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("Enemies", "Enemies_enemyType_ground").Entry.GetLocalizedString();
		string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("Enemies", "Enemies_enemyType_flying").Entry.GetLocalizedString();
		if (flag)
		{
			validEnemyTypesTooltip.TooltipText += (flag2 ? (" " + localizedString + ", " + localizedString2) : localizedString);
		}
		else if (flag2)
		{
			TooltipComponent_text tooltipComponent_text = validEnemyTypesTooltip;
			tooltipComponent_text.TooltipText = tooltipComponent_text.TooltipText + " " + localizedString2;
		}
	}

	private void UpdateTowerDamageMultipliers()
	{
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_againstHealth").Entry.GetLocalizedString();
		string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_againstArmor").Entry.GetLocalizedString();
		string localizedString3 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_againstShield").Entry.GetLocalizedString();
		damageMultiplierHealthContainer.DeleteAllChildren();
		UnityEngine.Object.Instantiate(GetDamageMultiplierPrefab(Tower.CombatComponent.HealthMultiplier), damageMultiplierHealthContainer);
		damageMultiplierHealthTooltip.TooltipText = localizedString + " " + GetDamageMultiplierTooltipText(Tower.CombatComponent.HealthMultiplier);
		damageMultiplierArmorContainer.DeleteAllChildren();
		UnityEngine.Object.Instantiate(GetDamageMultiplierPrefab(Tower.CombatComponent.ArmorMultiplier), damageMultiplierArmorContainer);
		damageMultiplierArmorTooltip.TooltipText = localizedString2 + " " + GetDamageMultiplierTooltipText(Tower.CombatComponent.ArmorMultiplier);
		damageMultiplierShieldContainer.DeleteAllChildren();
		UnityEngine.Object.Instantiate(GetDamageMultiplierPrefab(Tower.CombatComponent.ShieldMultiplier), damageMultiplierShieldContainer);
		damageMultiplierShieldTooltip.TooltipText = localizedString3 + " " + GetDamageMultiplierTooltipText(Tower.CombatComponent.ShieldMultiplier);
	}

	private void UpdateTargetProviders()
	{
		firstTargetProviderImage.sprite = towerController.FirstTargetProvider.Icon;
		secondTargetProviderImage.sprite = towerController.SecondTargetProvider.Icon;
		firstTargetProviderTooltip.TooltipText = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_selectable_tower_tooltip_firstTargetPriority").Entry.GetLocalizedString() + " " + towerController.FirstTargetProvider.DisplayName;
		secondTargetProviderTooltip.TooltipText = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_selectable_tower_tooltip_secondTargetPriority").Entry.GetLocalizedString() + " " + towerController.SecondTargetProvider.DisplayName;
	}

	private void UpdateKeepTarget()
	{
		keepTargetToggle.isOn = towerController.KeepTarget;
	}

	private void UpdateEffects()
	{
		effectsList.LoadList(Tower.GameplayEffectsComponent.GetEffects(excludeHiddenEffects: true));
	}

	private void UpdateTowerUpgrades()
	{
		List<PlayerData.PlayerBuilding> list = new List<PlayerData.PlayerBuilding>();
		string text = (Tower.GameplayObject.ObjectData.IsUpgrade() ? Tower.GameplayObject.ObjectData.BaseObject.Id : Tower.GameplayObject.ObjectData.Id);
		foreach (PlayerData.PlayerBuilding availableTower in LTFunctionLibrary.GetPlayerData().AvailableTowers)
		{
			if (availableTower.BuildingData?.BaseObject?.Id == text)
			{
				list.Add(availableTower);
			}
		}
		towerUpgradesList.LoadList(list);
		foreach (TowerUpgradeElementUI element in towerUpgradesList.Elements)
		{
			element.Tower = Tower;
			if (Tower.GameplayObject.ObjectData.IsUpgrade())
			{
				element.SetEnabled(enabled: false);
				if (LTFunctionLibrary.GetPlayerData().IsBuildingUnlocked(element.TowerData) && element.TowerData.Id == Tower.GameplayObject.ObjectData.Id)
				{
					element.SetSelected(selected: true);
				}
			}
			else
			{
				element.onBuyUpgradePressed = (Action<GameplayObjectData>)Delegate.Combine(element.onBuyUpgradePressed, new Action<GameplayObjectData>(onBuyTowerUpgradePressed));
			}
		}
	}

	private void UpdateGems()
	{
		if (tower.GemsComponent.Gems.Length != 0)
		{
			equippedGemsList.gameObject.SetActive(value: true);
			equippedGemsList.LoadList(tower.GemsComponent.Gems);
			int num = 0;
			foreach (SelectableUI_tower_gemUI element in equippedGemsList.Elements)
			{
				element.Setup(this, num);
				num++;
			}
		}
		else
		{
			equippedGemsList?.gameObject.SetActive(value: false);
		}
		if (LTFunctionLibrary.GetPlayerData().PlayerGems.Count > 0)
		{
			noGemsObject.SetActive(value: false);
			gemsList.gameObject.SetActive(value: true);
			gemsList.LoadList(LTFunctionLibrary.GetPlayerData().PlayerGems);
			for (int i = 0; i < gemsList.Elements.Count; i++)
			{
				int auxIdx = i;
				gemsList.Elements[i].GetComponent<Button>().onClick.AddListener(delegate
				{
					OnGemListElementClicked(auxIdx);
				});
			}
		}
		else
		{
			gemsList.ClearList();
			noGemsObject.SetActive(value: true);
			gemsList.gameObject.SetActive(value: false);
		}
	}

	private void OnGemListElementClicked(int gemListIdx)
	{
		GemData gemData = ((GemUI)gemsList.Elements[gemListIdx]).GemData;
		RemoveGem(editingGemSlotIdx);
		LTFunctionLibrary.GetPlayerData().RemoveGem(gemData);
		tower.GemsComponent.AddGem(gemData, editingGemSlotIdx);
		gemsContextWindow.CloseWindow();
	}

	public void RemoveGem(int equippedSlotIdx)
	{
		GemData gemData = Tower.GemsComponent.Gems[equippedSlotIdx];
		if ((bool)gemData)
		{
			LTFunctionLibrary.GetPlayerData().AddGem(gemData);
			Tower.GemsComponent.RemoveGem(equippedSlotIdx);
		}
	}

	public void ShowGemsContextWindow(int gemIdx)
	{
		gemsContextWindow.OpenWindow();
		gemsContextWindow.GetComponent<AutoTransformRebuild>().RebuildTransform();
		editingGemSlotIdx = gemIdx;
	}

	private void OnTargetProviderListElementClicked(TowerTargetProvider targetProvider)
	{
		if (editingTargetProviderIdx == 0)
		{
			towerController.FirstTargetProvider = targetProvider;
		}
		else if (editingTargetProviderIdx == 1)
		{
			towerController.SecondTargetProvider = targetProvider;
		}
		UpdateTargetProviders();
		targetProvidersContextWindow.CloseWindow();
	}

	public void ShowTargetProvidersContextWindow(int targetProviderIdx)
	{
		targetProvidersContextWindow.OpenWindow();
		targetProvidersList.LoadList(towerController.TargetProviders);
		targetProvidersContextWindow.GetComponent<AutoTransformRebuild>().RebuildTransform();
		for (int i = 0; i < targetProvidersList.Elements.Count; i++)
		{
			int auxIdx = i;
			targetProvidersList.Elements[i].GetComponent<Button>().onClick.AddListener(delegate
			{
				OnTargetProviderListElementClicked(towerController.TargetProviders[auxIdx]);
			});
		}
		editingTargetProviderIdx = targetProviderIdx;
	}

	private void UpdateExperienceBar(float experiencePercentage)
	{
		if (Tower.GameplayObject.ObjectData.IsUpgrade())
		{
			towerUpgradeFillBar.gameObject.SetActive(value: false);
			towerUpgradedImage.gameObject.SetActive(value: true);
			return;
		}
		towerUpgradeFillBar.gameObject.SetActive(value: true);
		towerUpgradedImage.gameObject.SetActive(value: false);
		towerUpgradeFillBar.SetBarValue(experiencePercentage);
		towerUpgradePercentageText.text = (int)(Mathf.Max(experiencePercentage, 0f) * 100f) + "%";
		if (experiencePercentage >= 1f)
		{
			towerUpgradeFillBar.SetBarColor(towerUpgradeFullColor);
		}
	}

	private void UpdateSellTooltip()
	{
		sellTooltip.TooltipText = string.Format(LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_selectable_tower_tooltip_sell", null, FallbackBehavior.UseProjectSettings), (int)(LTFunctionLibrary.GetLTGameManager().SellTowerCostMultiplier * 100f));
	}

	private void UpdateTargetMark(Enemy target)
	{
		if ((bool)towerTarget)
		{
			if ((bool)target)
			{
				towerTarget.gameObject.SetActive(value: true);
				towerTarget.SetFollowTarget(target.gameObject);
			}
			else
			{
				towerTarget.gameObject.SetActive(value: false);
			}
		}
	}

	public void ToggleKeepTarget(bool keepTarget)
	{
		towerController.KeepTarget = keepTarget;
	}

	private GameObject GetDamageMultiplierPrefab(EDamageMultiplier damageMultiplier)
	{
		return damageMultiplier switch
		{
			EDamageMultiplier.Low => damageMultiplierLowPrefab, 
			EDamageMultiplier.Normal => damageMultiplierNormalPrefab, 
			EDamageMultiplier.High => damageMultiplierHighPrefab, 
			_ => null, 
		};
	}

	private string GetDamageMultiplierTooltipText(EDamageMultiplier damageMultiplier)
	{
		return damageMultiplier switch
		{
			EDamageMultiplier.Low => LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_low").Entry.GetLocalizedString(), 
			EDamageMultiplier.Normal => LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_normal").Entry.GetLocalizedString(), 
			EDamageMultiplier.High => LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_high").Entry.GetLocalizedString(), 
			_ => "", 
		};
	}

	public void NextTargetProviderButton(int targetProviderIdx)
	{
		switch (targetProviderIdx)
		{
		case 0:
			towerController.FirstTargetProvider = towerController.TargetProviders[(int)Mathf.Repeat(towerController.TargetProviders.IndexOf(towerController.FirstTargetProvider) + 1, towerController.TargetProviders.Count)];
			break;
		case 1:
			towerController.SecondTargetProvider = towerController.TargetProviders[(int)Mathf.Repeat(towerController.TargetProviders.IndexOf(towerController.SecondTargetProvider) + 1, towerController.TargetProviders.Count)];
			break;
		}
		UpdateTargetProviders();
	}

	public void PreviousTargetProviderButton(int targetProviderIdx)
	{
		switch (targetProviderIdx)
		{
		case 0:
			towerController.FirstTargetProvider = towerController.TargetProviders[(int)Mathf.Repeat(towerController.TargetProviders.IndexOf(towerController.FirstTargetProvider) - 1, towerController.TargetProviders.Count)];
			break;
		case 1:
			towerController.SecondTargetProvider = towerController.TargetProviders[(int)Mathf.Repeat(towerController.TargetProviders.IndexOf(towerController.SecondTargetProvider) - 1, towerController.TargetProviders.Count)];
			break;
		}
		UpdateTargetProviders();
	}

	private void onBuyTowerUpgradePressed(GameplayObjectData data)
	{
		if (Tower.IsFullExperience())
		{
			Tower tower = LTFunctionLibrary.GetLTGameManager().UpgradeTower(Tower, data);
			if ((bool)tower)
			{
				(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = tower;
				SelectedObject = tower;
			}
		}
	}

	public void OnSellButtonPressed()
	{
		LTFunctionLibrary.GetLTGameManager().SellBuilding(Tower.GameplayObject);
		(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode as StandardInputMode).SelectedObject = null;
		AudioSystem.Instance.PlaySound2D(LTFunctionLibrary.GetLTPlayerController().SellObjectSFX, AudioSystem.EAudioMixerGroup.SFX);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		UpdateTowerStats();
	}

	private void OnEffectsChanged(GameplayEffect changedEffect)
	{
		UpdateEffects();
	}

	private void OnExperienceChanged(float experience, float experiencePercentage)
	{
		UpdateExperienceBar(experiencePercentage);
	}

	private void OnTargetChanged(Enemy newTarget, Enemy oldTarget)
	{
		UpdateTargetMark(newTarget);
	}

	private void OnTowerMaxGemsChanged(int obj)
	{
		UpdateGems();
	}

	private void OnGemAddedOrRemoved(GemData data)
	{
		UpdateGems();
	}
}
