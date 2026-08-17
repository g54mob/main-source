using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Cpp2ILInjected;
using UnityEngine;

public class ToxicBarrelEffect : MonoBehaviour
{
	public EffectPlayer effectPlayer;

	private void Awake()
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
		Action<float> b = OnUse;
		Delegate obj = Delegate.Combine(ItemToxicBarrel.A_OnUse, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ItemToxicBarrel.A_OnUse = (Action<float>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<float>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			ItemToxicBarrel.A_OnUse = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02ef;
			}
		}
		Action<ItemBase> b2 = Refresh;
		Delegate obj6 = Delegate.Combine(ItemBase.A_ItemAdded, b2);
		if ((object)obj6 == null)
		{
			ItemBase.A_ItemAdded = (Action<ItemBase>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ItemBase> action2 = default(Action<ItemBase>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<ItemBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02fa;
			}
			ItemBase.A_ItemAdded = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<ItemBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030a;
			}
		}
		Action<PlayerInventory> b3 = OnInventory;
		Delegate obj8 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b3);
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
		Action<float> value = OnUse;
		Delegate obj = Delegate.Remove(ItemToxicBarrel.A_OnUse, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			ItemToxicBarrel.A_OnUse = (Action<float>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<float>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			ItemToxicBarrel.A_OnUse = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02ef;
			}
		}
		Action<ItemBase> value2 = Refresh;
		Delegate obj6 = Delegate.Remove(ItemBase.A_ItemAdded, value2);
		if ((object)obj6 == null)
		{
			ItemBase.A_ItemAdded = (Action<ItemBase>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<ItemBase> action2 = default(Action<ItemBase>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<ItemBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02fa;
			}
			ItemBase.A_ItemAdded = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<ItemBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030a;
			}
		}
		Action<PlayerInventory> value3 = OnInventory;
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

	private void Start()
	{
		Refresh(null);
	}

	private void OnInventory(PlayerInventory inv)
	{
		Refresh(null);
	}

	private void Refresh(ItemBase obj)
	{
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.itemInventory != null)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				int amount = inventory2.itemInventory.GetAmount(EItem.ToxicBarrel);
				int num = amount ^ amount;
				int num2 = amount & num;
				bool flag = num2 < 0;
				bool flag2 = amount < 0;
				bool flag3 = amount == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				bool active = flag5 & flag4;
				GameObject gameObject = effectPlayer.gameObject;
				gameObject.SetActive(active);
			}
		}
	}

	public unsafe void OnUse(float radius)
	{
		//IL_0021: Expected O, but got Ref
		Transform transform = effectPlayer.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
		effectPlayer.Play();
	}
}
