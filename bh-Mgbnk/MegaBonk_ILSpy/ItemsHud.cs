using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Cpp2ILInjected;
using UnityEngine;

public class ItemsHud : MonoBehaviour
{
	public GameObject prefab;

	private Dictionary<EItem, ItemsHudElementPrefab> itemToPrefab;

	private void Start()
	{
		//IL_030d: Expected O, but got I4
		//IL_0334: Expected O, but got I4
		//IL_01bf: Expected I, but got O
		//IL_01c8: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_0269: Expected I, but got O
		//IL_0272: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_008e: Expected O, but got I4
		//IL_02c1: Expected I, but got O
		//IL_02ca: Expected O, but got I4
		//IL_02db: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		MyPlayer instance = MyPlayer.Instance;
		Action<EItem> action;
		Dictionary<EItem, ItemBase>.KeyCollection.Enumerator enumerator;
		if ((object)MyPlayer.Instance == null || instance.inventory == null)
		{
			action = null;
			enumerator = (Dictionary<EItem, ItemBase>.KeyCollection.Enumerator)0;
			goto IL_0374;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		bool flag = (object)MyPlayer.Instance == null;
		enumerator = (Dictionary<EItem, ItemBase>.KeyCollection.Enumerator)0;
		if (!flag)
		{
			PlayerInventory inventory = instance2.inventory;
			bool flag2 = instance2.inventory == null;
			enumerator = (Dictionary<EItem, ItemBase>.KeyCollection.Enumerator)0;
			if (!flag2)
			{
				ItemInventory itemInventory = inventory.itemInventory;
				bool flag3 = inventory.itemInventory == null;
				enumerator = (Dictionary<EItem, ItemBase>.KeyCollection.Enumerator)0;
				if (!flag3)
				{
					bool flag4 = itemInventory.items == null;
					enumerator = (Dictionary<EItem, ItemBase>.KeyCollection.Enumerator)0;
					if (!flag4)
					{
						Dictionary<EItem, ItemBase>.KeyCollection keys = itemInventory.items.Keys;
						bool flag5 = keys == null;
						enumerator = (Dictionary<EItem, ItemBase>.KeyCollection.Enumerator)0;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE40");
							Dictionary<EItem, ItemBase>.KeyCollection.Enumerator enumerator2 = default(Dictionary<EItem, ItemBase>.KeyCollection.Enumerator);
							EItem item = default(EItem);
							while (enumerator2.MoveNext())
							{
								OnItemAdded(item);
							}
							enumerator2.Dispose();
							action = null;
							Dictionary<EItem, ItemBase>.KeyCollection.Enumerator enumerator3 = default(Dictionary<EItem, ItemBase>.KeyCollection.Enumerator);
							enumerator = enumerator3;
							goto IL_0374;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0374:
		Action<EItem> b = OnItemAdded;
		Delegate obj = Delegate.Combine(ItemInventory.A_ItemAdded, b);
		nint num;
		object obj3;
		Delegate obj4;
		object obj5;
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = action;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action2 = default(Action<EItem>);
			if (action2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				throw obj;
			}
			ItemInventory.A_ItemAdded = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag6 = obj2 == null;
			num = (nint)typeof(Action<EItem>);
			obj3 = 0;
			obj4 = obj;
			obj5 = 0;
			if (flag6)
			{
				goto IL_03cf;
			}
		}
		Action<EItem, bool> b2 = OnItemRemoved;
		Delegate obj6 = Delegate.Combine(ItemInventory.A_ItemRemoved, b2);
		if ((object)obj6 == null)
		{
			ItemInventory.A_ItemRemoved = (Action<EItem, bool>)(object)action;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem, bool> action3 = default(Action<EItem, bool>);
		bool flag7 = action3 == null;
		num = (nint)typeof(Action<EItem, bool>);
		obj3 = 0;
		obj4 = obj6;
		obj5 = 0;
		if (!flag7)
		{
			ItemInventory.A_ItemRemoved = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag8 = obj7 == null;
			num = (nint)typeof(Action<EItem, bool>);
			obj3 = 0;
			obj4 = obj6;
			obj5 = 0;
			if (!flag8)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03cf;
		IL_03cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<EItem> value = OnItemAdded;
		Delegate obj = Delegate.Remove(ItemInventory.A_ItemAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ItemInventory.A_ItemAdded = (Action<EItem>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EItem> action = default(Action<EItem>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EItem>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			ItemInventory.A_ItemAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EItem>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<EItem, bool> value2 = OnItemRemoved;
		Delegate obj6 = Delegate.Remove(ItemInventory.A_ItemRemoved, value2);
		if ((object)obj6 == null)
		{
			ItemInventory.A_ItemRemoved = (Action<EItem, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EItem, bool> action2 = default(Action<EItem, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<EItem, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		ItemInventory.A_ItemRemoved = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<EItem, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private void OnItemAdded(EItem item)
	{
		if (!((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).ContainsKey((System.Int32Enum)item))
		{
			Transform transform = prefab.transform;
			Transform parent = transform.parent;
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent);
			ItemsHudElementPrefab component = gameObject.GetComponent<ItemsHudElementPrefab>();
			GameObject gameObject2 = component.gameObject;
			gameObject2.SetActive(value: true);
			((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).Add((System.Int32Enum)item, (object)component);
			ItemData item2 = DataManager.Instance.GetItem(item);
			Texture icon = item2.GetIcon();
			component.icon.texture = icon;
		}
		object obj = ((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).get_Item((System.Int32Enum)item);
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int amount = inventory.itemInventory.GetAmount(item);
		((ItemsHudElementPrefab)obj).SetAmount(amount);
	}

	private void OnItemRemoved(EItem item, bool showEffect)
	{
		if (((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).ContainsKey((System.Int32Enum)item))
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int amount = inventory.itemInventory.GetAmount(item);
			if (amount <= 0)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).get_Item((System.Int32Enum)item);
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).Remove((System.Int32Enum)item);
				GameObject obj2 = ((Component)obj).gameObject;
				UnityEngine.Object.Destroy(obj2);
			}
			else
			{
				object obj3 = ((Dictionary<System.Int32Enum, object>)(object)itemToPrefab).get_Item((System.Int32Enum)item);
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				int amount2 = inventory2.itemInventory.GetAmount(item);
				((ItemsHudElementPrefab)obj3).SetAmount(amount2);
			}
		}
	}

	public ItemsHud()
	{
		Dictionary<EItem, ItemsHudElementPrefab> dictionary = new Dictionary<EItem, ItemsHudElementPrefab>();
		itemToPrefab = dictionary;
		base._002Ector();
	}
}
