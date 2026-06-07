using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerUpgradeSetting
{
	public enum eUpgradeCostType
	{
		FIXED = 0,
		PERCENTAGE = 1
	}

	[SerializeField]
	[Header("升級花費類型")]
	private eUpgradeCostType upgradeCostType;

	[Header("升級花費")]
	[SerializeField]
	private int upgradeCost_Fixed;

	[Header("升級花費百分比")]
	[SerializeField]
	private float upgradeCost_Percentage;

	[Header("是否會切換屬性 (這邊的設定不會實際切換，只是查詢用!)")]
	[SerializeField]
	private bool doSwitchDamageType;

	[Header("切換後的屬性")]
	[SerializeField]
	private eDamageType upgradedDamageType;

	[Header("如果是1x1砲塔，是否有額外的Loc說明")]
	[SerializeField]
	private bool hasExtraLocDescription;

	[SerializeField]
	[Header("升級時提昇的數值")]
	private List<TowerStats> list_UpgradeStats;

	public bool HasExtraLocDescription => false;

	public List<TowerStats> List_UpgradeStats => null;

	private Color GetDamageTypeColor()
	{
		return default(Color);
	}

	public int GetUpgradeCost(int baseCost)
	{
		return 0;
	}

	public bool IsSwitchingDamageType()
	{
		return false;
	}

	public eDamageType GetUpgradedDamageType()
	{
		return default(eDamageType);
	}
}
