using System;
using System.Collections.Generic;
using I2.Loc;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : SerializedScriptableObject
{
	public Sprite Icon;

	public List<Color> IconColorList;

	public string Name;

	[TextArea(3, 4)]
	public string Desc;

	[HideInInspector]
	public string Slug;

	public UpgradeInfo[][] MergeComponents;

	[Header("Stats")]
	public Dictionary<PropertyType, int> Properties;

	[NonSerialized]
	[OdinSerialize]
	[HideInInspector]
	public Dictionary<PropertyType, int>[] PropertiesByLvl;

	[NonSerialized]
	[OdinSerialize]
	public UpgradeTier[] Tiers;

	public bool IsInGame;

	public int MinVersion;

	[Header("Generated")]
	public List<UpgradeInfo> Evolutions;

	public bool HasProperty(PropertyType pt)
	{
		return false;
	}

	public int GetProperty(PropertyType pt)
	{
		return 0;
	}

	public bool DoesPropertyChange(PropertyType pt, int lvl1, int lvl2)
	{
		return false;
	}

	public virtual int GetPropertyByLvl(PropertyType pt, int lvl, int defaultVal = 0)
	{
		return 0;
	}

	public void OnValidate()
	{
	}

	public virtual UpgradeType GetUpgradeType()
	{
		return default(UpgradeType);
	}

	public virtual int GetIdx()
	{
		return 0;
	}

	public virtual PassiveInfo ToPassive()
	{
		return null;
	}

	public virtual HeroInfo ToHero()
	{
		return null;
	}

	public virtual PetUpgradeInfo ToPetUpgrade()
	{
		return null;
	}

	public virtual void ApplyIcon(Image img)
	{
	}

	public bool IsMerged()
	{
		return false;
	}

	public bool HasMergeComponent(UpgradeInfo upgInf)
	{
		return false;
	}

	public bool HasMergeComponentRecursive(UpgradeInfo upgInf)
	{
		return false;
	}

	public int GetMergeComponentIdx(UpgradeInfo upgInf)
	{
		return 0;
	}

	public bool HasMergeCombo(UpgradeInfo h1Inf, UpgradeInfo h2Inf)
	{
		return false;
	}

	public bool IsMergeReqMet(int idx)
	{
		return false;
	}

	public UpgradeInfo[] GetAvailableMergeComponents()
	{
		return null;
	}

	public bool IsMergeReqMet()
	{
		return false;
	}

	public int GetNumMergeComponents()
	{
		return 0;
	}

	public virtual void GenerateSlug()
	{
	}

	public string GetUpgradeSlug(int lvl)
	{
		return null;
	}

	public string GetNameSlug()
	{
		return null;
	}

	public string GetDescSlug()
	{
		return null;
	}

	public virtual void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public void ApplyPropertyParams(LocalizationParamsManager loc)
	{
	}

	public void ApplyUpgradeParams(int lvl, LocalizationParamsManager loc, bool colorize = false)
	{
	}

	public void ApplyUnmodifiedUpgradeParams(int lvl, LocalizationParamsManager loc)
	{
	}

	public virtual bool ShouldAIPick()
	{
		return false;
	}

	public virtual LevelType GetRequiredLevel()
	{
		return default(LevelType);
	}

	public virtual bool IncludeInGame()
	{
		return false;
	}
}
