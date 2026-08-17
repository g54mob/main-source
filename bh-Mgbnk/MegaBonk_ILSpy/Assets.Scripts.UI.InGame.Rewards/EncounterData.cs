using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Upgrades;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.UI.InGame.Rewards;

public class EncounterData : ScriptableObject
{
	public EEncounter encounterType;

	public EncounterOffer[] offers;

	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public string GetName()
	{
		if (localizedName != null)
		{
			return localizedName.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public string GetDescription()
	{
		if (localizedDescription != null)
		{
			return localizedDescription.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public EncounterOffer[] GetOffers()
	{
		//IL_00ed: Expected I, but got O
		//IL_00f5: Expected I, but got O
		//IL_0142: Expected O, but got I
		//IL_0178: Expected O, but got I4
		//IL_01ba: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		EncounterOffer[] array;
		ItemBase item;
		ItemBase itemBase;
		if (encounterType != EEncounter.RandomStats)
		{
			if (encounterType != EEncounter.BalanceShrine)
			{
				return offers;
			}
			List<EncounterOffer> balanceShrineOffers = EncounterUtility.GetBalanceShrineOffers(2);
			if (balanceShrineOffers != null)
			{
				return balanceShrineOffers.ToArray();
			}
		}
		else
		{
			ChargeShrine lastRewardShrine = ChargeShrine.lastRewardShrine;
			if ((object)ChargeShrine.lastRewardShrine != null)
			{
				List<EncounterOffer> randomStatOffers = EncounterUtility.GetRandomStatOffers(3, lastRewardShrine._003CisGolden_003Ek__BackingField);
				if (randomStatOffers != null)
				{
					array = randomStatOffers.ToArray();
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						PlayerInventory inventory = instance.inventory;
						if (instance.inventory != null && inventory.itemInventory != null)
						{
							item = inventory.itemInventory.GetItem(EItem.Wrench);
							if (item == null)
							{
								goto IL_02f7;
							}
							nint num = (nint)typeof(ItemWrench);
							nint num2 = (nint)item;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r8_v6 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
							EItem eItem = EItem.Key;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v5 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ r8_v6 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWrench>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r9_v5 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v26+FFFFFFF8+v426 @ rcx_v17 (Assets.Scripts.Inventory__Items__Pickups.Items.EItem)*8]");
								if (0 == (nint)typeof(ItemWrench))
								{
									itemBase = (ItemBase)1;
									goto IL_03fd;
								}
							}
							itemBase = null;
							goto IL_03fd;
						}
					}
				}
			}
		}
		goto IL_03c8;
		IL_03c8:
		return (EncounterOffer[])(object)new NullReferenceException();
		IL_02f7:
		return array;
		IL_03fd:
		bool flag = itemBase == null;
		ItemBase itemBase2 = null;
		if (!flag)
		{
			itemBase2 = item;
		}
		if (itemBase2 != null)
		{
			if (array == null)
			{
				goto IL_03c8;
			}
			object obj2 = 0;
			object obj3 = 0;
			object obj5 = default(object);
			while ((nint)obj3 < array.Length)
			{
				EncounterOffer encounterOffer = array[obj2];
				if (array[obj2] != null)
				{
					EffectStat[] effects = encounterOffer.effects;
					bool flag2 = encounterOffer.effects == null;
					object obj4 = 0;
					if (!flag2)
					{
						while ((nint)obj4 < effects.Length)
						{
							EffectStat effectStat = effects[obj4];
							if (effects[obj4] != null)
							{
								StatModifier statModifier = effectStat.statModifier;
								if (effectStat.statModifier != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180462D90");
									float modification = (float)obj5 * statModifier.modification;
									obj4++;
									statModifier.modification = modification;
									continue;
								}
							}
							goto IL_03c8;
						}
						obj2++;
						obj3 = obj2;
						continue;
					}
				}
				goto IL_03c8;
			}
		}
		goto IL_02f7;
	}

	public bool HasRarity()
	{
		//IL_0010: Expected O, but got I4
		object obj = encounterType - 1;
		return obj == null;
	}
}
