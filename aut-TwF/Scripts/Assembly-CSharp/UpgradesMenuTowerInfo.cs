using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class UpgradesMenuTowerInfo : MonoBehaviour
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
	}

	private void UpdateTowerStats()
	{
		UpdateDamageText(0f);
		UpdateAttackSpeedText(0f);
		UpdateRangeText(0f);
		bool active = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Ground, towerCombatComponent);
		bool active2 = LTFunctionLibrary.CanTargetEnemyType(Enemy.EEnemyType.Flying, towerCombatComponent);
		enemyTypeGroundGO.SetActive(active);
		enemyTypeFlyingGO.SetActive(active2);
	}

	private void UpdateDamageText(float damageToAdd)
	{
		damageStatText.text = FunctionLibrary.RoundToDecimals(towerStatsComponent.GetStat(EStats.BaseDamage) + damageToAdd, 2).ToString();
	}

	private void UpdateAttackSpeedText(float attackSpeedToAdd)
	{
		attackSpeedStatText.text = FunctionLibrary.RoundToDecimals(1f / (towerStatsComponent.GetStat(EStats.AttackSpeed) + attackSpeedToAdd), 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_second_short").Entry.GetLocalizedString();
	}

	private void UpdateRangeText(float rangeToAdd)
	{
		rangeStatText.text = FunctionLibrary.RoundToDecimals(towerStatsComponent.GetStat(EStats.Range) + rangeToAdd, 2) + LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_meter_short").Entry.GetLocalizedString();
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
}
