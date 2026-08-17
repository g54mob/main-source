using System;
using System.Collections.Generic;
using Assets.Scripts._Data;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class TomeData : UnlockableBase, IUpgradable
{
	public ETome eTome;

	public string description;

	public StatModifier statModifier;

	public Texture icon;

	public UpgradeData upgradeData;

	public MyAchievement AchievementRequirement;

	public string GetUpgradeDescription(int level, List<StatModifier> upgradeOffer, ERarity rarity)
	{
		//IL_00f5: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317219C]");
		bool flag = (nint)0 == 0;
		object obj = eTome - 23;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag && (nint)obj3 != 1)
				{
					if (level > 0)
					{
						return StatUtility.GetUpgradeDescriptionTome(upgradeOffer, this);
					}
					return StatUtility.GetUpgradeDescriptionTomeModifier(statModifier, this);
				}
			}
			return GetDescription();
		}
		return TomeUtility.GetUpgradeDescription(this, rarity);
	}

	public override string GetDescription()
	{
		//IL_0176: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317219D]");
		bool flag = (nint)0 == 0;
		object obj = eTome - 23;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag && (nint)obj3 != 1)
				{
					StatModifier statModifier = this.statModifier;
					if (this.statModifier != null)
					{
						string statName = LocalizationUtility.GetStatName(statModifier.stat);
						StatModifier statModifier2 = this.statModifier;
						if (this.statModifier != null)
						{
							string statDesc = LocalizationUtility.GetStatDesc(statModifier2.stat);
							return "+" + statName + " - " + statDesc;
						}
					}
					goto IL_0158;
				}
			}
			if (localizedDescription != null)
			{
				return localizedDescription.GetLocalizedString();
			}
			goto IL_0158;
		}
		return TomeUtility.GetUpgradeDescription(this, ERarity.New);
		IL_0158:
		return (string)(object)new NullReferenceException();
	}

	public override Texture GetIcon()
	{
		return icon;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return AchievementRequirement;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317219E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Unlockables", "TOME_BOOK", "Tome");
	}

	public unsafe override string GetInternalName()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		return ((Enum)(&obj)).ToString();
	}

	public int GetLevel()
	{
		//IL_007d: Expected I4, but got O
		if ((object)GameManager.Instance != null)
		{
			PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
			if (playerInventory != null && playerInventory.tomeInventory != null)
			{
				return playerInventory.tomeInventory.GetTomeLevel(eTome);
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetMaxLevel()
	{
		return InventoryUtility.GetTomeMaxLevel();
	}

	public List<StatModifier> GetUpgradeOffer(ERarity rarity)
	{
		if (eTome != ETome.Balance)
		{
			if (rarity != ERarity.New)
			{
				StatModifier statModifier = new StatModifier();
				StatModifier statModifier2 = this.statModifier;
				if (this.statModifier != null && statModifier != null)
				{
					statModifier.stat = statModifier2.stat;
					StatModifier statModifier3 = this.statModifier;
					if (this.statModifier != null)
					{
						float rarityValue = StatUtility.GetRarityValue(statModifier3.modification, rarity);
						statModifier.modification = rarityValue;
						StatModifier statModifier4 = this.statModifier;
						if (this.statModifier != null)
						{
							statModifier.modifyType = statModifier4.modifyType;
							List<StatModifier> list = new List<StatModifier>();
							if (list != null)
							{
								list.Add(statModifier);
								return list;
							}
						}
					}
				}
			}
			else
			{
				List<StatModifier> list2 = new List<StatModifier>();
				if (list2 != null)
				{
					list2.Add(this.statModifier);
					return list2;
				}
			}
			return (List<StatModifier>)(object)new NullReferenceException();
		}
		return new List<StatModifier>();
	}
}
