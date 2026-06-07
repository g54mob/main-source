using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AItemSettingData : ScriptableObject, ICardDataSource, ILocalizationDataSource
{
	[Header("卡片類型")]
	[SerializeField]
	protected eItemType itemType;

	[Header("卡片圖示")]
	[SerializeField]
	protected Sprite sprite_Icon;

	[SerializeField]
	[Header("基本金額")]
	protected int baseCost;

	[SerializeField]
	[Header("商店金額")]
	protected int storeCost;

	[SerializeField]
	[Header("是否可在遊戲中使用")]
	protected bool isInGame;

	[Header("是否在DEMO中出現")]
	[SerializeField]
	protected bool isInDemo;

	[SerializeField]
	[Header("是否可在商店中買到")]
	protected bool canPurchaseInStore;

	[SerializeField]
	[Header("額外提示類型")]
	private eExtraTooltipType extraTooltipType;

	[SerializeField]
	[Header("屬性列表")]
	protected List<TowerStats> list_Stats;

	protected string loc_AttributeString;

	protected string loc_Name;

	protected string loc_FlavorText;

	public List<TowerStats> List_Stats => null;

	public int GetBaseBuildCost(float multiplier = 1f)
	{
		return 0;
	}

	public int GetStoreCost()
	{
		return 0;
	}

	public bool IsInGame()
	{
		return false;
	}

	public bool IsPurchaseable()
	{
		return false;
	}

	public bool IsInDemo()
	{
		return false;
	}

	public eItemType GetItemType()
	{
		return default(eItemType);
	}

	public Sprite GetCardIcon()
	{
		return null;
	}

	public virtual string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public virtual string GetLocFlavorTextString()
	{
		return null;
	}

	public virtual string GetLocStatsString()
	{
		return null;
	}

	public virtual List<string> GetSecondaryDescriptionStrings(eExtraTooltipType extra = eExtraTooltipType.NONE)
	{
		return null;
	}

	public AItemSettingData GetScriptableObjectData()
	{
		return null;
	}

	public bool IsHaveTowerStat(eStatType type)
	{
		return false;
	}

	public TowerStats GetTowerStats(eStatType type)
	{
		return null;
	}

	public void CombineMultiplier(AItemSettingData data)
	{
	}

	public void AddBuffMultiplier(TowerStats buffStat)
	{
	}

	public void RemoveBuffMultiplier(TowerStats buffStat)
	{
	}

	public void RemoveBuffMultiplier(int id)
	{
	}

	public void RemoveBuffMultiplier(eStatType type, int id)
	{
	}

	public bool IsHaveBuffMultiplierWithID(eStatType type, int id)
	{
		return false;
	}
}
