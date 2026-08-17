using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups;

public static class RunUnlockables
{
	public static HashSet<ItemData> banishedItems;

	public static HashSet<UnlockableBase> banishedUpgradables;

	public static Dictionary<EItemRarity, List<ItemData>> availableItems;

	private static Dictionary<EItem, int> numItemsPickedupThisRun;

	public static Action A_Inited;

	private static int maxOverpoweredLamps;

	private static int maxAnvils;

	public static void Init()
	{
		//IL_038b: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_0414: Expected I, but got O
		//IL_048d: Expected I, but got O
		//IL_0108: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_015c: Expected I, but got O
		//IL_016d: Expected O, but got I4
		//IL_01ff: Expected I, but got O
		//IL_0210: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_035b: Expected O, but got I4
		Delegate obj = GameManager.A_RunStarted;
		Action action = OnNewRunStarted;
		Delegate obj2 = Delegate.Combine(GameManager.A_RunStarted, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_04aa;
			}
			GameManager.A_RunStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_04ba;
			}
		}
		Action<MyAchievement> b = OnAchievementUnlocked;
		Delegate obj7 = Delegate.Combine(MyAchievements.A_Unlocked, b);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			MyAchievements.A_Unlocked = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action3 = default(Action<MyAchievement>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_044a;
			}
			MyAchievements.A_Unlocked = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_045a;
			}
		}
		Action<EItem> b2 = OnItemAdded;
		Delegate obj10 = Delegate.Combine(ItemInventory.A_ItemAdded, b2);
		if ((object)obj10 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action4 = default(Action<EItem>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag6)
			{
				goto IL_046a;
			}
			ItemInventory.A_ItemAdded = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj10;
			obj4 = 0;
			obj5 = null;
			if (flag7)
			{
				goto IL_047a;
			}
		}
		Action<EItem, bool> b3 = OnItemRemoved;
		Delegate obj12 = Delegate.Combine(ItemInventory.A_ItemRemoved, b3);
		if ((object)obj12 == null)
		{
			ItemInventory.A_ItemRemoved = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem, bool> action5 = default(Action<EItem, bool>);
		bool flag8 = action5 == null;
		obj = (Delegate)(object)typeof(Action<EItem, bool>);
		action2 = (Action)obj12;
		obj4 = 0;
		obj5 = null;
		if (flag8)
		{
			goto IL_049a;
		}
		ItemInventory.A_ItemRemoved = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag9 = obj13 == null;
		obj = (Delegate)(object)typeof(Action<EItem, bool>);
		action2 = (Action)obj12;
		obj4 = 0;
		obj5 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_04aa;
		IL_044a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ba;
		IL_04ba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049a;
		IL_046a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_045a;
		IL_049a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_047a;
		IL_047a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_046a;
		IL_045a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_044a;
	}

	public static void Cleanup()
	{
		//IL_038b: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_0414: Expected I, but got O
		//IL_048d: Expected I, but got O
		//IL_0108: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_015c: Expected I, but got O
		//IL_016d: Expected O, but got I4
		//IL_01ff: Expected I, but got O
		//IL_0210: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_035b: Expected O, but got I4
		Delegate obj = GameManager.A_RunStarted;
		Action action = OnNewRunStarted;
		Delegate obj2 = Delegate.Remove(GameManager.A_RunStarted, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			GameManager.A_RunStarted = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_04aa;
			}
			GameManager.A_RunStarted = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_04ba;
			}
		}
		Action<MyAchievement> value = OnAchievementUnlocked;
		Delegate obj7 = Delegate.Remove(MyAchievements.A_Unlocked, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			MyAchievements.A_Unlocked = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action3 = default(Action<MyAchievement>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_044a;
			}
			MyAchievements.A_Unlocked = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_045a;
			}
		}
		Action<EItem> value2 = OnItemAdded;
		Delegate obj10 = Delegate.Remove(ItemInventory.A_ItemAdded, value2);
		if ((object)obj10 == null)
		{
			ItemInventory.A_ItemAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action4 = default(Action<EItem>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag6)
			{
				goto IL_046a;
			}
			ItemInventory.A_ItemAdded = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			obj = (Delegate)(object)typeof(Action<EItem>);
			action2 = (Action)obj10;
			obj4 = 0;
			obj5 = null;
			if (flag7)
			{
				goto IL_047a;
			}
		}
		Action<EItem, bool> value3 = OnItemRemoved;
		Delegate obj12 = Delegate.Remove(ItemInventory.A_ItemRemoved, value3);
		if ((object)obj12 == null)
		{
			ItemInventory.A_ItemRemoved = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem, bool> action5 = default(Action<EItem, bool>);
		bool flag8 = action5 == null;
		obj = (Delegate)(object)typeof(Action<EItem, bool>);
		action2 = (Action)obj12;
		obj4 = 0;
		obj5 = null;
		if (flag8)
		{
			goto IL_049a;
		}
		ItemInventory.A_ItemRemoved = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag9 = obj13 == null;
		obj = (Delegate)(object)typeof(Action<EItem, bool>);
		action2 = (Action)obj12;
		obj4 = 0;
		obj5 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_04aa;
		IL_044a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ba;
		IL_04ba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049a;
		IL_046a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_045a;
		IL_049a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_047a;
		IL_047a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_046a;
		IL_045a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_044a;
	}

	private unsafe static void OnNewRunStarted()
	{
		//IL_00af: Expected O, but got Ref
		//IL_00b7: Expected O, but got Ref
		//IL_00d0: Expected I4, but got O
		//IL_01ec: Expected I4, but got O
		//IL_020b: Expected I, but got O
		//IL_0423: Expected I, but got O
		//IL_045a: Expected O, but got I
		//IL_022d: Expected I4, but got O
		//IL_0235: Expected I, but got O
		//IL_0261: Expected O, but got I
		//IL_0154: Expected I, but got O
		//IL_015c: Expected I, but got O
		//IL_018b: Expected I, but got O
		//IL_0199: Expected I, but got O
		//IL_0286: Expected O, but got Ref
		//IL_03c9: Expected I, but got O
		//IL_03d7: Expected I, but got O
		//IL_0294: Expected O, but got Ref
		//IL_01d0: Expected I4, but got O
		//IL_02c8: Expected O, but got Ref
		//IL_0309: Expected O, but got Ref
		HashSet<ItemData> hashSet = (HashSet<ItemData>)(object)new HashSet<object>();
		banishedItems = hashSet;
		HashSet<UnlockableBase> hashSet2 = (HashSet<UnlockableBase>)(object)new HashSet<object>();
		banishedUpgradables = hashSet2;
		Dictionary<EItem, int> dictionary = new Dictionary<EItem, int>();
		numItemsPickedupThisRun = dictionary;
		Dictionary<EItemRarity, List<ItemData>> dictionary2 = new Dictionary<EItemRarity, List<ItemData>>();
		availableItems = dictionary2;
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(EItemRarity));
		Array values = Enum.GetValues(typeFromHandle);
		bool flag = values == null;
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		Type type = typeFromHandle;
		List<ItemData> list2;
		if (!flag)
		{
			IEnumerator enumerator = values.GetEnumerator();
			List<ItemData> list = default(List<ItemData>);
			object obj = (object)(&list);
			object obj2 = default(object);
			UnlockableBase unlockableBase = (UnlockableBase)(&obj2);
			object obj3 = default(object);
			object obj4 = default(object);
			nint num5;
			while (true)
			{
				if (list != null)
				{
					((Dictionary<EItemRarity, List<ItemData>>)null).Add((EItemRarity)typeof(IEnumerator), list);
					if (obj3 == null)
					{
						break;
					}
					bool flag2 = list == null;
					Array array = null;
					if (!flag2)
					{
						object current = ((IEnumerator)list).Current;
						bool flag3 = current == null;
						list2 = list;
						if (!flag3)
						{
							nint num2 = (nint)typeof(EItemRarity);
							nint num3 = (nint)current;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v39 (Il2CppClass<System.Object>)+40]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ r8_v15 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.EItemRarity>)+40]");
							bool flag4 = num4 != 0;
							num5 = (nint)typeof(EItemRarity);
							num = (nint)typeof(IEnumerator);
							list2 = (List<ItemData>)current;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								List<ItemData> list3 = new List<ItemData>();
								bool flag5 = availableItems == null;
								num5 = (nint)typeof(EItemRarity);
								num = (nint)typeof(IEnumerator);
								list2 = list3;
								if (!flag5)
								{
									((Dictionary<System.Int32Enum, object>)(object)availableItems).Add((System.Int32Enum)obj4, (object)list3);
									continue;
								}
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((Dictionary<EItemRarity, List<ItemData>>)obj).Add((EItemRarity)typeof(IDisposable), list);
			List<ItemData> list4 = default(List<ItemData>);
			unlockableBase = (UnlockableBase)(object)list4;
			bool flag6 = list4 == null;
			num5 = (nint)list;
			if (!flag6)
			{
				((Dictionary<EItemRarity, List<ItemData>>)null).Add((EItemRarity)typeof(IDisposable), list4);
				num5 = (nint)list4;
			}
			nint num6 = (nint)typeof(DataManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ rax_v41 (Il2CppClass<DataManager>)+B8]");
			nint num7 = 0;
			DataManager instance = DataManager.Instance;
			bool flag7 = (object)DataManager.Instance == null;
			num = 0;
			type = (Type)num7;
			if (!flag7)
			{
				bool flag8 = instance.unsortedItems == null;
				num = 0;
				type = (Type)num7;
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
					while (true)
					{
						if (enumerator2.MoveNext())
						{
							UnlockableBase unlockableBase2 = (UnlockableBase)(&obj2);
							if (MyAchievements.IsAvailable((UnlockableBase)(&obj2)))
							{
								bool flag9 = &obj2 == null;
								UnlockableBase unlockableBase3 = (UnlockableBase)(&obj2);
								if (flag9)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rdi_v11 (Assets.Scripts.Saves___Serialization.Progression.Achievements.UnlockableBase)+50]");
								if ((nint)0 != 0)
								{
									AddItemToPool((ItemData)(&obj2));
								}
							}
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						Action a_Inited = A_Inited;
						if (A_Inited != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v672.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
						return;
					}
					throw new NullReferenceException();
				}
			}
		}
		list2 = (List<ItemData>)(object)type;
		throw new NullReferenceException();
	}

	public static void Testing()
	{
		OnNewRunStarted();
	}

	private static void AddItemToPool(ItemData item)
	{
		//IL_008f: Expected O, but got I
		//IL_00e9: Expected O, but got I
		if (!((Dictionary<System.Int32Enum, object>)(object)availableItems).ContainsKey((System.Int32Enum)item.rarity))
		{
			List<ItemData> value = new List<ItemData>();
			((Dictionary<System.Int32Enum, object>)(object)availableItems).Add((System.Int32Enum)item.rarity, (object)value);
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item.rarity);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v14 (System.Object)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v14 (System.Object)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v14 (System.Object)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v9+18]");
		if (num >= 0)
		{
			((List<object>)obj).AddWithResize((object)item);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v14 (System.Object)+18]");
		object obj3 = (nint)0 + (nint)1;
	}

	private unsafe static void OnItemAdded(EItem eItem)
	{
		//IL_02af: Expected O, but got Ref
		if (!numItemsPickedupThisRun.ContainsKey(eItem))
		{
			((Dictionary<System.Int32Enum, int>)(object)numItemsPickedupThisRun).set_Item((System.Int32Enum)eItem, 0);
		}
		int num = numItemsPickedupThisRun.get_Item(eItem);
		int value = num + 1;
		((Dictionary<System.Int32Enum, int>)(object)numItemsPickedupThisRun).set_Item((System.Int32Enum)eItem, value);
		ItemData item = DataManager.Instance.GetItem(eItem);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int amount = inventory.itemInventory.GetAmount(eItem);
		if (item.maxAmount > 0 && amount >= item.maxAmount)
		{
			ItemData item2 = DataManager.Instance.GetItem(eItem);
			object obj = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item2.rarity);
			if (((List<object>)obj).Contains((object)item2))
			{
				object obj2 = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item2.rarity);
				bool flag = ((List<object>)obj2).Remove((object)item2);
			}
		}
		ItemData item3 = DataManager.Instance.GetItem(eItem);
		if (item3.maxAmountPerRun <= 0)
		{
			return;
		}
		int num2 = numItemsPickedupThisRun.get_Item(eItem);
		if (num2 >= item3.maxAmountPerRun)
		{
			ItemData item4 = DataManager.Instance.GetItem(eItem);
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item4.rarity);
			if (((List<object>)obj3).Contains((object)item4))
			{
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item4.rarity);
				bool flag2 = ((List<object>)obj4).Remove((object)item4);
			}
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			int num3 = numItemsPickedupThisRun.get_Item(eItem);
			int num4 = default(int);
			string text2 = num4.ToString();
			int num5 = default(int);
			string text3 = num5.ToString();
			string text4 = "Removed from pool: " + text + ", amount: " + text2 + "/" + text3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	private static void OnItemRemoved(EItem eItem, bool whatever)
	{
		//IL_0081: Expected O, but got I4
		ItemData item = DataManager.Instance.GetItem(eItem);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int amount = inventory.itemInventory.GetAmount(eItem);
		if (item.maxAmount <= 0)
		{
			return;
		}
		object obj = item.maxAmount - 1;
		if (amount == (nint)obj)
		{
			ItemData item2 = DataManager.Instance.GetItem(eItem);
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item2.rarity);
			if (!((List<object>)obj2).Contains((object)item2))
			{
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)item2.rarity);
				((List<ItemData>)obj3).Add(item2);
			}
		}
	}

	private static void OnAchievementUnlocked(MyAchievement ach)
	{
	}

	public static void BanishItem(ItemData unlockable)
	{
		bool flag = banishedItems.Add(unlockable);
		object obj = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)unlockable.rarity);
		if (((List<object>)obj).Contains((object)unlockable))
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)availableItems).get_Item((System.Int32Enum)unlockable.rarity);
			bool flag2 = ((List<object>)obj2).Remove((object)unlockable);
		}
	}

	public static void BanishUpgradable(UnlockableBase upgradable)
	{
		bool flag = banishedUpgradables.Add(upgradable);
	}

	static RunUnlockables()
	{
		Dictionary<EItemRarity, List<ItemData>> dictionary = new Dictionary<EItemRarity, List<ItemData>>();
		availableItems = dictionary;
		Dictionary<EItem, int> dictionary2 = new Dictionary<EItem, int>();
		numItemsPickedupThisRun = dictionary2;
		maxOverpoweredLamps = 2;
		maxAnvils = 1;
	}
}
