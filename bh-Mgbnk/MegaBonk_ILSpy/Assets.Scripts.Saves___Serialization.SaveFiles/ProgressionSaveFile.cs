using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts._Data.Progression;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Cpp2ILInjected;
using Inventory__Items__Pickups;
using Inventory__Items__Pickups.Xp_and_Levels;

namespace Assets.Scripts.Saves___Serialization.SaveFiles;

[Serializable]
public class ProgressionSaveFile
{
	public int gold;

	public int silver;

	public Dictionary<EShopItem, int> shopItems;

	public Dictionary<ECharacter, CharacterProgression> characterProgression;

	public HashSet<string> achievements;

	public HashSet<string> claimedAchievements;

	public HashSet<string> purchases;

	public HashSet<string> inactivated;

	public bool hasNewQuestDone;

	public MenuMeta menuMeta;

	public HashSet<string> newUnlockables;

	public HashSet<string> newShopItems;

	public HashSet<string> newMaps;

	public static Action<int> A_SilverChanged;

	public static Action<MyAchievement> A_AchievementClaimed;

	public static Action<UnlockableBase> A_UnlockablePurchased;

	public unsafe void Init()
	{
		//IL_0044: Expected O, but got Ref
		//IL_004c: Expected O, but got Ref
		//IL_00ae: Expected I4, but got O
		//IL_00c9: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_05fc: Expected O, but got I
		//IL_01b3: Expected I, but got O
		//IL_01bb: Expected I, but got O
		//IL_01ea: Expected I, but got O
		//IL_01f8: Expected I, but got O
		//IL_032f: Expected O, but got I
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0237: Expected I, but got O
		//IL_0245: Expected I, but got O
		//IL_026c: Expected I4, but got O
		//IL_027e: Expected I, but got O
		//IL_0286: Expected I4, but got O
		//IL_0705: Expected I, but got O
		//IL_0713: Expected I, but got O
		//IL_02c3: Expected I, but got O
		//IL_073d: Expected I, but got O
		//IL_074b: Expected I4, but got O
		//IL_02ef: Expected I4, but got O
		//IL_02fd: Expected I4, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EShopItem));
		Array values = Enum.GetValues(typeFromHandle);
		IEnumerator enumerator = values.GetEnumerator();
		IEnumerator enumerator2 = default(IEnumerator);
		object obj = (object)(&enumerator2);
		Delegate obj3 = default(Delegate);
		object obj2 = (object)(&obj3);
		EShopItem eShopItem = EShopItem.Refresh;
		Array array = values;
		object obj5 = default(object);
		object obj14 = default(object);
		object obj15 = default(object);
		Delegate obj4;
		nint num3;
		while (true)
		{
			bool flag = enumerator2 == null;
			obj4 = (Delegate)enumerator2;
			nint num2;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
				if (obj5 != null)
				{
					bool flag2 = enumerator2 == null;
					obj4 = (Delegate)enumerator2;
					eShopItem = (EShopItem)typeof(IEnumerator);
					array = null;
					if (!flag2)
					{
						nint num = (nint)enumerator2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v10 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_013d;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v10 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						num2 = 0;
						Delegate obj6 = null;
						while (true)
						{
							object obj7 = (object)obj6 + (object)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ r8_v7 (Il2CppClass<Assets.Scripts._Data.ShopItems.EShopItem>)+v477 @ rax_v73*8]");
							if (0 == (nint)typeof(IEnumerator))
							{
								break;
							}
							obj6 = (Delegate)(obj6 + 1);
							Delegate obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r10_v10 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_013d;
						}
						object obj9 = (object)obj6 + (object)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ r8_v7 (Il2CppClass<Assets.Scripts._Data.ShopItems.EShopItem>)+8+v542 @ rcx_v66*8]");
						object obj10 = (nint)0 + (nint)1;
						object obj11 = obj10 << 4;
						object obj12 = obj11 + 312;
						object obj13 = obj12 + num;
						goto IL_0155;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				obj2 = obj14;
				if (obj14 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				}
				break;
			}
			throw new NullReferenceException();
			IL_013d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
			num2 = 1;
			goto IL_0155;
			IL_0155:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v64+8]");
			eShopItem = EShopItem.Refresh;
			object current = enumerator2.Current;
			bool flag3 = current == null;
			num3 = (nint)typeof(IEnumerator);
			array = (Array)enumerator2;
			if (!flag3)
			{
				nint num4 = (nint)typeof(EShopItem);
				nint num5 = (nint)current;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdx_v48 (Il2CppClass<System.Object>)+40]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ r8_v17 (Il2CppClass<Assets.Scripts._Data.ShopItems.EShopItem>)+40]");
				bool flag4 = num6 != 0;
				num2 = (nint)typeof(EShopItem);
				num3 = (nint)typeof(IEnumerator);
				array = (Array)current;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					bool flag5 = shopItems == null;
					num2 = (nint)typeof(EShopItem);
					num3 = (nint)typeof(IEnumerator);
					array = (Array)(object)shopItems;
					if (!flag5)
					{
						bool flag6 = shopItems.ContainsKey((EShopItem)obj15);
						num3 = (nint)typeof(IEnumerator);
						eShopItem = (EShopItem)obj15;
						array = (Array)(object)shopItems;
						if (!flag6)
						{
							bool flag7 = shopItems == null;
							num2 = 0;
							num3 = (nint)typeof(IEnumerator);
							array = (Array)(object)shopItems;
							if (flag7)
							{
								throw new NullReferenceException();
							}
							((Dictionary<System.Int32Enum, int>)(object)shopItems).Add((System.Int32Enum)obj15, 0);
							num3 = 0;
							eShopItem = (EShopItem)obj15;
							array = (Array)(object)shopItems;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				eShopItem = (EShopItem)num2;
			}
			obj4 = (Delegate)num2;
			throw new NullReferenceException();
		}
		if (claimedAchievements == null)
		{
			HashSet<string> hashSet = (HashSet<string>)(object)new HashSet<object>();
			claimedAchievements = hashSet;
		}
		if (purchases == null)
		{
			HashSet<string> hashSet2 = (HashSet<string>)(object)new HashSet<object>();
			purchases = hashSet2;
		}
		if (achievements == null)
		{
			HashSet<string> hashSet3 = (HashSet<string>)(object)new HashSet<object>();
			achievements = hashSet3;
		}
		if (claimedAchievements == null)
		{
			HashSet<string> hashSet4 = (HashSet<string>)(object)new HashSet<object>();
			claimedAchievements = hashSet4;
		}
		if (inactivated == null)
		{
			HashSet<string> hashSet5 = (HashSet<string>)(object)new HashSet<object>();
			inactivated = hashSet5;
		}
		if (characterProgression == null)
		{
			Dictionary<ECharacter, CharacterProgression> dictionary = new Dictionary<ECharacter, CharacterProgression>();
			characterProgression = dictionary;
		}
		if (gold < 0)
		{
			gold = 0;
		}
		Action b = OnGameOver;
		Delegate obj16 = Delegate.Combine(GameManager.A_GameOver, b);
		if ((object)obj16 == null)
		{
			GameManager.A_GameOver = null;
			return;
		}
		bool flag8 = (object)obj16.GetType() != typeof(Action);
		Delegate obj17 = null;
		if (!flag8)
		{
			obj17 = obj16;
		}
		bool flag9 = (object)obj17 == null;
		obj4 = obj16;
		num3 = unchecked((nint)null);
		nint num7 = (nint)typeof(Action);
		if (!flag9)
		{
			GameManager.A_GameOver = (Action)obj17;
			bool flag10 = (object)obj16.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag10)
			{
				obj18 = obj16;
			}
			bool flag11 = (object)obj18 == null;
			obj4 = obj16;
			num3 = unchecked((nint)null);
			eShopItem = (EShopItem)typeof(Action);
			if (!flag11)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void OnDestroy()
	{
		//IL_0124: Expected I, but got O
		Action value = OnGameOver;
		Delegate obj = Delegate.Remove(GameManager.A_GameOver, value);
		if ((object)obj == null)
		{
			GameManager.A_GameOver = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_GameOver = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void CompleteAchievement(MyAchievement achievement)
	{
		//IL_0073: Expected I, but got O
		//IL_007b: Expected I, but got O
		//IL_008b: Expected O, but got I
		//IL_0111: Expected I, but got O
		//IL_0121: Expected O, but got I
		//IL_01a7: Expected I, but got O
		//IL_01b7: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_022b: Expected I, but got O
		//IL_023b: Expected O, but got I
		//IL_015d: Expected O, but got I
		//IL_02af: Expected I, but got O
		//IL_02bf: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_0333: Expected I, but got O
		//IL_0343: Expected O, but got I
		//IL_0277: Expected O, but got I
		//IL_03b7: Expected I, but got O
		//IL_03c7: Expected O, but got I
		//IL_02fb: Expected O, but got I
		//IL_037f: Expected O, but got I
		//IL_0403: Expected O, but got I
		HashSet<string> hashSet;
		if (achievement._003Cunlockable_003Ek__BackingField != null)
		{
			UnlockableBase unlockableBase = achievement._003Cunlockable_003Ek__BackingField;
			if ((object)achievement._003Cunlockable_003Ek__BackingField != null)
			{
				nint num = (nint)typeof(ShopItemData);
				nint num2 = (nint)unlockableBase;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v7 (Il2CppClass<ShopItemData>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v7 (Il2CppClass<ShopItemData>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v31+FFFFFFF8+v213 @ rax_v8*8]");
					if (0 == (nint)typeof(ShopItemData))
					{
						hashSet = newShopItems;
						goto IL_047e;
					}
				}
				nint num4 = (nint)typeof(MapData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v9 (Il2CppClass<MapData>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v9 (Il2CppClass<MapData>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v30+FFFFFFF8+v255 @ rax_v13*8]");
					if (0 == (nint)typeof(MapData))
					{
						hashSet = newMaps;
						goto IL_047e;
					}
				}
				nint num6 = (nint)typeof(CharacterData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v10 (Il2CppClass<CharacterData>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v10 (Il2CppClass<CharacterData>)+130]");
				if (num7 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v29+FFFFFFF8+v298 @ rax_v15*8]");
					if (0 == (nint)typeof(CharacterData))
					{
						goto IL_0430;
					}
				}
				nint num8 = (nint)typeof(WeaponData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rdx_v12 (Il2CppClass<WeaponData>)+130]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rdx_v12 (Il2CppClass<WeaponData>)+130]");
				if (num9 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v28+FFFFFFF8+v365 @ rax_v18*8]");
					if (0 == (nint)typeof(WeaponData))
					{
						goto IL_0430;
					}
				}
				nint num10 = (nint)typeof(TomeData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v13 (Il2CppClass<TomeData>)+130]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v13 (Il2CppClass<TomeData>)+130]");
				if (num11 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v27+FFFFFFF8+v430 @ rax_v20*8]");
					if (0 == (nint)typeof(TomeData))
					{
						goto IL_0430;
					}
				}
				nint num12 = (nint)typeof(ItemData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v14 (Il2CppClass<ItemData>)+130]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v14 (Il2CppClass<ItemData>)+130]");
				if (num13 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v26+FFFFFFF8+v454 @ rax_v22*8]");
					if (0 == (nint)typeof(ItemData))
					{
						goto IL_0430;
					}
				}
				nint num14 = (nint)typeof(HatData);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v15 (Il2CppClass<HatData>)+130]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+130]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v15 (Il2CppClass<HatData>)+130]");
				if (num15 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r9_v3 (Il2CppClass<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+C8]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v25+FFFFFFF8+v172 @ rax_v24*8]");
					if (0 == (nint)typeof(HatData))
					{
						goto IL_0430;
					}
				}
			}
		}
		goto IL_0455;
		IL_0455:
		hasNewQuestDone = true;
		bool flag = achievements.Add(achievement.internalName);
		return;
		IL_0430:
		hashSet = newUnlockables;
		goto IL_047e;
		IL_047e:
		string internalName = achievement._003Cunlockable_003Ek__BackingField.GetInternalName();
		bool flag2 = hashSet.Add(internalName);
		goto IL_0455;
	}

	public bool PurchaseUnlockable(UnlockableBase unlockable)
	{
		//IL_0180: Expected I4, but got O
		if ((object)unlockable != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
			{
				ProgressionSaveFile progression = saveManager.progression;
				if (saveManager.progression != null)
				{
					int price = unlockable.GetPrice();
					if (progression.silver < price)
					{
						goto IL_016c;
					}
					object internalName = unlockable.GetInternalName();
					if (purchases != null)
					{
						if (((HashSet<object>)(object)purchases).Contains(internalName))
						{
							goto IL_016c;
						}
						int price2 = unlockable.GetPrice();
						RemoveSilver(price2);
						string internalName2 = unlockable.GetInternalName();
						if (purchases != null)
						{
							bool flag = purchases.Add(internalName2);
							Action<UnlockableBase> a_UnlockablePurchased = A_UnlockablePurchased;
							if (A_UnlockablePurchased != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v275 @ rax_v24 (System.Action`1<Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase>)+18] (should have been resolved before IL gen)");
							}
							return true;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_016c:
		return false;
	}

	public bool HasUnclaimedQuests()
	{
		//IL_0072: Expected I4, but got O
		//IL_0045: Expected O, but got I4
		HashSet<string> hashSet = claimedAchievements;
		if (claimedAchievements != null)
		{
			HashSet<string> hashSet2 = achievements;
			if (achievements != null)
			{
				object obj = hashSet._count - hashSet2._count;
				bool flag = obj == null;
				return !flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool PurchaseShopItem(ShopItemData shopItemData)
	{
		//IL_00b2: Expected I4, but got O
		if ((object)shopItemData != null)
		{
			if (!shopItemData.CanBuy())
			{
				return false;
			}
			int price = shopItemData.GetPrice();
			int num = silver - price;
			silver = num;
			Action<int> a_SilverChanged = A_SilverChanged;
			if (A_SilverChanged != null)
			{
				int num2 = -price;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v48 @ r9_v2 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
			}
			if (shopItems != null)
			{
				int num3 = shopItems.get_Item(shopItemData.eShopItem);
				int value = num3 + 1;
				((Dictionary<System.Int32Enum, int>)(object)shopItems).set_Item((System.Int32Enum)shopItemData.eShopItem, value);
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool RefundShopItem(ShopItemData shopItemData)
	{
		//IL_00c3: Expected I4, but got O
		if ((object)shopItemData != null)
		{
			if (!shopItemData.CanRefund())
			{
				return false;
			}
			int refundPrice = shopItemData.GetRefundPrice();
			AddSilver(refundPrice);
			if (shopItems != null)
			{
				int num = shopItems.get_Item(shopItemData.eShopItem);
				int value = num - 1;
				((Dictionary<System.Int32Enum, int>)(object)shopItems).set_Item((System.Int32Enum)shopItemData.eShopItem, value);
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void AddSilver(int change)
	{
		//IL_0060: Expected O, but got I4
		//IL_00ae: Expected O, but got Ref
		//IL_0051: Expected F4, but got I4
		object obj = 2147483647 - change;
		if (silver <= (nint)obj)
		{
			int num = silver + change;
			silver = num;
		}
		else
		{
			silver = 2147483647;
		}
		Action<int> a_SilverChanged = A_SilverChanged;
		if (A_SilverChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v51 @ rax_v5 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
		object obj2 = default(object);
		string statName = ((Enum)(&obj2)).ToString();
		MyStats.SetValueForce(statName, silver);
	}

	public void RemoveSilver(int change)
	{
		int num = silver - change;
		silver = num;
		Action<int> a_SilverChanged = A_SilverChanged;
		if (A_SilverChanged != null)
		{
			int num2 = -change;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v32 @ rax_v3 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	public void ClaimAchievement(MyAchievement achievement)
	{
		//IL_0052: Expected O, but got I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		bool flag = claimedAchievements.Add(achievement.internalName);
		bool flag2 = achievement.difficulty == EAchievementDifficulty.Easy;
		if (flag2)
		{
			goto IL_00c6;
		}
		object obj = achievement.difficulty - 1;
		int change;
		if (!flag2)
		{
			object obj2 = obj - 1;
			if (!flag2)
			{
				if ((nint)obj2 != 1)
				{
					goto IL_00c6;
				}
				change = 8;
			}
			else
			{
				change = 4;
			}
		}
		else
		{
			change = 2;
		}
		goto IL_00e3;
		IL_00e3:
		AddSilver(change);
		Action<MyAchievement> a_AchievementClaimed = A_AchievementClaimed;
		if (A_AchievementClaimed != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v158 @ rax_v6 (System.Action`1<Assets.Scripts.Saves___Serialization.Progression.Achievements.MyAchievement>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_00c6:
		change = 1;
		goto IL_00e3;
	}

	public bool HasShopItem(EShopItem eShopItem)
	{
		//IL_0098: Expected I4, but got O
		if (shopItems != null)
		{
			int num = shopItems.get_Item(eShopItem);
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = num < 0;
			bool flag3 = num == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public int GetShopItemLevel(EShopItem eShopItem)
	{
		//IL_002b: Expected I4, but got O
		if (shopItems != null)
		{
			return shopItems.get_Item(eShopItem);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe void OnGameOver()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected I4, but got Unknown
		//IL_00b8: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PlayerXp playerXp = inventory.playerXp;
		MyPlayer instance2 = MyPlayer.Instance;
		CharacterProgression characterProgression = GetCharacterProgression(instance2.character);
		object obj = playerXp.xp * characterProgression.xpModifier;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int numRuns = characterProgression.numRuns + 1;
		characterProgression.numRuns = numRuns;
		object obj2 = default(object);
		int xp = obj2 + characterProgression.xp;
		characterProgression.xp = xp;
		object obj3 = default(object);
		string text = ((Enum)(&obj3)).ToString();
		string text2 = text.ToLower();
		string statName = text2 + "Rank";
		MyPlayer instance3 = MyPlayer.Instance;
		CharacterProgression characterProgression2 = GetCharacterProgression(instance3.character);
		int num = XpUtility.XpToLevel(characterProgression2.xp);
		float value = (float)num + 1f;
		MyStats.SetValueForce(statName, value);
	}

	public CharacterProgression GetCharacterProgression(ECharacter character)
	{
		if (this.characterProgression != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)this.characterProgression).ContainsKey((System.Int32Enum)character))
			{
				CharacterProgression characterProgression = new CharacterProgression();
				characterProgression.xpModifier = 0.1f;
				if (this.characterProgression == null)
				{
					goto IL_00b1;
				}
				((Dictionary<System.Int32Enum, object>)(object)this.characterProgression).Add((System.Int32Enum)character, (object)characterProgression);
			}
			if (this.characterProgression != null)
			{
				return (CharacterProgression)((Dictionary<System.Int32Enum, object>)(object)this.characterProgression).get_Item((System.Int32Enum)character);
			}
		}
		goto IL_00b1;
		IL_00b1:
		return (CharacterProgression)(object)new NullReferenceException();
	}

	public ProgressionSaveFile()
	{
		Dictionary<EShopItem, int> dictionary = new Dictionary<EShopItem, int>();
		shopItems = dictionary;
		Dictionary<ECharacter, CharacterProgression> dictionary2 = new Dictionary<ECharacter, CharacterProgression>();
		characterProgression = dictionary2;
		HashSet<string> hashSet = (HashSet<string>)(object)new HashSet<object>();
		achievements = hashSet;
		HashSet<string> hashSet2 = (HashSet<string>)(object)new HashSet<object>();
		claimedAchievements = hashSet2;
		HashSet<string> hashSet3 = (HashSet<string>)(object)new HashSet<object>();
		purchases = hashSet3;
		HashSet<string> hashSet4 = (HashSet<string>)(object)new HashSet<object>();
		inactivated = hashSet4;
		MenuMeta menuMeta = new MenuMeta
		{
			lastSelectedMap = EMap.Forest
		};
		Dictionary<EMap, MapProgress> mapsProgress = new Dictionary<EMap, MapProgress>();
		menuMeta.mapsProgress = mapsProgress;
		menuMeta.numRunsForUnlocks = 1;
		menuMeta.numRunsForLeaderboards = 2;
		menuMeta.numRunsForQuests = 4;
		menuMeta.numRunsForQuickQuests = 5;
		menuMeta.numRunsForShop = 6;
		this.menuMeta = menuMeta;
		HashSet<string> hashSet5 = (HashSet<string>)(object)new HashSet<object>();
		newUnlockables = hashSet5;
		HashSet<string> hashSet6 = (HashSet<string>)(object)new HashSet<object>();
		newShopItems = hashSet6;
		HashSet<string> hashSet7 = (HashSet<string>)(object)new HashSet<object>();
		newMaps = hashSet7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
