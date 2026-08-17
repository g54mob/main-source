using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class ItemInventory
{
	public Dictionary<EItem, ItemBase> items;

	public static Action<EStat> A_StatsChanged;

	public static Action<EItem> A_ItemAdded;

	public static Action<EItem, bool> A_ItemRemoved;

	private HashSet<EItem> itemsWithOnHitProcs;

	private HashSet<EItem> itemsWithPreAttackProcs;

	private List<EItem> itemsWithOnHitSorted;

	private List<EItem> itemsSorted;

	private Dictionary<EItem, string> itemToStringCache;

	private DamageContainer postDamageDc;

	public ItemInventory()
	{
		//IL_01fb: Expected I, but got O
		Dictionary<EItem, ItemBase> dictionary = new Dictionary<EItem, ItemBase>();
		items = dictionary;
		HashSet<EItem> hashSet = (HashSet<EItem>)(object)new HashSet<System.Int32Enum>();
		itemsWithOnHitProcs = hashSet;
		HashSet<EItem> hashSet2 = (HashSet<EItem>)(object)new HashSet<System.Int32Enum>();
		itemsWithPreAttackProcs = hashSet2;
		List<EItem> list = new List<EItem>();
		itemsWithOnHitSorted = list;
		List<EItem> list2 = new List<EItem>();
		itemsSorted = list2;
		Dictionary<EItem, string> dictionary2 = new Dictionary<EItem, string>();
		itemToStringCache = dictionary2;
		DamageContainer damageContainer = new DamageContainer(0f, "");
		postDamageDc = damageContainer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		Action b = OnLateFixedUpdate;
		Delegate obj = Delegate.Combine(LateFixedUpdate.A_LateUpdate, b);
		if ((object)obj == null)
		{
			LateFixedUpdate.A_LateUpdate = null;
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
			LateFixedUpdate.A_LateUpdate = (Action)obj2;
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

	public void AddItem(EItem eItem)
	{
		//IL_0344: Expected I, but got O
		//IL_01e5: Expected I, but got O
		//IL_0148: Expected O, but got I
		//IL_02a0: Expected I, but got O
		//IL_015d: Expected O, but got I
		//IL_01b1: Expected O, but got I
		if (ChallengesTracker.HasChallengeModifier("no_items") && eItem != EItem.CageKey && eItem != EItem.CryptKey)
		{
			return;
		}
		if (!((Dictionary<System.Int32Enum, object>)(object)items).ContainsKey((System.Int32Enum)eItem))
		{
			ItemBase itemBase = ItemFactory.CreateItem(eItem, this);
			itemBase.Init();
			((Dictionary<System.Int32Enum, object>)(object)items).Add((System.Int32Enum)eItem, (object)itemBase);
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
		nint num = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v11 (System.Object)+18]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v515 @ rax_v13 (Il2CppClass<System.Object>)+198] (should have been resolved before IL gen)");
		Action<ItemBase> a_ItemAdded = ItemBase.A_ItemAdded;
		if (ItemBase.A_ItemAdded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v521 @ rax_v16 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+18] (should have been resolved before IL gen)");
		}
		bool flag = ((List<System.Int32Enum>)(object)itemsSorted).Contains((System.Int32Enum)eItem);
		nint num2 = 0;
		if (!flag)
		{
			List<EItem> list = itemsSorted;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v32 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v32 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v32 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v32 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v27+18]");
			if (num3 >= 0)
			{
				list.AddWithResize(eItem);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rcx_v32 (System.Collections.Generic.List`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			SortItems();
			num2 = 0;
		}
		object obj5 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
		nint num4 = (nint)obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v132 @ r8_v11 (Il2CppClass<System.Object>)+1D8] (should have been resolved before IL gen)");
		object obj6 = default(object);
		if (obj6 != null && !itemsWithOnHitProcs.Contains(eItem))
		{
			bool flag2 = itemsWithOnHitProcs.Add(eItem);
			if (!((List<System.Int32Enum>)(object)itemsWithOnHitSorted).Contains((System.Int32Enum)eItem))
			{
				itemsWithOnHitSorted.Add(eItem);
				SortOnHitItems();
			}
		}
		object obj7 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
		nint num5 = (nint)obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ r8_v14 (Il2CppClass<System.Object>)+1E8] (should have been resolved before IL gen)");
		object obj8 = default(object);
		if (obj8 != null && !itemsWithPreAttackProcs.Contains(eItem))
		{
			bool flag3 = itemsWithPreAttackProcs.Add(eItem);
		}
		Action<EItem> a_ItemAdded2 = A_ItemAdded;
		if (A_ItemAdded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v678 @ rax_v27 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Items.EItem>)+18] (should have been resolved before IL gen)");
		}
	}

	public void AddItem(EItem eItem, int count)
	{
		//IL_0029: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		if (count > 0)
		{
			object obj = 0;
			do
			{
				AddItem(eItem);
				obj++;
			}
			while ((nint)obj < count);
		}
	}

	public ItemBase GetItem(EItem eItem)
	{
		if (items != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)items).ContainsKey((System.Int32Enum)eItem))
			{
				return null;
			}
			if (items != null)
			{
				return (ItemBase)((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
			}
		}
		return (ItemBase)(object)new NullReferenceException();
	}

	public void RemoveItem(EItem eItem, bool showEffect = true)
	{
		//IL_02ca: Expected I, but got O
		//IL_00ba: Expected I, but got O
		//IL_018f: Expected I, but got O
		//IL_021a: Expected I, but got O
		if (!((Dictionary<System.Int32Enum, object>)(object)items).ContainsKey((System.Int32Enum)eItem))
		{
			return;
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
		nint num = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v6 (System.Object)+18]");
		_ = -1;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v422 @ rax_v8 (Il2CppClass<System.Object>)+198] (should have been resolved before IL gen)");
		Action<ItemBase> a_ItemRemoved = ItemBase.A_ItemRemoved;
		if (ItemBase.A_ItemRemoved != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v428 @ rax_v11 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+18] (should have been resolved before IL gen)");
		}
		object obj2 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v13 (System.Object)+18]");
		if ((nint)0 <= (nint)0)
		{
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
			nint num2 = (nint)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ r8_v10 (Il2CppClass<System.Object>)+1D8] (should have been resolved before IL gen)");
			object obj4 = default(object);
			if (obj4 != null && itemsWithOnHitProcs.Contains(eItem))
			{
				bool flag = itemsWithOnHitProcs.Remove(eItem);
				if (((List<System.Int32Enum>)(object)itemsWithOnHitSorted).Contains((System.Int32Enum)eItem))
				{
					bool flag2 = ((List<System.Int32Enum>)(object)itemsWithOnHitSorted).Remove((System.Int32Enum)eItem);
					SortOnHitItems();
				}
			}
			object obj5 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
			nint num3 = (nint)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v84 @ r8_v13 (Il2CppClass<System.Object>)+1E8] (should have been resolved before IL gen)");
			object obj6 = default(object);
			if (obj6 != null && itemsWithPreAttackProcs.Contains(eItem))
			{
				bool flag3 = itemsWithPreAttackProcs.Remove(eItem);
			}
			object obj7 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
			nint num4 = (nint)obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v88 @ r8_v16 (Il2CppClass<System.Object>)+188] (should have been resolved before IL gen)");
			bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)items).Remove((System.Int32Enum)eItem);
			if (((List<System.Int32Enum>)(object)itemsSorted).Contains((System.Int32Enum)eItem))
			{
				bool flag5 = ((List<System.Int32Enum>)(object)itemsSorted).Remove((System.Int32Enum)eItem);
				SortItems();
			}
		}
		Action<EItem, bool> a_ItemRemoved2 = A_ItemRemoved;
		if (A_ItemRemoved != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v353 @ rax_v16 (System.Action`2<Assets.Scripts.Inventory__Items__Pickups.Items.EItem, System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private unsafe void SortItems()
	{
		Comparison<EItem> comparison = delegate(EItem a, EItem b)
		{
			//IL_00f4: Expected O, but got Ref
			//IL_014d: Expected O, but got Ref
			//IL_011e: Expected I, but got O
			//IL_01e1: Expected I4, but got O
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected I4, but got Unknown
			ItemData item = DataManager.Instance.GetItem(a);
			ItemData item2 = DataManager.Instance.GetItem(b);
			int num2;
			if (item != null && item2 != null)
			{
				int num = item + 120;
				num2 = ((int*)num)->CompareTo(item2.itemTickPriority);
				if (num2 != 0)
				{
					goto IL_01ce;
				}
			}
			nint num3 = default(nint);
			if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)a))
			{
				string value = ((Enum)(&num3)).ToString();
				((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)a, (object)value);
				num3 = (nint)typeof(EItem);
			}
			if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)b))
			{
				string value2 = ((Enum)(&num3)).ToString();
				if (itemToStringCache == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)b, (object)value2);
			}
			object strA = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)a);
			object strB = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)b);
			num2 = string.Compare((string)strA, (string)strB, StringComparison.Ordinal);
			goto IL_01ce;
			IL_01ce:
			return num2;
		};
		itemsSorted.Sort(comparison);
	}

	private unsafe void SortOnHitItems()
	{
		Comparison<EItem> comparison = delegate(EItem a, EItem b)
		{
			//IL_002f: Expected O, but got Ref
			//IL_0088: Expected O, but got Ref
			//IL_0059: Expected I, but got O
			//IL_011c: Expected I4, but got O
			nint num = default(nint);
			if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)a))
			{
				string value = ((Enum)(&num)).ToString();
				((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)a, (object)value);
				num = (nint)typeof(EItem);
			}
			if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)b))
			{
				string value2 = ((Enum)(&num)).ToString();
				if (itemToStringCache == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)b, (object)value2);
			}
			object strA = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)a);
			object strB = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)b);
			return string.Compare((string)strA, (string)strB, StringComparison.Ordinal);
		};
		itemsWithOnHitSorted.Sort(comparison);
	}

	public void Tick()
	{
		//IL_0059: Expected I, but got O
		if (MyTime.paused)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
		nint num = 0;
		List<EItem>.Enumerator enumerator = default(List<EItem>.Enumerator);
		System.Int32Enum key = default(System.Int32Enum);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (items == null)
				{
					break;
				}
				object obj = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item(key);
				num = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v94 @ r8_v4 (Il2CppMethodInfo)+1A8] (should have been resolved before IL gen)");
				continue;
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public StatComponents PreAttack(DamageContainer dc, StatComponents itemModifierStatComponents)
	{
		//IL_009b: Expected I, but got O
		itemModifierStatComponents._003CbaseValue_003Ek__BackingField = 0f;
		itemModifierStatComponents._003CmultiplicativeValue_003Ek__BackingField = 1f;
		itemModifierStatComponents.hasModifications = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18106E6B0");
		HashSet<EItem>.Enumerator enumerator = default(HashSet<EItem>.Enumerator);
		System.Int32Enum key = default(System.Int32Enum);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (items != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item(key);
					if (obj == null)
					{
						break;
					}
					nint num = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v174 @ r10_v4 (Il2CppClass<System.Object>)+1B8] (should have been resolved before IL gen)");
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			return itemModifierStatComponents;
		}
		throw new NullReferenceException();
	}

	public void PostDamage(DamageContainer dc)
	{
		//IL_0013: Invalid comparison between I4 and F4
		//IL_0066: Expected O, but got I4
		//IL_015b: Expected O, but got I4
		//IL_00a3: Expected O, but got I
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_0118: Expected I, but got O
		if (!(0f < dc.procCoefficient))
		{
			return;
		}
		postDamageDc.Copy(dc);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)items).ContainsKey((System.Int32Enum)26);
		bool flag2 = !flag;
		object obj = 1;
		if (!flag2)
		{
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)26);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v25 (System.Object)+18]");
			obj = (nint)0 + (nint)1;
		}
		object obj3 = 0;
		List<EItem>.Enumerator enumerator = default(List<EItem>.Enumerator);
		System.Int32Enum key = default(System.Int32Enum);
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			while (enumerator.MoveNext())
			{
				if (items != null)
				{
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item(key);
					if (dc.enemy != null)
					{
						nint num = (nint)obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v444 @ rax_v22 (Il2CppClass<System.Object>)+1C8] (should have been resolved before IL gen)");
						continue;
					}
					enumerator.Dispose();
					return;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			obj3++;
		}
	}

	private void OnLateFixedUpdate()
	{
		if (MyTime.paused)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<EItem, ItemBase>.Enumerator enumerator = default(Dictionary<EItem, ItemBase>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v214 @ rax_v14+1F8] (should have been resolved before IL gen)");
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}

	public void StatWasModified(EStat stat)
	{
		Action<EStat> a_StatsChanged = A_StatsChanged;
		if (A_StatsChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<Assets.Scripts.Menu.Shop.EStat>)+18] (should have been resolved before IL gen)");
		}
	}

	public int GetAmount(EItem eItem)
	{
		//IL_00a1: Expected I4, but got O
		if (items != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)items).ContainsKey((System.Int32Enum)eItem))
			{
				return 0;
			}
			if (items != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)items).get_Item((System.Int32Enum)eItem);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v6 (System.Object)+18]");
					return 0;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int GetUniqueItemsInRarity(EItemRarity itemRarity)
	{
		Dictionary<EItem, ItemBase>.KeyCollection keys = items.Keys;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
		int num = 0;
		Dictionary<EItem, ItemBase>.KeyCollection.Enumerator enumerator = default(Dictionary<EItem, ItemBase>.KeyCollection.Enumerator);
		EItem item2 = default(EItem);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)DataManager.Instance != null)
				{
					ItemData item = DataManager.Instance.GetItem(item2);
					if ((object)item == null)
					{
						break;
					}
					if (item.rarity == itemRarity)
					{
						num++;
					}
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			return num;
		}
		throw new NullReferenceException();
	}

	public void Cleanup()
	{
		//IL_027c: Expected O, but got I
		//IL_0140: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_015b: Expected O, but got I
		Action value = OnLateFixedUpdate;
		Delegate obj = Delegate.Remove(LateFixedUpdate.A_LateUpdate, value);
		Delegate obj3;
		NullReferenceException typeFromHandle;
		if ((object)obj == null)
		{
			LateFixedUpdate.A_LateUpdate = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj3 = obj;
				goto IL_021f;
			}
			LateFixedUpdate.A_LateUpdate = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag2)
			{
				obj4 = obj;
			}
			bool flag3 = (object)obj4 == null;
			obj3 = obj;
			typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (flag3)
			{
				goto IL_028a;
			}
		}
		bool flag4 = items == null;
		obj3 = obj;
		if (!flag4)
		{
			Dictionary<EItem, ItemBase>.ValueCollection values = items.Values;
			bool flag5 = values == null;
			obj3 = obj;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
				Dictionary<EItem, ItemBase>.ValueCollection.Enumerator enumerator = default(Dictionary<EItem, ItemBase>.ValueCollection.Enumerator);
				Delegate obj5 = default(Delegate);
				Dictionary<EItem, ItemBase>.ValueCollection.Enumerator enumerator3 = default(Dictionary<EItem, ItemBase>.ValueCollection.Enumerator);
				Delegate obj6;
				Dictionary<EItem, ItemBase>.ValueCollection.Enumerator enumerator2;
				while (enumerator.MoveNext())
				{
					bool flag6 = (object)obj5 == null;
					obj6 = obj5;
					enumerator2 = enumerator3;
					obj3 = (Delegate)0;
					if (!flag6)
					{
						obj5.GetObjectData((SerializationInfo)0, (StreamingContext)0);
						continue;
					}
					goto IL_021f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				bool flag7 = itemsWithOnHitProcs == null;
				obj6 = obj5;
				enumerator2 = enumerator3;
				obj3 = (Delegate)0;
				if (!flag7)
				{
					itemsWithOnHitProcs.Clear();
					return;
				}
			}
		}
		typeFromHandle = new NullReferenceException();
		goto IL_028a;
		IL_028a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_021f:
		throw new NullReferenceException();
	}

	private unsafe int _003CSortItems_003Eb__13_0(EItem a, EItem b)
	{
		//IL_00f4: Expected O, but got Ref
		//IL_014d: Expected O, but got Ref
		//IL_011e: Expected I, but got O
		//IL_01e1: Expected I4, but got O
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected I4, but got Unknown
		ItemData item = DataManager.Instance.GetItem(a);
		ItemData item2 = DataManager.Instance.GetItem(b);
		int num2;
		if (item != null && item2 != null)
		{
			int num = item + 120;
			num2 = ((int*)num)->CompareTo(item2.itemTickPriority);
			if (num2 != 0)
			{
				goto IL_01ce;
			}
		}
		nint num3 = default(nint);
		if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)a))
		{
			string value = ((Enum)(&num3)).ToString();
			((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)a, (object)value);
			num3 = (nint)typeof(EItem);
		}
		if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)b))
		{
			string value2 = ((Enum)(&num3)).ToString();
			if (itemToStringCache == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)b, (object)value2);
		}
		object strA = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)a);
		object strB = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)b);
		num2 = string.Compare((string)strA, (string)strB, StringComparison.Ordinal);
		goto IL_01ce;
		IL_01ce:
		return num2;
	}

	private unsafe int _003CSortOnHitItems_003Eb__14_0(EItem a, EItem b)
	{
		//IL_002f: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_0059: Expected I, but got O
		//IL_011c: Expected I4, but got O
		nint num = default(nint);
		if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)a))
		{
			string value = ((Enum)(&num)).ToString();
			((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)a, (object)value);
			num = (nint)typeof(EItem);
		}
		if (!((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).ContainsKey((System.Int32Enum)b))
		{
			string value2 = ((Enum)(&num)).ToString();
			if (itemToStringCache == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (int)ex;
			}
			((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).set_Item((System.Int32Enum)b, (object)value2);
		}
		object strA = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)a);
		object strB = ((Dictionary<System.Int32Enum, object>)(object)itemToStringCache).get_Item((System.Int32Enum)b);
		return string.Compare((string)strA, (string)strB, StringComparison.Ordinal);
	}
}
