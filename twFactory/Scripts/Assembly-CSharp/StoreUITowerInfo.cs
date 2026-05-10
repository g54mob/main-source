using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class StoreUITowerInfo : MonoBehaviour
{
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

	[Header("Effects")]
	[SerializeField]
	private UIList effectsList;

	[Header("Upgrades")]
	[SerializeField]
	private UIList towerUpgradesList;

	[Header("Tooltips")]
	[SerializeField]
	private TooltipComponent_text validEnemyTypesTooltip;

	[SerializeField]
	private TooltipComponent_text damageMultiplierHealthTooltip;

	[SerializeField]
	private TooltipComponent_text damageMultiplierArmorTooltip;

	[SerializeField]
	private TooltipComponent_text damageMultiplierShieldTooltip;

	private Tower selectedTower;

	private TowerCombatComponent towerCombatComponent;

	private StatsComponent towerStatsComponent;

	private GameplayEffectsComponent towerGameplayEffectsComponent;

	public Tower SelectedTower
	{
		get
		{
			return selectedTower;
		}
		set
		{
			selectedTower = value;
			LoadData();
		}
	}

	private void LoadData()
	{
		towerStatsComponent = selectedTower.GetComponent<StatsComponent>();
		towerCombatComponent = selectedTower.GetComponent<TowerCombatComponent>();
		towerGameplayEffectsComponent = selectedTower.GetComponent<GameplayEffectsComponent>();
		UpdateTowerStats();
		UpdateTowerDamageMultipliers();
		UpdateEffects();
		UpdateTowerUpgrades();
	}

	private void UpdateTowerStats()
	{
		Tower.FTowerStats totalTowerStats = Tower.GetTotalTowerStats(selectedTower);
		UpdateDamageText(totalTowerStats.Damage);
		UpdateAttackSpeedText(totalTowerStats.AttackSpeed);
		UpdateRangeText(totalTowerStats.Range);
		bool flag = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Ground, towerCombatComponent);
		bool flag2 = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Flying, towerCombatComponent);
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

	private void UpdateDamageText(float damage)
	{
		damageStatText.text = FunctionLibrary.RoundToDecimals(damage, 2).ToString();
	}

	private void UpdateAttackSpeedText(float attackSpeed)
	{
		attackSpeedStatText.text = FunctionLibrary.RoundToDecimals(1f / attackSpeed, 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
	}

	private void UpdateRangeText(float range)
	{
		rangeStatText.text = FunctionLibrary.RoundToDecimals(range, 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_meter_short").Entry.GetLocalizedString();
	}

	private void UpdateTowerDamageMultipliers()
	{
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_againstHealth").Entry.GetLocalizedString();
		string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_againstArmor").Entry.GetLocalizedString();
		string localizedString3 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_damageMultiplier_againstShield").Entry.GetLocalizedString();
		damageMultiplierHealthContainer.DeleteAllChildren();
		Object.Instantiate(GetDamageMultiplierPrefab(towerCombatComponent.HealthMultiplier), damageMultiplierHealthContainer);
		damageMultiplierHealthTooltip.TooltipText = localizedString + " " + GetDamageMultiplierTooltipText(towerCombatComponent.HealthMultiplier);
		damageMultiplierArmorContainer.DeleteAllChildren();
		Object.Instantiate(GetDamageMultiplierPrefab(towerCombatComponent.ArmorMultiplier), damageMultiplierArmorContainer);
		damageMultiplierArmorTooltip.TooltipText = localizedString2 + " " + GetDamageMultiplierTooltipText(towerCombatComponent.ArmorMultiplier);
		damageMultiplierShieldContainer.DeleteAllChildren();
		Object.Instantiate(GetDamageMultiplierPrefab(towerCombatComponent.ShieldMultiplier), damageMultiplierShieldContainer);
		damageMultiplierShieldTooltip.TooltipText = localizedString3 + " " + GetDamageMultiplierTooltipText(towerCombatComponent.ShieldMultiplier);
	}

	private void UpdateEffects()
	{
		List<GameplayEffectData> initialEffects = towerGameplayEffectsComponent.GetInitialEffects(excludeHiddenEffects: true);
		foreach (GameplayEffectData item in LTFunctionLibrary.GetGameplayEffectDatasToApplyToBuilding(selectedTower.GetComponent<GameplayObject>().ObjectData))
		{
			if (!item.HideToPlayer)
			{
				initialEffects.Add(item);
			}
		}
		effectsList.LoadList(initialEffects);
	}

	private void UpdateTowerUpgrades()
	{
		List<PlayerData.PlayerBuilding> list = new List<PlayerData.PlayerBuilding>();
		string id = selectedTower.GetComponent<GameplayObject>().ObjectData.Id;
		foreach (PlayerData.PlayerBuilding availableTower in LTFunctionLibrary.GetPlayerData().AvailableTowers)
		{
			if (availableTower.BuildingData?.BaseObject?.Id == id)
			{
				list.Add(availableTower);
			}
		}
		towerUpgradesList.LoadList(list);
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
}
