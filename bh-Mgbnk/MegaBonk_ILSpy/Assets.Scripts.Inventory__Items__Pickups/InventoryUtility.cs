using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Inventory__Items__Pickups.Progression;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups;

public class InventoryUtility
{
	public const int MAX_WEAPON_LEVEL_BASE = 40;

	public const int MAX_TOME_LEVEL_BASE = 99;

	public unsafe static List<IUpgradable> GetRandomUpgrades()
	{
		//IL_0034: Expected O, but got I4
		//IL_064d: Expected O, but got I4
		//IL_06a5: Expected O, but got Ref
		//IL_00b9: Expected O, but got Ref
		//IL_03a1: Expected O, but got Ref
		//IL_00cf: Expected I, but got O
		//IL_03c6: Expected O, but got I4
		//IL_0170: Expected I, but got O
		//IL_0107: Expected O, but got I
		//IL_0110: Expected O, but got I4
		//IL_03ef: Expected O, but got I4
		//IL_022c: Expected I, but got O
		//IL_01b1: Expected O, but got I4
		//IL_02c0: Expected O, but got I
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_0435: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0314: Expected O, but got I4
		//IL_0322: Expected I, but got O
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_0292: Expected I, but got O
		//IL_0363: Expected O, but got I4
		//IL_0371: Expected I, but got O
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		List<IUpgradable> list = new List<IUpgradable>();
		List<IUpgradable> list2 = new List<IUpgradable>();
		list2._002Ector();
		List<WeaponData> availableWeapons = UnlockUtility.GetAvailableWeapons();
		bool flag = list2 == null;
		List<IUpgradable>.Enumerator enumerator = (List<IUpgradable>.Enumerator)0;
		if (!flag)
		{
			((List<object>)(object)list2).AddRange((IEnumerable<object>)availableWeapons);
			HashSet<TomeData> availableTomes = UnlockUtility.GetAvailableTomes();
			((List<object>)(object)list2).AddRange((IEnumerable<object>)availableTomes);
			List<IUpgradable> list3 = new List<IUpgradable>();
			List<IUpgradable> list4 = new List<IUpgradable>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			nint num = 0;
			List<object>.Enumerator enumerator2;
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			IUpgradable upgradable = default(IUpgradable);
			object obj9 = default(object);
			while (true)
			{
				IL_0644:
				enumerator2 = (List<object>.Enumerator)3;
				while (enumerator3.MoveNext())
				{
					bool flag2 = upgradable == null;
					IUpgradable upgradable2 = (IUpgradable)(&enumerator3);
					List<object>.Enumerator enumerator4;
					if (!flag2)
					{
						nint num2 = (nint)upgradable;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ r10_v7 (Il2CppClass<Assets.Scripts._Data.IUpgradable>)+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0147;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ r10_v7 (Il2CppClass<Assets.Scripts._Data.IUpgradable>)+B0]");
						enumerator4 = (List<object>.Enumerator)0;
						object obj = 0;
						while (true)
						{
							object obj2 = obj + obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ r8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>)+v556 @ rax_v81*8]");
							if (0 == (nint)typeof(IUpgradable))
							{
								break;
							}
							obj++;
							object obj3 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ r10_v7 (Il2CppClass<Assets.Scripts._Data.IUpgradable>)+12E]");
							if ((nint)obj3 < 0)
							{
								continue;
							}
							goto IL_0147;
						}
						object obj4 = obj + obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ r8_v19 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>)+8+v614 @ rcx_v61*8]");
						object obj5 = (nint)0 + (nint)3;
						object obj6 = obj5 << 4;
						object obj7 = obj6 + 312;
						object obj8 = obj7 + num2;
						goto IL_015e;
					}
					throw new NullReferenceException();
					IL_01e8:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					num = 4;
					goto IL_0200;
					IL_0147:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18026F510");
					enumerator4 = enumerator2;
					goto IL_015e;
					IL_0200:
					int maxLevel = upgradable.GetMaxLevel();
					bool flag3 = (nint)obj9 >= maxLevel;
					nint num3 = (nint)typeof(IUpgradable);
					if (flag3)
					{
						goto IL_0644;
					}
					if ((nint)obj9 > 0)
					{
						goto IL_025a;
					}
					bool flag4 = CanUnlockItem(upgradable);
					bool flag5 = !flag4;
					enumerator2 = (List<object>.Enumerator)3;
					num3 = (nint)typeof(IUpgradable);
					if (!flag5)
					{
						if (list4 == null)
						{
							throw new NullReferenceException();
						}
						list4.Add(upgradable);
						enumerator2 = (List<object>.Enumerator)3;
						num3 = (nint)typeof(IUpgradable);
						num = 0;
					}
					continue;
					IL_015e:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v611 @ rax_v59] (should have been resolved before IL gen)");
					nint num4 = (nint)upgradable;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r10_v8 (Il2CppClass<Assets.Scripts._Data.IUpgradable>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_01e8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r10_v8 (Il2CppClass<Assets.Scripts._Data.IUpgradable>)+B0]");
					num = 0;
					object obj10 = 0;
					while (true)
					{
						object obj11 = obj10 + obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r8_v10 (Il2CppMethodInfo)+v652 @ rax_v70*8]");
						if (0 != (nint)typeof(IUpgradable))
						{
							obj10++;
							object obj12 = obj10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r10_v8 (Il2CppClass<Assets.Scripts._Data.IUpgradable>)+12E]");
							if ((nint)obj12 < 0)
							{
								continue;
							}
							goto IL_01e8;
						}
						break;
					}
					goto IL_0200;
				}
				break;
				IL_025a:
				if (list3 != null)
				{
					list3.Add(upgradable);
					nint num3 = (nint)typeof(IUpgradable);
					num = 0;
					continue;
				}
				throw new NullReferenceException();
			}
			((List<IUpgradable>.Enumerator*)(&enumerator3))->Dispose();
			bool flag6 = list4 == null;
			enumerator = (List<IUpgradable>.Enumerator)(&enumerator3);
			if (!flag6)
			{
				bool flag7 = list3 == null;
				enumerator = (List<IUpgradable>.Enumerator)(&enumerator3);
				if (!flag7)
				{
					List<object>.Enumerator enumerator5 = (List<object>.Enumerator)(list4._size + list3._size);
					object obj13;
					IUpgradable upgradable3;
					if ((nint)enumerator5 > 3)
					{
						obj13 = 0;
						upgradable3 = upgradable;
						List<object>.Enumerator enumerator7 = default(List<object>.Enumerator);
						List<object>.Enumerator enumerator6 = enumerator7;
					}
					else
					{
						if ((nint)enumerator5 <= 0)
						{
							goto IL_0599;
						}
						enumerator2 = enumerator5;
						obj13 = 0;
						upgradable3 = upgradable;
						List<object>.Enumerator enumerator6 = enumerator5;
					}
					int index = default(int);
					int index2 = default(int);
					while (true)
					{
						IUpgradable item;
						List<object> list5;
						nint num3;
						if (list4._size > 0)
						{
							bool flag8 = list3._size <= 0;
							IUpgradable upgradable4 = upgradable3;
							if (!flag8)
							{
								enumerator = (List<IUpgradable>.Enumerator)MyRandom.random;
								if (MyRandom.random == null)
								{
									break;
								}
								object obj14 = enumerator;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v922 @ rax_v53+1B8] (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm0\"");
								bool flag9 = (nint)MyRandom.random > 0;
								upgradable4 = null;
								upgradable3 = null;
								if (flag9)
								{
									goto IL_075c;
								}
							}
							enumerator = (List<IUpgradable>.Enumerator)MyRandom.random;
							if (MyRandom.random == null)
							{
								break;
							}
							object obj15 = enumerator;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v924 @ rax_v45+1A0]");
							num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v924 @ rax_v45+198] (should have been resolved before IL gen)");
							item = list4.get_Item(index);
							upgradable3 = upgradable4;
							list5 = (List<object>)(object)list4;
							goto IL_0726;
						}
						goto IL_075c;
						IL_075c:
						enumerator = (List<IUpgradable>.Enumerator)MyRandom.random;
						if (MyRandom.random == null)
						{
							break;
						}
						object obj16 = enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ rax_v36+1A0]");
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v913 @ rax_v36+198] (should have been resolved before IL gen)");
						item = list3.get_Item(index2);
						list5 = (List<object>)(object)list3;
						goto IL_0726;
						IL_0726:
						bool flag10 = list5.Remove(item);
						bool flag11 = list == null;
						enumerator = (List<IUpgradable>.Enumerator)list5;
						if (flag11)
						{
							break;
						}
						list.Add(item);
						obj13++;
						bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) < System.Runtime.CompilerServices.Unsafe.As<List<object>.Enumerator, UIntPtr>(ref enumerator2);
						num = 0;
						if (flag12)
						{
							continue;
						}
						goto IL_0599;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0599:
		return list;
	}

	public static List<ItemData> GetRandomItemsMoai(int moaiLuckMode)
	{
		//IL_03d4: Expected O, but got I4
		//IL_03dd: Expected O, but got I4
		//IL_0075: Expected I4, but got O
		//IL_0414: Expected O, but got I4
		//IL_00b4: Expected I4, but got O
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_00e4: Expected O, but got I
		//IL_00e4: Expected I4, but got O
		//IL_0233: Expected I4, but got O
		List<ItemData> list = new List<ItemData>();
		Dictionary<EItemRarity, List<ItemData>> dictionary = new Dictionary<EItemRarity, List<ItemData>>();
		dictionary._002Ector();
		if (RunUnlockables.availableItems != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			nint num = 0;
			Dictionary<EItemRarity, List<ItemData>>.Enumerator enumerator = default(Dictionary<EItemRarity, List<ItemData>>.Enumerator);
			List<ItemData> list2 = default(List<ItemData>);
			object obj = default(object);
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			while (enumerator.MoveNext())
			{
				List<ItemData> value = new List<ItemData>();
				if (dictionary != null)
				{
					((Dictionary<System.Int32Enum, object>)(object)dictionary).Add((System.Int32Enum)list2, (object)value);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						num = 0;
						while (enumerator2.MoveNext())
						{
							object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)list2);
							if (obj2 != null)
							{
								((Dictionary<EItemRarity, List<ItemData>>)obj2).Add((EItemRarity)list2, (List<ItemData>)0);
								num = 0;
								continue;
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			bool flag = moaiLuckMode == 0;
			bool flag2 = !flag;
			object obj3 = (flag2 ? 1 : 0) + 2;
			object obj4 = 0;
			while (true)
			{
				float stat = PlayerStats.GetStat(EStat.Luck);
				EItemRarity key;
				float luck;
				if (moaiLuckMode != 0)
				{
					if (moaiLuckMode != 2)
					{
						EItemRarity itemRarity = Rarity.GetItemRarity(stat);
						bool flag3 = moaiLuckMode != 3;
						key = itemRarity;
						if (!flag3)
						{
							key = (EItemRarity)moaiLuckMode;
						}
						goto IL_03fc;
					}
					luck = stat * 1.5f;
				}
				else
				{
					luck = stat * 0.5f;
				}
				EItemRarity itemRarity2 = Rarity.GetItemRarity(luck);
				key = itemRarity2;
				goto IL_03fc;
				IL_03fc:
				bool flag4 = dictionary == null;
				Dictionary<System.Int32Enum, object> dictionary2 = (Dictionary<System.Int32Enum, object>)30;
				if (flag4)
				{
					break;
				}
				object obj5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
				if (obj5 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v26 (System.Object)+18]");
				List<ItemData> result;
				if ((nint)0 > (nint)0)
				{
					object obj6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
					object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
					if (obj7 == null || MyRandom.random == null)
					{
						break;
					}
					int index = (int)((Dictionary<TKey, TValue>)(object)MyRandom.random).System_002ECollections_002EGeneric_002EIDictionary_003CTKey_002CTValue_003E_002EKeys;
					if (obj6 == null)
					{
						break;
					}
					ItemData item = ((List<ItemData>)obj6).get_Item(index);
					object obj8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
					if (obj8 == null)
					{
						break;
					}
					bool flag5 = ((List<object>)obj8).Remove((object)item);
					if (list == null)
					{
						break;
					}
					list.Add(item);
					result = list;
				}
				else
				{
					result = list;
				}
				obj4++;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					return result;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static List<ItemData> GetRandomItemsShadyGuy(EItemRarity itemRarity)
	{
		//IL_0437: Expected O, but got I4
		//IL_0076: Expected I4, but got F4
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_00c1: Invalid comparison between F4 and I4
		//IL_00cf: Expected O, but got Ref
		//IL_0179: Expected I4, but got F4
		//IL_0148: Expected O, but got F4
		//IL_0159: Expected O, but got F4
		//IL_015e: Expected I, but got O
		//IL_0289: Expected I4, but got O
		//IL_01a9: Expected O, but got I
		//IL_01a9: Expected I4, but got F4
		List<ItemData> list = new List<ItemData>();
		Dictionary<EItemRarity, List<ItemData>> dictionary = new Dictionary<EItemRarity, List<ItemData>>();
		dictionary._002Ector();
		if (RunUnlockables.availableItems != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			nint num = 0;
			Dictionary<EItemRarity, List<ItemData>>.Enumerator enumerator = default(Dictionary<EItemRarity, List<ItemData>>.Enumerator);
			float num2 = default(float);
			object obj = default(object);
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
			while (enumerator.MoveNext())
			{
				List<ItemData> value = new List<ItemData>();
				if (dictionary != null)
				{
					((Dictionary<System.Int32Enum, object>)(object)dictionary).Add((System.Int32Enum)num2, (object)value);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
						float num3 = num2;
						List<object>.Enumerator enumerator2 = enumerator3;
						num = 0;
						while (enumerator4.MoveNext())
						{
							bool flag = num2 == 0f;
							List<object>.Enumerator enumerator5 = (List<object>.Enumerator)(&enumerator4);
							if (!flag)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ stack_-C0 (System.Single)+54]");
								bool flag2 = (nint)0 != 79;
								float num4 = num3;
								List<object>.Enumerator enumerator6 = enumerator2;
								if (!flag2)
								{
									float num5 = UnityEngine.Random.Range(0f, 1f);
									flag2 = num5 > 0.0025f;
									num4 = 1f;
									enumerator6 = (List<object>.Enumerator)num5;
									num3 = 1f;
									enumerator2 = (List<object>.Enumerator)num5;
									num = unchecked((nint)null);
									if (flag2)
									{
										continue;
									}
								}
								object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)num2);
								if (obj2 != null)
								{
									((Dictionary<EItemRarity, List<ItemData>>)obj2).Add((EItemRarity)num2, (List<ItemData>)0);
									num3 = num4;
									enumerator2 = enumerator6;
									num = 0;
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			object obj3 = 0;
			while (true)
			{
				float stat = PlayerStats.GetStat(EStat.Luck);
				float luck = stat * 0.5f;
				EItemRarity itemRarity2 = Rarity.GetItemRarity(luck);
				bool flag3 = itemRarity2 >= itemRarity;
				EItemRarity key = itemRarity2;
				if (!flag3)
				{
					key = itemRarity;
				}
				if (dictionary == null)
				{
					break;
				}
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
				if (obj4 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v28 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					object obj5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
					object obj6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
					if (obj6 == null || MyRandom.random == null)
					{
						break;
					}
					int index = (int)((Dictionary<TKey, TValue>)(object)MyRandom.random).System_002ECollections_002EGeneric_002EIDictionary_003CTKey_002CTValue_003E_002EKeys;
					if (obj5 == null)
					{
						break;
					}
					ItemData item = ((List<ItemData>)obj5).get_Item(index);
					object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)key);
					if (obj7 == null)
					{
						break;
					}
					bool flag4 = ((List<object>)obj7).Remove((object)item);
					if (list == null)
					{
						break;
					}
					list.Add(item);
				}
				obj3++;
				if ((nint)obj3 >= 3)
				{
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	private static int GetNumUpgrades()
	{
		return 3;
	}

	private static bool CanUnlockItem(IUpgradable upgradable)
	{
		//IL_029b: Expected I4, but got O
		//IL_0232: Expected O, but got I4
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected I4, but got Unknown
		//IL_0142: Expected O, but got I4
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected I4, but got Unknown
		if (upgradable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(TomeData));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B65E0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
				Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(WeaponData));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805B65E0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					return true;
				}
				MyPlayer instance = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory = instance.inventory;
					if (instance.inventory != null)
					{
						WeaponInventory weaponInventory = inventory.weaponInventory;
						if (inventory.weaponInventory != null && weaponInventory.weapons != null)
						{
							int count = weaponInventory.weapons.Count;
							int numAvailableWeaponSlots = GetNumAvailableWeaponSlots();
							object obj3 = count - numAvailableWeaponSlots;
							int num = count ^ numAvailableWeaponSlots;
							int num2 = count ^ obj3;
							int num3 = num & num2;
							bool flag = num3 < 0;
							bool flag2 = (nint)obj3 < 0;
							return flag2 != flag;
						}
					}
				}
			}
			else
			{
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInventory inventory2 = instance2.inventory;
					if (instance2.inventory != null)
					{
						TomeInventory tomeInventory = inventory2.tomeInventory;
						if (inventory2.tomeInventory != null && tomeInventory.tomeLevels != null)
						{
							int count2 = tomeInventory.tomeLevels.Count;
							int numAvailableTomeSlots = GetNumAvailableTomeSlots();
							object obj4 = count2 - numAvailableTomeSlots;
							int num4 = count2 ^ numAvailableTomeSlots;
							int num5 = count2 ^ obj4;
							int num6 = num4 & num5;
							bool flag3 = num6 < 0;
							bool flag4 = (nint)obj4 < 0;
							return flag4 != flag3;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static bool CanUnlockWeapons()
	{
		//IL_00fe: Expected I4, but got O
		//IL_0095: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected I4, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				WeaponInventory weaponInventory = inventory.weaponInventory;
				if (inventory.weaponInventory != null && weaponInventory.weapons != null)
				{
					int count = weaponInventory.weapons.Count;
					int numAvailableWeaponSlots = GetNumAvailableWeaponSlots();
					object obj = count - numAvailableWeaponSlots;
					int num = count ^ numAvailableWeaponSlots;
					int num2 = count ^ obj;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = (nint)obj < 0;
					return flag2 != flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static bool CanUnlockTomes()
	{
		//IL_00fe: Expected I4, but got O
		//IL_0095: Expected O, but got I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected I4, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null)
			{
				TomeInventory tomeInventory = inventory.tomeInventory;
				if (inventory.tomeInventory != null && tomeInventory.tomeLevels != null)
				{
					int count = tomeInventory.tomeLevels.Count;
					int numAvailableTomeSlots = GetNumAvailableTomeSlots();
					object obj = count - numAvailableTomeSlots;
					int num = count ^ numAvailableTomeSlots;
					int num2 = count ^ obj;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = (nint)obj < 0;
					return flag2 != flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static int GetNumAvailableWeaponSlots()
	{
		//IL_00a3: Expected I4, but got O
		if (!ChallengesTracker.HasChallengeModifier("minimalist"))
		{
			if ((object)DataManager.Instance != null)
			{
				ShopItemData shopItemData = DataManager.Instance.GetShopItemData(EShopItem.Weapons);
				if ((object)shopItemData != null)
				{
					int level = shopItemData.GetLevel();
					return level + 2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return 1;
	}

	public static int GetNumAvailableTomeSlots()
	{
		//IL_00a3: Expected I4, but got O
		if (!ChallengesTracker.HasChallengeModifier("minimalist"))
		{
			if ((object)DataManager.Instance != null)
			{
				ShopItemData shopItemData = DataManager.Instance.GetShopItemData(EShopItem.Tomes);
				if ((object)shopItemData != null)
				{
					int level = shopItemData.GetLevel();
					return level + 2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return 1;
	}

	public static int GetNumMaxWeaponSlots()
	{
		return 4;
	}

	public static int GetNumMaxTomeSlots()
	{
		return 4;
	}

	public static int GetWeaponMaxLevel()
	{
		//IL_01b9: Expected I4, but got O
		//IL_00bf: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_0150: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance2.inventory;
				if (instance2.inventory != null && inventory.itemInventory != null)
				{
					ItemBase item = inventory.itemInventory.GetItem(EItem.Pot);
					if (item == null)
					{
						goto IL_01a5;
					}
					nint num = (nint)typeof(ItemPotSteel);
					nint num2 = (nint)item;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPotSteel>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPotSteel>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9+FFFFFFF8+v189 @ rcx_v8*8]");
						if (0 == (nint)typeof(ItemPotSteel))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPotSteel>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9+FFFFFFF8+v115 @ rdx_v6*8]");
							object obj4 = 0 - typeof(ItemPotSteel);
							bool flag = obj4 == null;
							bool flag2 = !flag;
							ItemBase itemBase = null;
							if (!flag2)
							{
								itemBase = item;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r8_v6 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase)+3C]");
							return (int)((nint)0 + (nint)40);
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		goto IL_01a5;
		IL_01a5:
		return 40;
	}

	public static int GetTomeMaxLevel()
	{
		//IL_01b9: Expected I4, but got O
		//IL_00bf: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_0150: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance2.inventory;
				if (instance2.inventory != null && inventory.itemInventory != null)
				{
					ItemBase item = inventory.itemInventory.GetItem(EItem.WizardsHat);
					if (item == null)
					{
						goto IL_01a5;
					}
					nint num = (nint)typeof(ItemWizardsHat);
					nint num2 = (nint)item;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWizardsHat>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWizardsHat>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9+FFFFFFF8+v189 @ rcx_v8*8]");
						if (0 == (nint)typeof(ItemWizardsHat))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWizardsHat>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v9+FFFFFFF8+v115 @ rdx_v6*8]");
							object obj4 = 0 - typeof(ItemWizardsHat);
							bool flag = obj4 == null;
							bool flag2 = !flag;
							ItemBase itemBase = null;
							if (!flag2)
							{
								itemBase = item;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r8_v6 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase)+3C]");
							return (int)((nint)0 + (nint)99);
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		goto IL_01a5;
		IL_01a5:
		return 99;
	}

	public static int GetNumExtraWeaponLevels()
	{
		//IL_01b9: Expected I4, but got O
		//IL_00bf: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_0150: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance2.inventory;
				if (instance2.inventory != null && inventory.itemInventory != null)
				{
					ItemBase item = inventory.itemInventory.GetItem(EItem.Pot);
					if (item == null)
					{
						goto IL_01a5;
					}
					nint num = (nint)typeof(ItemPotSteel);
					nint num2 = (nint)item;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPotSteel>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPotSteel>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v9+FFFFFFF8+v188 @ rcx_v8*8]");
						if (0 == (nint)typeof(ItemPotSteel))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemPotSteel>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v9+FFFFFFF8+v114 @ rdx_v6*8]");
							object obj4 = 0 - typeof(ItemPotSteel);
							bool flag = obj4 == null;
							bool flag2 = !flag;
							ItemBase itemBase = null;
							if (!flag2)
							{
								itemBase = item;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v15 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase)+3C]");
							return 0;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		goto IL_01a5;
		IL_01a5:
		return 0;
	}

	public static int GetNumExtraTomeLevels()
	{
		//IL_01b9: Expected I4, but got O
		//IL_00bf: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_0113: Expected O, but got I
		//IL_0150: Expected O, but got I
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance2.inventory;
				if (instance2.inventory != null && inventory.itemInventory != null)
				{
					ItemBase item = inventory.itemInventory.GetItem(EItem.WizardsHat);
					if (item == null)
					{
						goto IL_01a5;
					}
					nint num = (nint)typeof(ItemWizardsHat);
					nint num2 = (nint)item;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWizardsHat>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWizardsHat>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v13 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v9+FFFFFFF8+v188 @ rcx_v8*8]");
						if (0 == (nint)typeof(ItemWizardsHat))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r9_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemWizardsHat>)+130]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v9+FFFFFFF8+v114 @ rdx_v6*8]");
							object obj4 = 0 - typeof(ItemWizardsHat);
							bool flag = obj4 == null;
							bool flag2 = !flag;
							ItemBase itemBase = null;
							if (!flag2)
							{
								itemBase = item;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v15 (Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase)+3C]");
							return 0;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		goto IL_01a5;
		IL_01a5:
		return 0;
	}
}
