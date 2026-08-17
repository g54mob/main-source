using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public static class ItemUtility
{
	public unsafe static ItemData GetRandomChestItem(EChest chestType, float luck)
	{
		//IL_030e: Expected O, but got I8
		//IL_0328: Expected O, but got I4
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_0493: Expected O, but got Ref
		//IL_008b: Expected O, but got Ref
		//IL_00cb: Expected I, but got O
		//IL_00d3: Expected O, but got I4
		//IL_0162: Expected O, but got Ref
		//IL_0188: Expected I, but got O
		//IL_01d4: Expected I, but got O
		//IL_0217: Expected I, but got O
		//IL_02f2: Expected I, but got O
		//IL_02d4: Expected I, but got O
		//IL_02b6: Expected I, but got O
		//IL_0298: Expected I, but got O
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		nint num = default(nint);
		string text;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			StatsSaveFile stats = saveManager.stats;
			Dictionary<string, MyStat> dictionary;
			if (saveManager.stats != null)
			{
				if (stats.stats != null)
				{
					string key = ((Enum)(&num)).ToString();
					bool flag = stats.stats.ContainsKey(key);
					bool? flag2 = flag;
					nint num2 = 0;
					num = (nint)typeof(EMyStat);
					text = (string)flag;
					dictionary = null;
				}
				else
				{
					dictionary = stats.stats;
				}
			}
			else
			{
				dictionary = null;
			}
			object obj = (object)dictionary >> 8;
			object obj2 = obj - 1;
			bool flag3 = obj2 == null;
			object obj3 = dictionary & flag3;
			if (obj3 != null)
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
				{
					StatsSaveFile stats2 = saveManager2.stats;
					if (saveManager2.stats != null)
					{
						string text2 = ((Enum)(&num)).ToString();
						bool flag4 = stats2.stats == null;
						num = (nint)typeof(EMyStat);
						text = null;
						if (!flag4)
						{
							MyStat myStat = stats2.stats.get_Item(text2);
							bool flag5 = myStat == null;
							nint num2 = 0;
							num = (nint)typeof(EMyStat);
							text = text2;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rax+18h]\"");
								bool flag6 = (nint)myStat > 6;
								num2 = 0;
								num = (nint)typeof(EMyStat);
								text = text2;
								if (flag6)
								{
									goto IL_02fc;
								}
								if ((nint)myStat != 1)
								{
									if ((nint)myStat != 3)
									{
										if ((nint)myStat != 6)
										{
											num2 = 0;
											num = (nint)typeof(EMyStat);
											text = null;
										}
										else
										{
											num2 = 0;
											num = (nint)typeof(EMyStat);
											text = null;
										}
									}
									else
									{
										num2 = 0;
										num = (nint)typeof(EMyStat);
										text = null;
									}
								}
								else
								{
									num2 = 0;
									num = (nint)typeof(EMyStat);
									text = null;
								}
								goto IL_0467;
							}
						}
					}
				}
				goto IL_045b;
			}
		}
		goto IL_02fc;
		IL_02fc:
		object obj4 = (long)chestType & 0xFFFFFFFCL;
		bool flag7 = obj4 == null;
		object obj5 = !flag7;
		if ((obj5 != null || chestType == EChest.Corrupt) && chestType != EChest.Ghost)
		{
			if (chestType != EChest.Corrupt)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
				string text3 = ((Enum)(&num)).ToString();
				string message = "Chest not implemented: " + text3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				Exception ex = new Exception(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
				throw ex;
			}
		}
		else
		{
			EItemRarity itemRarity = Rarity.GetItemRarity(luck);
		}
		text = null;
		goto IL_0467;
		IL_045b:
		throw new NullReferenceException();
		IL_0467:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 378 Invalid \"Jump target not found in method: 0x180444FF0\"");
		goto IL_045b;
	}

	public static ItemData GetRandomItem(float luck)
	{
		EItemRarity itemRarity = Rarity.GetItemRarity(luck);
		return GetRandomItemFromRarity(itemRarity);
	}

	public unsafe static ItemData GetRandomItemFromRarity(EItemRarity rarity)
	{
		//IL_0041: Expected O, but got Ref
		if (rarity == EItemRarity.Legendary)
		{
			float num = UnityEngine.Random.Range(0f, 1f);
			if (0.0025f > num)
			{
				object obj = default(object);
				string statName = ((Enum)(&obj)).ToString();
				float stat = MyStats.GetStat(statName);
				if (!(stat < 6f))
				{
					if ((object)DataManager.Instance != null)
					{
						return DataManager.Instance.GetItem(EItem.GoldenRing);
					}
					goto IL_0165;
				}
			}
		}
		if (RunUnlockables.availableItems != null)
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)rarity);
			if (RunUnlockables.availableItems != null)
			{
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)RunUnlockables.availableItems).get_Item((System.Int32Enum)rarity);
				if (obj3 != null && MyRandom.random != null)
				{
					System.Random random = MyRandom.random;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v12 (System.Object)+18]");
					int index = random.Next(0, 0);
					if (obj2 != null)
					{
						return ((List<ItemData>)obj2).get_Item(index);
					}
				}
			}
		}
		goto IL_0165;
		IL_0165:
		return (ItemData)(object)new NullReferenceException();
	}

	public static bool TryProc(float procCoefficient, float baseProcChance)
	{
		//IL_005d: Expected I4, but got O
		bool flag = (nint)MyRandom.random < 0;
		bool flag2 = MyRandom.random == null;
		if (!flag2)
		{
			double num = MyRandom.random.NextDouble();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
