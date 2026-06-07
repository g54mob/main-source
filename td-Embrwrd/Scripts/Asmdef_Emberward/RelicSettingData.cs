using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RelicSettingData", menuName = "設定檔/RelicSettingData", order = 1)]
public class RelicSettingData : AItemSettingData
{
	[Header("神器效果類型")]
	[SerializeField]
	private eRelicEffectType effectType;

	[Header("帶有屬性")]
	[SerializeField]
	private List<eDamageType> relatedDamageType;

	[Header("是否在單場Roguelite模式出現")]
	[SerializeField]
	private bool doShowInSingleRoundRoguelite;

	[Header("是否在第一輪遊戲就出現")]
	[SerializeField]
	private bool doShowBeforeTutorial;

	[SerializeField]
	private bool isRequireNormalBossKill;

	[SerializeField]
	private bool onlyShowInAcademy;

	[SerializeField]
	[Header("是否跟遊戲時間有關")]
	private bool isTimeRelated;

	[SerializeField]
	[Header("是否跟生命值有關")]
	private bool isHPRelated;

	[Header("是否限制只能出現在某個世界")]
	[SerializeField]
	private bool isLimitedWorldType;

	[Header("只能出現的世界類型")]
	[SerializeField]
	private eWorldType limitedWorldType;

	[Header("是否限制玩家要有某種砲塔才能出現")]
	[SerializeField]
	private bool isRequireTowerType;

	[Header("必須要有的砲塔類型")]
	[SerializeField]
	private List<eItemType> requiredTowerType;

	[Header("是否在擁有某種砲塔時增加權重")]
	[SerializeField]
	private bool isIncreaseWeightWithTowerType;

	[SerializeField]
	[Header("增加權重的砲塔類型")]
	private List<eItemType> increaseWeightTowerType;

	public eRelicEffectType EffectType => default(eRelicEffectType);

	public bool DoShowInSingleRoundRoguelite => false;

	public bool DoShowBeforeTutorial => false;

	public bool IsRequireNormalBossKill => false;

	public bool OnlyShowInAcademy => false;

	public bool IsTimeRelated => false;

	public bool IsHPRelated => false;

	public bool IsRequireTowerType => false;

	public bool IsIncreaseWeightWithTowerType => false;

	public bool CanSpawnInWorld(eWorldType worldType)
	{
		return false;
	}

	public bool CanSpawnWithTowerSet(List<TowerIngameData> towerSet)
	{
		return false;
	}

	public bool CanSpawnWithTowerType(List<eItemType> list_TowerType)
	{
		return false;
	}

	public int GetIncreasedWeightWithTowerSet(List<TowerIngameData> towerSet)
	{
		return 0;
	}

	public bool IsRelatedToDamageType(eDamageType damageType)
	{
		return false;
	}

	public bool HasAnyRelatedDamageType()
	{
		return false;
	}

	public bool IsRelatedToDamageType(List<eDamageType> damageTypes)
	{
		return false;
	}

	public int GetIncreasedWeightWithDamageType(eDamageType damageType)
	{
		return 0;
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
