using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/TowerSettingData", order = 1)]
public class TowerSettingData : ATowerComponentSettingData
{
	[Header("砲塔等級")]
	[SerializeField]
	private eTowerTier towerTier;

	[Header("砲塔尺寸")]
	[SerializeField]
	private eTowerSizeType towerSizeType;

	[SerializeField]
	[Header("傷害屬性")]
	private eDamageType damageType;

	private const float fragilePerSecond = 5f;

	[SerializeField]
	[Header("[奧術限定] 脆弱效果增幅倍率")]
	private float extraFragileMultiplier;

	private const float chargePerSecond = 10f;

	[Header("[電屬性限定] 蓄能效果增幅倍率")]
	[SerializeField]
	private float extraChargeMultiplier;

	[SerializeField]
	[Header("[冰屬性限定] 每次擊中的層數 (顯示用)")]
	private int chillLayerOnHit;

	[SerializeField]
	[Header("砲塔目標類型")]
	private eTowerTargetType towerTargetType;

	[SerializeField]
	[Header("砲塔攻擊目標數量")]
	private int towerAttackTargetCount;

	[Header("砲塔的攻擊範圍類型")]
	[SerializeField]
	private eTowerRangeType towerRangeType;

	[SerializeField]
	[Header("砲塔的最低攻擊範圍")]
	private float innerRangeRate;

	[Header("是否可選擇優先攻擊目標")]
	[SerializeField]
	private bool canSelectTargetPriority;

	[Header("是否是功能型砲塔")]
	[SerializeField]
	private bool isUtilityTower;

	[SerializeField]
	[Header("是否顯示功能型砲塔的範圍")]
	private bool doShowRangeForUtilityTower;

	[SerializeField]
	[Header("是否顯示功能型砲塔的攻擊速度")]
	private bool doShowSpeedForUtilityTower;

	[SerializeField]
	[Header("是否有限制建築數量")]
	private bool doLimitBuildingCount;

	[SerializeField]
	[Header("建築數量限制")]
	private int limitBuildingCount;

	[SerializeField]
	private List<eStatType> list_UpgradeableStatType;

	[SerializeField]
	[Header("是否在TowerControl有額外的屬性")]
	private bool isHaveExtraTowerControlStat;

	[SerializeField]
	[Header("是否在TowerControl有額外的數值紀錄")]
	private bool isHaveExtraTowerControlRecord;

	[Header("是否在說明中隱藏 攻擊範圍 數值")]
	[SerializeField]
	private bool doHideAttackRangeInTooltip;

	[SerializeField]
	[Header("是否在說明中隱藏 攻擊速度 數值")]
	private bool doHideAttackSpeedInTooltip;

	[SerializeField]
	[Header("將屬性替換成另外一個屬性")]
	private List<TowerBuffStatReplace> list_StatReplace;

	[SerializeField]
	[Header("是否可以不需要方塊直接建造")]
	private bool canBuildWithoutTetrisBlock;

	[Header("是否可以升級")]
	[SerializeField]
	private bool isUpgradeable;

	[Header("升級設定A")]
	[SerializeField]
	private TowerUpgradeSetting upgradeSetting_A;

	[Header("升級設定B")]
	[SerializeField]
	private TowerUpgradeSetting upgradeSetting_B;

	[Header("砲塔的Prefab")]
	[SerializeField]
	private GameObject prefab;

	[Header("子彈Prefab")]
	[SerializeField]
	private GameObject bulletPrefab;

	[Header("特殊尺寸圖示")]
	[SerializeField]
	private Sprite sprite_SpecialSizeIcon;

	private string overrrideDamageDisplay;

	private ABaseTower boundTower;

	public eTowerTier TowerTier => default(eTowerTier);

	public eTowerSizeType TowerSizeType => default(eTowerSizeType);

	public eDamageType DamageType => default(eDamageType);

	public float ExtraFragileMultiplier => 0f;

	public float ExtraChargeMultiplier => 0f;

	public int ChillLayerOnHit => 0;

	public eTowerTargetType TowerTargetType => default(eTowerTargetType);

	public int TowerAttackTargetCount => 0;

