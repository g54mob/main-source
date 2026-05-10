using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class TooltipUI_towerUpgrade : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI towerName;

	[SerializeField]
	private TextMeshProUGUI towerDescription;

	[SerializeField]
	private UIList costList;

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

	[SerializeField]
	private Color improvedStatColor = Color.green;

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

	private Tower tower;

	private Tower currentBaseTower;

	private GameplayObjectData towerData;

	private TowerCombatComponent towerCombatComponent;

	private StatsComponent towerStatsComponent;

	private GameplayEffectsComponent towerGameplayEffectsComponent;

	private void OnDestroy()
	{
		if ((bool)currentBaseTower)
		{
			currentBaseTower.onEndedUpgrade -= OnTowerEndsUpgrade;
		}
	}

	public override void Setup(Dictionary<string, object> data)
	{
		TooltipComponent_towerUpgrade.FTowerUpgradeTooltipData fTowerUpgradeTooltipData = (TooltipComponent_towerUpgrade.FTowerUpgradeTooltipData)data["towerUpgradeData"];
		tower = fTowerUpgradeTooltipData.towerData.Prefab.GetComponent<Tower>();
		towerData = tower.GetComponent<GameplayObject>().ObjectData;
		towerStatsComponent = tower.GetComponent<StatsComponent>();
		towerCombatComponent = tower.GetComponent<TowerCombatComponent>();
		towerGameplayEffectsComponent = tower.GetComponent<GameplayEffectsComponent>();
		currentBaseTower = fTowerUpgradeTooltipData.upgradingTower;
		if ((bool)currentBaseTower)
		{
			currentBaseTower.onEndedUpgrade += OnTowerEndsUpgrade;
		}
		UpdateInfo();
		costList.LoadList(fTowerUpgradeTooltipData.towerData.BuyCost);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private void OnTowerEndsUpgrade()
	{
		UpdateInfo();
	}

	private void UpdateInfo()
	{
		towerName.text = towerData.DisplayName;
		towerDescription.text = towerData.Description;
		UpdateTowerStats();
		UpdateTowerDamageMultipliers();
		UpdateEffects();
		costList.LoadList(towerData.BuyCost);
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}

	private List<GameplayEffectData> GetBaseTowerEffects()
	{
		List<GameplayEffectData> list = new List<GameplayEffectData>();
		if ((bool)currentBaseTower)
		{
			Vector3[] occupiedPositions = currentBaseTower.PlacementComponent.GetOccupiedPositions();
			foreach (Vector3 position in occupiedPositions)
			{
				foreach (GameplayObject adjacentBuiltObject in LTFunctionLibrary.GetGrid().GetAdjacentBuiltObjects(position))
				{
					if (adjacentBuiltObject.TryGetComponent<Obelisk>(out var component))
					{
						list.AddRange(component.GameplayEffectsToApply);
					}
				}
			}
			foreach (GemData gems in currentBaseTower.GemsComponent.GemsList)
			{
				list.AddRange(gems.GameplayEffectsToApply);
			}
		}
		return list;
	}

	private void UpdateTowerStats()
	{
		Tower.FTowerStats totalTowerStats = Tower.GetTotalTowerStats(tower);
		Tower.FTowerStats totalTowerStats2 = Tower.GetTotalTowerStats(currentBaseTower ?? tower.GetComponent<GameplayObject>().ObjectData.BaseObject.Prefab.GetComponent<Tower>());
		List<GameplayEffectData> baseTowerEffects = GetBaseTowerEffects();
		totalTowerStats.ApplyGE(baseTowerEffects);
		totalTowerStats2.ApplyGE(baseTowerEffects);
		UpdateDamageText(totalTowerStats.Damage, totalTowerStats2.Damage);
		UpdateAttackSpeedText(totalTowerStats.AttackSpeed, totalTowerStats2.AttackSpeed);
		UpdateRangeText(totalTowerStats.Range, totalTowerStats2.Range);
		bool active = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Ground, towerCombatComponent);
		bool active2 = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Flying, towerCombatComponent);
		enemyTypeGroundGO.SetActive(active);
		enemyTypeFlyingGO.SetActive(active2);
	}

	private void UpdateDamageText(float damage, float baseTowerDamage)
	{
		damageStatText.text = FunctionLibrary.RoundToDecimals(damage, 2).ToString();
		if (damage > baseTowerDamage)
		{
			damageStatText.color = improvedStatColor;
		}
	}

	private void UpdateAttackSpeedText(float attackSpeed, float baseTowerAttackSpeed)
	{
		attackSpeedStatText.text = FunctionLibrary.RoundToDecimals(1f / attackSpeed, 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
		if (attackSpeed > baseTowerAttackSpeed)
		{
			attackSpeedStatText.color = improvedStatColor;
		}
	}

	private void UpdateRangeText(float range, float baseTowerRange)
	{
		rangeStatText.text = FunctionLibrary.RoundToDecimals(range, 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_meter_short").Entry.GetLocalizedString();
		if (range > baseTowerRange)
		{
			rangeStatText.color = improvedStatColor;
		}
	}

	private void UpdateTowerDamageMultipliers()
	{
		damageMultiplierHealthContainer.DeleteAllChildren();
		Object.Instantiate(GetDamageMultiplierPrefab(towerCombatComponent.HealthMultiplier), damageMultiplierHealthContainer);
		damageMultiplierArmorContainer.DeleteAllChildren();
		Object.Instantiate(GetDamageMultiplierPrefab(towerCombatComponent.ArmorMultiplier), damageMultiplierArmorContainer);
		damageMultiplierShieldContainer.DeleteAllChildren();
		Object.Instantiate(GetDamageMultiplierPrefab(towerCombatComponent.ShieldMultiplier), damageMultiplierShieldContainer);
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
			EDamageMultiplier.Low => "low (x0.5)", 
			EDamageMultiplier.Normal => "normal (x1)", 
			EDamageMultiplier.High => "high (x2)", 
			_ => "", 
		};
	}

	private void UpdateEffects()
	{
		List<GameplayEffectData> initialEffects = towerGameplayEffectsComponent.GetInitialEffects(excludeHiddenEffects: true);
		foreach (GameplayEffectData item in LTFunctionLibrary.GetGameplayEffectDatasToApplyToBuilding(tower.GetComponent<GameplayObject>().ObjectData))
		{
			if (!item.HideToPlayer)
			{
				initialEffects.Add(item);
			}
		}
		initialEffects.AddRange(GetBaseTowerEffects());
		effectsList.LoadList(initialEffects);
	}
}
