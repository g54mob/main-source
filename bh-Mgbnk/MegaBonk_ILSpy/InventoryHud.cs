using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI;
using Cpp2ILInjected;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
	public GameObject itemContainerPrefab;

	public Transform weaponParent;

	public Transform tomeParent;

	private List<InventoryItemPrefabUI> weaponContainers;

	private List<InventoryItemPrefabUI> tomeContainers;

	private void Start()
	{
		//IL_02bd: Expected O, but got I4
		//IL_02c6: Expected O, but got I4
		//IL_02d4: Expected I, but got O
		//IL_009f: Expected O, but got I4
		//IL_00a8: Expected O, but got I4
		//IL_00b6: Expected I, but got O
		//IL_0149: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_0160: Expected I, but got O
		//IL_01a1: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_01b8: Expected I, but got O
		//IL_0223: Expected O, but got I4
		//IL_022c: Expected O, but got I4
		//IL_023a: Expected I, but got O
		//IL_027b: Expected O, but got I4
		//IL_0284: Expected O, but got I4
		//IL_0292: Expected I, but got O
		Refresh();
		Action<WeaponBase> b = OnWeaponAdded;
		Delegate obj = Delegate.Combine(WeaponInventory.A_WeaponAdded, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponAdded = (Action<WeaponBase>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action = default(Action<WeaponBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<WeaponBase>);
				goto IL_0360;
			}
			WeaponInventory.A_WeaponAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			num2 = (nint)typeof(Action<WeaponBase>);
			if (flag)
			{
				goto IL_02f5;
			}
		}
		Action<ETome, EStat> b2 = OnTomeAdded;
		Delegate obj6 = Delegate.Combine(TomeInventory.A_TomeUpgrade, b2);
		if ((object)obj6 == null)
		{
			TomeInventory.A_TomeUpgrade = (Action<ETome, EStat>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ETome, EStat> action2 = default(Action<ETome, EStat>);
			bool flag2 = action2 == null;
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			num2 = (nint)typeof(Action<ETome, EStat>);
			if (flag2)
			{
				goto IL_0300;
			}
			TomeInventory.A_TomeUpgrade = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			num = (nint)typeof(Action<ETome, EStat>);
			if (flag3)
			{
				goto IL_0310;
			}
		}
		Action<PlayerInventory> b3 = OnInventoryInit;
		Delegate obj8 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b3);
		if ((object)obj8 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
		bool flag4 = action3 == null;
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		num = (nint)typeof(Action<PlayerInventory>);
		if (flag4)
		{
			goto IL_0350;
		}
		MyPlayer.A_PlayerInventoryInitialized = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		num = (nint)typeof(Action<PlayerInventory>);
		if (!flag5)
		{
			return;
		}
		goto IL_0360;
		IL_0360:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0350;
		IL_02f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0300:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02f5;
		IL_0310:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0300;
		IL_0350:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0310;
	}

	private void OnDestroy()
	{
		//IL_02a8: Expected I, but got O
		//IL_02b9: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_020e: Expected I, but got O
		//IL_021f: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_0266: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		Action<WeaponBase> value = OnWeaponAdded;
		Delegate obj = Delegate.Remove(WeaponInventory.A_WeaponAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponAdded = (Action<WeaponBase>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action = default(Action<WeaponBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<WeaponBase>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			WeaponInventory.A_WeaponAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02ef;
			}
		}
		Action<ETome, EStat> value2 = OnTomeAdded;
		Delegate obj6 = Delegate.Remove(TomeInventory.A_TomeUpgrade, value2);
		if ((object)obj6 == null)
		{
			TomeInventory.A_TomeUpgrade = (Action<ETome, EStat>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ETome, EStat> action2 = default(Action<ETome, EStat>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<ETome, EStat>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02fa;
			}
			TomeInventory.A_TomeUpgrade = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<ETome, EStat>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030a;
			}
		}
		Action<PlayerInventory> value3 = OnInventoryInit;
		Delegate obj8 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value3);
		if ((object)obj8 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action3 = default(Action<PlayerInventory>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_034a;
		}
		MyPlayer.A_PlayerInventoryInitialized = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_035a;
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
		IL_02ef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02ef;
		IL_030a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02fa;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030a;
	}

	private void OnInventoryInit(PlayerInventory obj)
	{
		Refresh();
	}

	public void Refresh()
	{
		//IL_05af: Expected O, but got I
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.inventory == null)
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory = instance2.inventory;
		TomeInventory tomeInventory = inventory.tomeInventory;
		Dictionary<ETome, int>.KeyCollection keys = tomeInventory.tomeLevels.Keys;
		List<System.Int32Enum> list = Enumerable.ToList((IEnumerable<System.Int32Enum>)(object)keys);
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerInventory inventory2 = instance3.inventory;
		WeaponInventory weaponInventory = inventory2.weaponInventory;
		Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
		List<object> list2 = Enumerable.ToList((IEnumerable<object>)values);
		int numAvailableWeaponSlots = InventoryUtility.GetNumAvailableWeaponSlots();
		int num = list2._size;
		if (numAvailableWeaponSlots > list2._size)
		{
			num = numAvailableWeaponSlots;
		}
		int numAvailableTomeSlots = InventoryUtility.GetNumAvailableTomeSlots();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		int num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		if ((nint)numAvailableTomeSlots > (nint)0)
		{
			num2 = numAvailableTomeSlots;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
		int num3 = list2._size;
		int num4 = default(int);
		if (num4 > list2._size)
		{
			num3 = num4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804203C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = default(object);
		if ((nint)obj2 > 0)
		{
			obj = obj2;
		}
		bool flag = num3 <= 0;
		int num5 = 0;
		if (!flag)
		{
			do
			{
				List<InventoryItemPrefabUI> list3 = weaponContainers;
				if (num5 >= list3._size)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(itemContainerPrefab, weaponParent);
					InventoryItemPrefabUI component = gameObject.GetComponent<InventoryItemPrefabUI>();
					list3.Add(component);
				}
				InventoryItemPrefabUI inventoryItemPrefabUI = weaponContainers.get_Item(num5);
				GameObject gameObject2 = inventoryItemPrefabUI.gameObject;
				gameObject2.SetActive(value: true);
				if (num5 >= num)
				{
					InventoryItemPrefabUI inventoryItemPrefabUI2 = weaponContainers.get_Item(num5);
					GameObject gameObject3 = inventoryItemPrefabUI2.gameObject;
					gameObject3.SetActive(value: false);
				}
				else
				{
					UnlockableBase item;
					InventoryItemPrefabUI inventoryItemPrefabUI4;
					if (list2._size <= num5)
					{
						InventoryItemPrefabUI inventoryItemPrefabUI3 = weaponContainers.get_Item(num5);
						item = null;
						inventoryItemPrefabUI4 = inventoryItemPrefabUI3;
					}
					else
					{
						InventoryItemPrefabUI inventoryItemPrefabUI5 = weaponContainers.get_Item(num5);
						WeaponBase weaponBase = ((List<WeaponBase>)(object)list2).get_Item(num5);
						item = weaponBase.weaponData;
						inventoryItemPrefabUI4 = inventoryItemPrefabUI5;
					}
					inventoryItemPrefabUI4.SetItem(item);
				}
				num5++;
			}
			while (num5 < num3);
		}
		if ((nint)obj > 0)
		{
			int num6 = 0;
			do
			{
				List<InventoryItemPrefabUI> list4 = tomeContainers;
				if (num6 >= list4._size)
				{
					GameObject gameObject4 = UnityEngine.Object.Instantiate(itemContainerPrefab, tomeParent);
					InventoryItemPrefabUI component2 = gameObject4.GetComponent<InventoryItemPrefabUI>();
					list4.Add(component2);
				}
				InventoryItemPrefabUI inventoryItemPrefabUI6 = tomeContainers.get_Item(num6);
				GameObject gameObject5 = inventoryItemPrefabUI6.gameObject;
				gameObject5.SetActive(value: true);
				if (num6 >= num2)
				{
					InventoryItemPrefabUI inventoryItemPrefabUI7 = tomeContainers.get_Item(num6);
					GameObject gameObject6 = inventoryItemPrefabUI7.gameObject;
					gameObject6.SetActive(value: false);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rax_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					UnlockableBase item2;
					InventoryItemPrefabUI inventoryItemPrefabUI9;
					if ((nint)0 <= (nint)num6)
					{
						InventoryItemPrefabUI inventoryItemPrefabUI8 = tomeContainers.get_Item(num6);
						item2 = null;
						inventoryItemPrefabUI9 = inventoryItemPrefabUI8;
					}
					else
					{
						InventoryItemPrefabUI inventoryItemPrefabUI10 = tomeContainers.get_Item(num6);
						ETome eTome = ((List<ETome>)(object)list).get_Item(num6);
						TomeData tome = DataManager.Instance.GetTome(eTome);
						item2 = tome;
						inventoryItemPrefabUI9 = inventoryItemPrefabUI10;
					}
					inventoryItemPrefabUI9.SetItem(item2);
				}
				num6++;
			}
			while (num6 < (nint)obj);
		}
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
	}

	private void OnTomeAdded(ETome eTome, EStat obj)
	{
		Refresh();
	}

	private void OnWeaponAdded(WeaponBase obj)
	{
		Refresh();
	}

	public InventoryHud()
	{
		List<InventoryItemPrefabUI> list = new List<InventoryItemPrefabUI>();
		weaponContainers = list;
		tomeContainers = new List<InventoryItemPrefabUI>();
		base._002Ector();
	}
}