	public eTowerRangeType TowerRangeType => default(eTowerRangeType);

	public float InnerRangeRate => 0f;

	public bool CanSelectTargetPriority => false;

	public bool IsUtilityTower => false;

	public bool DoShowRangeForUtilityTower => false;

	public bool DoShowSpeedForUtilityTower => false;

	public bool DoLimitBuildingCount => false;

	public int LimitBuildingCount => 0;

	public bool IsHaveExtraTowerControlStat => false;

	public bool IsHaveExtraTowerControlRecord => false;

	public bool DoHideAttackRangeInTooltip => false;

	public bool DoHideAttackSpeedInTooltip => false;

	public List<TowerBuffStatReplace> List_BuffStatReplace => null;

	public bool CanBuildWithoutTetrisBlock => false;

	public bool IsUpgradeable => false;

	public TowerUpgradeSetting UpgradeSetting_A => null;

	public TowerUpgradeSetting UpgradeSetting_B => null;

	public Sprite Sprite_SpecialSizeIcon => null;

	private Color GetLimitBuildingCountColor()
	{
		return default(Color);
	}

	public void ApplyTowerTalentBuff()
	{
	}

	public void RegisterTower(ABaseTower tower)
	{
	}

	public GameObject GetPrefab()
	{
		return null;
	}

	public GameObject GetBulletPrefab()
	{
		return null;
	}

	public float GetAttackRange(float multiplier = 1f)
	{
		return 0f;
	}

	public float GetInnerRange()
	{
		return 0f;
	}

	public void OverrideDamageType(eDamageType newType)
	{
	}

	public void OverrideBuildCost(int newCost)
	{
	}

	public void OverrideOriginalDamage(int damage)
	{
	}

	public void OverrideOriginalAttackRate(float rate)
	{
	}

	public void OverrideAttackTargetCount(int count)
	{
	}

	public void OverrideCanSetTargetPriority(bool canSet)
	{
	}

	public void OverrideTowerTargetType(eTowerTargetType targetType)
	{
	}

	public void OverrideRangeType(eTowerRangeType newType)
	{
	}

	public void OverrideHideAttackRangeInTooltip(bool hide)
	{
	}

	public void OverrideHideAttackSpeedInTooltip(bool hide)
	{
	}

	public void OverrideIsUtilityTower(bool isUtility)
	{
	}

	public int GetDamage(float multiplier = 1f)
	{
		return 0;
	}

	public int GetExtraTargetCount()
	{
		return 0;
	}

	public float GetBaseShootInterval()
	{
		return 0f;
	}

	public float GetShootInterval(float multiplier = 1f)
	{
		return 0f;
	}

	public int GetSellValue(int roundCountAfterDeploy)
	{
		return 0;
	}

	public int GetBaseUpgradeCost(ABaseTower.eUpgradeType upgradeType)
	{
		return 0;
	}

	public TowerUpgradeSetting GetUpgradeSetting(ABaseTower.eUpgradeType upgradeType)
	{
		return null;
	}

	public bool HasUpgradeableStat(eStatType statType)
	{
		return false;
	}

	public List<eStatType> GetUpgradeableStatList()
	{
		return null;
	}

	public void RuntimeUpdateTick(float deltaTime)
	{
	}

	public bool CanSellInBattle()
	{
		return false;
	}

	public float GetFragilePerHit()
	{
		return 0f;
	}

	public void OverrideFragileMultiplier(float newMultiplier)
	{
	}

	public int GetChargePerHit()
	{
		return 0;
	}

	public void OverrideChargeMultiplier(float newMultiplier)
	{
	}

	public void OverrideChillLayerOnHit(int newLayer)
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocFlavorTextString()
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}

	public string GetStatString()
	{
		return null;
	}

	public override List<string> GetSecondaryDescriptionStrings(eExtraTooltipType extra = eExtraTooltipType.NONE)
	{
		return null;
	}

	public string GetLocUpgradeString(ABaseTower.eUpgradeType upgradeType)
	{
		return null;
	}

	public bool IsAnyUpgradeChangesToDamageType(eDamageType damageType)
	{
		return false;
	}
}
