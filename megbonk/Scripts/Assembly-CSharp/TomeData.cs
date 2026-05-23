using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts._Data;
using Assets.Scripts._Data.Tomes;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Tome", order = 1)]
public class TomeData : UnlockableBase, IUpgradable
{
	public ETome eTome;

	[TextArea]
	public string description;

	public StatModifier statModifier;

	public Texture icon;

	public UpgradeData upgradeData;

	[Header("Unlocks")]
	public MyAchievement AchievementRequirement;

	public string GetUpgradeDescription(int level, List<StatModifier> upgradeOffer, ERarity rarity)
	{
		return null;
	}

	public override string GetDescription()
	{
		return null;
	}

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		return null;
	}

	public override string GetInternalName()
	{
		return null;
	}

	public int GetLevel()
	{
		return 0;
	}

	public int GetMaxLevel()
	{
		return 0;
	}

	public List<StatModifier> GetUpgradeOffer(ERarity rarity)
	{
		return null;
	}
}
