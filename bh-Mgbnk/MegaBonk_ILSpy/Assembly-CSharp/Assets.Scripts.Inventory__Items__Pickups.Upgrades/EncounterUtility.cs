using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.InGame.Rewards.Effects;
using Cpp2ILInjected;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Upgrades;

public class EncounterUtility
{
	public static List<EStat> upgradableStatsShrines;

	public static List<EStat> upgradableStatsChaosAndGamble;

	private static List<EStat> upgradableStatsBalanceShrine;

	public static List<EStat> GetRandomStats(int amount)
	{
		//IL_0132: Expected O, but got I4
		//IL_005d: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		List<EStat> list = new List<EStat>();
		List<EStat> list2 = (List<EStat>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)upgradableStatsShrines);
		bool flag = amount <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				Random random = MyRandom.random;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v7 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
				int index = random.Next(0, 0);
				EStat item = list2.get_Item(index);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v13+18]");
				if (num >= 0)
				{
					list.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v13+18]");
					if (num2 >= 0)
					{
						return (List<EStat>)(object)new IndexOutOfRangeException();
					}
				}
				list2.RemoveAt(index);
				obj++;
			}
			while ((nint)obj < amount);
		}
		return list;
	}

	public static List<EStat> GetRandomStatsChaosAndGamble(int amount)
	{
		//IL_0132: Expected O, but got I4
		//IL_005d: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		List<EStat> list = new List<EStat>();
		List<EStat> list2 = (List<EStat>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)upgradableStatsChaosAndGamble);
		bool flag = amount <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				Random random = MyRandom.random;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v7 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
				int index = random.Next(0, 0);
				EStat item = list2.get_Item(index);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v13+18]");
				if (num >= 0)
				{
					list.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v13+18]");
					if (num2 >= 0)
					{
						return (List<EStat>)(object)new IndexOutOfRangeException();
					}
				}
				list2.RemoveAt(index);
				obj++;
			}
			while ((nint)obj < amount);
		}
		return list;
	}

	public static List<EStat> GetRandomStatsBalanceShrine(int amount)
	{
		//IL_0132: Expected O, but got I4
		//IL_005d: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		List<EStat> list = new List<EStat>();
		List<EStat> list2 = (List<EStat>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)upgradableStatsBalanceShrine);
		bool flag = amount <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				Random random = MyRandom.random;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v7 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
				int index = random.Next(0, 0);
				EStat item = list2.get_Item(index);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v13+18]");
				if (num >= 0)
				{
					list.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v13+18]");
					if (num2 >= 0)
					{
						return (List<EStat>)(object)new IndexOutOfRangeException();
					}
				}
				list2.RemoveAt(index);
				obj++;
			}
			while ((nint)obj < amount);
		}
		return list;
	}

	public static List<EncounterOffer> GetRandomStatOffers(int amount, bool forceLegendary = false, bool useShrineStats = true)
	{
		//IL_0143: Expected I4, but got O
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected I4, but got Unknown
		//IL_020b: Expected I, but got O
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected I4, but got Unknown
		if (!useShrineStats)
		{
			List<EStat> randomStatsChaosAndGamble = GetRandomStatsChaosAndGamble(amount);
		}
		else
		{
			List<EStat> randomStatsChaosAndGamble = GetRandomStats(amount);
		}
		List<EncounterOffer> list = new List<EncounterOffer>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
		nint num = 0;
		List<EStat>.Enumerator enumerator = default(List<EStat>.Enumerator);
		EStat stat2 = default(EStat);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				EncounterOffer encounterOffer = new EncounterOffer();
				float stat = PlayerStats.GetStat(EStat.Luck);
				ERarity upgradeOfferRarity = Rarity.GetUpgradeOfferRarity(stat);
				bool flag = encounterOffer == null;
				EStat eStat = EStat.Luck;
				if (!flag)
				{
					encounterOffer.rarity = upgradeOfferRarity;
					if (forceLegendary)
					{
						encounterOffer.rarity = ERarity.Legendary;
					}
					StatModifier statModifier = new StatModifier();
					float randomStatValue = GetRandomStatValue(stat2, out var type);
					float multiplier = Rarity.GetMultiplier(encounterOffer.rarity);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180436390");
					bool flag2 = statModifier == null;
					eStat = (EStat)typeof(Math);
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
						statModifier.modification = 0f;
						statModifier.stat = stat2;
						statModifier.modifyType = type;
						EffectStat[] array = new EffectStat[1];
						EffectStat effectStat = new EffectStat();
						if (effectStat != null)
						{
							effectStat.effectType = EEncounterEffect.StatChange;
							effectStat.statModifier = statModifier;
							eStat = (EStat)(effectStat + 24);
							if (array != null)
							{
								nint num2 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
								if (obj == null)
								{
									break;
								}
								if (array.Length > 0)
								{
									array[0] = effectStat;
									encounterOffer.effects = array;
									eStat = (EStat)(encounterOffer + 24);
									if (list != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180001FF0");
										num = 0;
										continue;
									}
									throw new NullReferenceException();
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return list;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
		EffectStat effectStat2 = default(EffectStat);
		throw effectStat2;
	}

	public static List<EncounterOffer> GetBalanceShrineOffers(int amount)
	{
		//IL_0057: Expected O, but got I4
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01a6: Expected O, but got I4
		//IL_01ae: Expected I4, but got O
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01ce: Expected I4, but got O
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02d4: Expected I4, but got O
		//IL_02ea: Expected I, but got O
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03bf: Expected I4, but got O
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		int amount2 = amount + amount;
		List<EStat> randomStatsBalanceShrine = GetRandomStatsBalanceShrine(amount2);
		List<EncounterOffer> list = new List<EncounterOffer>();
		if (amount > 0)
		{
			object obj = 0;
			do
			{
				EncounterOffer encounterOffer = new EncounterOffer();
				bool flag = list == null;
				int num = 0;
				EncounterOffer encounterOffer2 = encounterOffer;
				if (!flag)
				{
					int version = list._version + 1;
					list._version = version;
					encounterOffer2 = (EncounterOffer)(object)list._items;
					bool flag2 = list._items == null;
					num = 0;
					if (!flag2)
					{
						if (list._size >= (nint)encounterOffer2.effects)
						{
							((List<object>)(object)list).AddWithResize((object)encounterOffer);
						}
						else
						{
							int size = list._size + 1;
							list._size = size;
							if (list._size >= (nint)encounterOffer2.effects)
							{
								goto IL_040e;
							}
						}
						EffectStat[] array = new EffectStat[2];
						bool flag3 = encounterOffer == null;
						num = 2;
						encounterOffer2 = (EncounterOffer)(object)typeof(EffectStat[]);
						if (!flag3)
						{
							encounterOffer2 = (EncounterOffer)(encounterOffer + 24);
							encounterOffer.effects = array;
							object obj2 = 0;
							num = (int)array;
							while (true)
							{
								encounterOffer.rarity = ERarity.Rare;
								if (randomStatsBalanceShrine == null)
								{
									break;
								}
								object obj3 = obj * 2;
								int index = (int)(obj2 + obj3);
								EStat stat = randomStatsBalanceShrine.get_Item(index);
								float modification = (((nint)obj2 != 1) ? 2f : 0.5f);
								StatModifier statModifier = new StatModifier();
								bool flag4 = statModifier == null;
								num = 0;
								encounterOffer2 = (EncounterOffer)(object)statModifier;
								if (flag4)
								{
									break;
								}
								statModifier.modification = modification;
								statModifier.stat = stat;
								statModifier.modifyType = EStatModifyType.Multiplication;
								EffectStat[] effects = encounterOffer.effects;
								EffectStat effectStat = new EffectStat();
								bool flag5 = effectStat == null;
								num = 0;
								encounterOffer2 = (EncounterOffer)(object)effectStat;
								if (flag5)
								{
									break;
								}
								encounterOffer2 = (EncounterOffer)(effectStat + 24);
								effectStat.effectType = EEncounterEffect.StatChangeBalanceShrine;
								effectStat.statModifier = statModifier;
								bool flag6 = encounterOffer.effects == null;
								num = (int)statModifier;
								if (flag6)
								{
									break;
								}
								nint num2 = (nint)effects;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rdx_v19 (Il2CppClass<Assets.Scripts.UI.InGame.Rewards.EffectStat[]>)+40]");
								num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rdx_v19 (Il2CppClass<Assets.Scripts.UI.InGame.Rewards.EffectStat[]>)+40]");
								EStat eStat = ((List<EStat>)(object)effectStat).get_Item(0);
								bool flag7 = eStat == EStat.MaxHealth;
								encounterOffer2 = (EncounterOffer)(object)effectStat;
								if (!flag7)
								{
									if ((nint)obj2 < effects.Length)
									{
										object obj4 = obj2 + 4;
										effects[obj2] = effectStat;
										object obj5 = obj4 * 8;
										encounterOffer2 = (EncounterOffer)(object)((object)encounterOffer.effects + obj5);
										obj2++;
										bool flag8 = (nint)obj2 < 2;
										num = (int)effectStat;
										if (flag8)
										{
											continue;
										}
										goto IL_03cd;
									}
									goto IL_040e;
								}
								EStat eStat2 = ((List<EStat>)(object)encounterOffer2).get_Item(num);
								throw eStat2;
							}
						}
					}
				}
				throw new NullReferenceException();
				IL_03cd:
				obj++;
				continue;
				IL_040e:
				return (List<EncounterOffer>)(object)new IndexOutOfRangeException();
			}
			while ((nint)obj < amount);
		}
		return list;
	}

	private unsafe static float GetRandomStatValue(EStat stat, out EStatModifyType type)
	{
		//IL_006d: Expected F4, but got I4
		//IL_0033: Expected O, but got I8
		//IL_0043: Expected O, but got I
		//IL_005d: Expected O, but got I8
		ref EStatModifyType reference = ref *(EStatModifyType*)2;
		if (stat <= EStat.SilverIncreaseMultiplier)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r8_v1+436C24+stat @ rcx (Assets.Scripts.Menu.Shop.EStat)]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r8_v1+436BE0+v17 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 0f;
	}

	static EncounterUtility()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_15bc: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_15e4: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_160c: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_1634: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_165c: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_1684: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_16ac: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_16d4: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_16fc: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_1724: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_174c: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_1774: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_179c: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_17c4: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_17ec: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_1814: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_183c: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_1864: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_188c: Expected O, but got I
		//IL_0860: Expected O, but got I
		//IL_18b4: Expected O, but got I
		//IL_08ca: Expected O, but got I
		//IL_18dc: Expected O, but got I
		//IL_0934: Expected O, but got I
		//IL_1904: Expected O, but got I
		//IL_099e: Expected O, but got I
		//IL_192c: Expected O, but got I
		//IL_0a08: Expected O, but got I
		//IL_1954: Expected O, but got I
		//IL_0a72: Expected O, but got I
		//IL_197c: Expected O, but got I
		//IL_0adc: Expected O, but got I
		//IL_19a4: Expected O, but got I
		//IL_0b46: Expected O, but got I
		//IL_19cc: Expected O, but got I
		//IL_0bb0: Expected O, but got I
		//IL_0be8: Expected O, but got I
		//IL_0c42: Expected O, but got I
		//IL_1a0c: Expected O, but got I
		//IL_0cac: Expected O, but got I
		//IL_1a34: Expected O, but got I
		//IL_0d16: Expected O, but got I
		//IL_1a5c: Expected O, but got I
		//IL_0d80: Expected O, but got I
		//IL_1a84: Expected O, but got I
		//IL_0dea: Expected O, but got I
		//IL_1aac: Expected O, but got I
		//IL_0e54: Expected O, but got I
		//IL_1ad4: Expected O, but got I
		//IL_0ebe: Expected O, but got I
		//IL_1afc: Expected O, but got I
		//IL_0f28: Expected O, but got I
		//IL_1b24: Expected O, but got I
		//IL_0f92: Expected O, but got I
		//IL_1b4c: Expected O, but got I
		//IL_0ffc: Expected O, but got I
		//IL_1b74: Expected O, but got I
		//IL_1066: Expected O, but got I
		//IL_1b9c: Expected O, but got I
		//IL_10d0: Expected O, but got I
		//IL_1bc4: Expected O, but got I
		//IL_113a: Expected O, but got I
		//IL_1bec: Expected O, but got I
		//IL_11a4: Expected O, but got I
		//IL_1c14: Expected O, but got I
		//IL_120e: Expected O, but got I
		//IL_1c3c: Expected O, but got I
		//IL_1278: Expected O, but got I
		//IL_1c64: Expected O, but got I
		//IL_12e2: Expected O, but got I
		//IL_1c8c: Expected O, but got I
		//IL_134c: Expected O, but got I
		List<EStat> list = new List<EStat>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(EStat.MaxHealth);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(EStat.HealthRegen);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v10+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(EStat.Shield);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v12+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(EStat.Thorns);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v14+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(EStat.Armor);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v16+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(EStat.Evasion);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v18+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(EStat.SizeMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v20+18]");
		if (num8 >= 0)
		{
			list.AddWithResize(EStat.DurationMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v22+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(EStat.ProjectileSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v24+18]");
		if (num10 >= 0)
		{
			list.AddWithResize(EStat.DamageMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v26+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(EStat.AttackSpeed);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v28+18]");
		if (num12 >= 0)
		{
			list.AddWithResize(EStat.Projectiles);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v30+18]");
		if (num13 >= 0)
		{
			list.AddWithResize(EStat.Lifesteal);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v32+18]");
		if (num14 >= 0)
		{
			list.AddWithResize(EStat.CritChance);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v34+18]");
		if (num15 >= 0)
		{
			list.AddWithResize(EStat.CritDamage);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v36+18]");
		if (num16 >= 0)
		{
			list.AddWithResize(EStat.EliteDamageMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v38+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(EStat.KnockbackMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v40+18]");
		if (num18 >= 0)
		{
			list.AddWithResize(EStat.MoveSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 25;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v42+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(EStat.JumpHeight);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 26;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v44+18]");
		if (num20 >= 0)
		{
			list.AddWithResize(EStat.PickupRange);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 29;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v46+18]");
		if (num21 >= 0)
		{
			list.AddWithResize(EStat.Luck);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 30;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v48+18]");
		if (num22 >= 0)
		{
			list.AddWithResize(EStat.GoldIncreaseMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 31;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v50+18]");
		if (num23 >= 0)
		{
			list.AddWithResize(EStat.XpIncreaseMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 32;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v52+18]");
		if (num24 >= 0)
		{
			list.AddWithResize(EStat.EliteSpawnIncrease);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 39;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v54+18]");
		if (num25 >= 0)
		{
			list.AddWithResize(EStat.PowerupBoostMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v56+18]");
		if (num26 >= 0)
		{
			list.AddWithResize(EStat.PowerupChance);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 41;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v58+18]");
		if (num27 >= 0)
		{
			list.AddWithResize(EStat.Difficulty);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 38;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v60+18]");
		if (num28 >= 0)
		{
			list.AddWithResize(EStat.ExtraJumps);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v2 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 46;
		}
		upgradableStatsShrines = list;
		List<EStat> list2 = new List<EStat>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v67+18]");
		if (num29 >= 0)
		{
			list2.AddWithResize(EStat.MaxHealth);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v69+18]");
		if (num30 >= 0)
		{
			list2.AddWithResize(EStat.HealthRegen);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v71+18]");
		if (num31 >= 0)
		{
			list2.AddWithResize(EStat.Shield);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v73+18]");
		if (num32 >= 0)
		{
			list2.AddWithResize(EStat.Thorns);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v75+18]");
		if (num33 >= 0)
		{
			list2.AddWithResize(EStat.Armor);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj66 = (nint)0 + (nint)1;
			_ = 4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rcx_v77+18]");
		if (num34 >= 0)
		{
			list2.AddWithResize(EStat.Evasion);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj68 = (nint)0 + (nint)1;
			_ = 5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rcx_v79+18]");
		if (num35 >= 0)
		{
			list2.AddWithResize(EStat.SizeMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj70 = (nint)0 + (nint)1;
			_ = 9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v81+18]");
		if (num36 >= 0)
		{
			list2.AddWithResize(EStat.DurationMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj72 = (nint)0 + (nint)1;
			_ = 10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj73 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v83+18]");
		if (num37 >= 0)
		{
			list2.AddWithResize(EStat.ProjectileSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj74 = (nint)0 + (nint)1;
			_ = 11;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj75 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v85+18]");
		if (num38 >= 0)
		{
			list2.AddWithResize(EStat.DamageMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj76 = (nint)0 + (nint)1;
			_ = 12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj77 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v87+18]");
		if (num39 >= 0)
		{
			list2.AddWithResize(EStat.AttackSpeed);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj78 = (nint)0 + (nint)1;
			_ = 15;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj79 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num40 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rcx_v89+18]");
		if (num40 >= 0)
		{
			list2.AddWithResize(EStat.Projectiles);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj80 = (nint)0 + (nint)1;
			_ = 16;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj81 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v91+18]");
		if (num41 >= 0)
		{
			list2.AddWithResize(EStat.Lifesteal);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj82 = (nint)0 + (nint)1;
			_ = 17;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj83 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v93+18]");
		if (num42 >= 0)
		{
			list2.AddWithResize(EStat.CritChance);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj84 = (nint)0 + (nint)1;
			_ = 18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj85 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v95+18]");
		if (num43 >= 0)
		{
			list2.AddWithResize(EStat.CritDamage);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj86 = (nint)0 + (nint)1;
			_ = 19;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj87 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num44 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v97+18]");
		if (num44 >= 0)
		{
			list2.AddWithResize(EStat.EliteDamageMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj88 = (nint)0 + (nint)1;
			_ = 23;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj89 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v99+18]");
		if (num45 >= 0)
		{
			list2.AddWithResize(EStat.KnockbackMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj90 = (nint)0 + (nint)1;
			_ = 24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+10]");
		object obj91 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
		nint num46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v101+18]");
		if (num46 >= 0)
		{
			list2.AddWithResize(EStat.MoveSpeedMultiplier);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rax_v39 (System.Collections.Generic.List`1<Assets.Scripts.Menu.Shop.EStat>)+18]");
			object obj92 = (nint)0 + (nint)1;
			_ = 25;
		}
		list2.Add(EStat.PickupRange);
		list2.Add(EStat.Luck);
		list2.Add(EStat.GoldIncreaseMultiplier);
		list2.Add(EStat.XpIncreaseMultiplier);
		list2.Add(EStat.EliteSpawnIncrease);
		list2.Add(EStat.PowerupBoostMultiplier);
		list2.Add(EStat.PowerupChance);
		list2.Add(EStat.Difficulty);
		list2.Add(EStat.ExtraJumps);
		upgradableStatsChaosAndGamble = list2;
		upgradableStatsBalanceShrine = new List<EStat>
		{
			EStat.MaxHealth,
			EStat.HealthRegen,
			EStat.Shield,
			EStat.Thorns,
			EStat.Armor,
			EStat.Evasion,
			EStat.SizeMultiplier,
			EStat.DurationMultiplier,
			EStat.ProjectileSpeedMultiplier,
			EStat.DamageMultiplier,
			EStat.AttackSpeed,
			EStat.Lifesteal,
			EStat.CritChance,
			EStat.CritDamage,
			EStat.EliteDamageMultiplier,
			EStat.KnockbackMultiplier,
			EStat.MoveSpeedMultiplier,
			EStat.JumpHeight,
			EStat.FallDamageReduction,
			EStat.PickupRange,
			EStat.Luck,
			EStat.GoldIncreaseMultiplier,
			EStat.XpIncreaseMultiplier,
			EStat.PowerupBoostMultiplier,
			EStat.PowerupChance
		};
	}
}
