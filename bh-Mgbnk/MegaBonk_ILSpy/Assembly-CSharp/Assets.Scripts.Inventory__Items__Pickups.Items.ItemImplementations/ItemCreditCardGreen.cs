using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Chests;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCreditCardGreen : ItemBase
{
	private float luckPerChestPerAmount = 0.02f;

	private float luckPerChest;

	private float chestPriceIncreasePerAmount = 0.1f;

	private float accumulatedLuck;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * luckPerChestPerAmount;
		luckPerChest = num;
		StatModifier statModifier = new StatModifier();
		float modification = chestPriceIncreasePerAmount * (float)amount;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.ChestPriceMultiplier;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public override void Init()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0230: Expected O, but got I4
		//IL_0246: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_027a: Expected O, but got I4
		Action b = OnChestWindowOpen;
		Delegate obj = Delegate.Combine(InteractableChest.A_ChestOpened, b);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			InteractableChest.A_ChestOpened = null;
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
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02d3;
			}
			InteractableChest.A_ChestOpened = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b8;
			}
		}
		Action b2 = OnChestWindowOpen;
		Delegate obj6 = Delegate.Combine(OpenChest.A_Open, b2);
		if ((object)obj6 == null)
		{
			OpenChest.A_Open = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02c3;
		}
		OpenChest.A_Open = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02d3;
		IL_02b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b8;
		IL_02d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c3;
	}

	public override void Cleanup()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0230: Expected O, but got I4
		//IL_0246: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_027a: Expected O, but got I4
		Action value = OnChestWindowOpen;
		Delegate obj = Delegate.Remove(InteractableChest.A_ChestOpened, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			InteractableChest.A_ChestOpened = null;
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
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02d3;
			}
			InteractableChest.A_ChestOpened = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b8;
			}
		}
		Action value2 = OnChestWindowOpen;
		Delegate obj6 = Delegate.Remove(OpenChest.A_Open, value2);
		if ((object)obj6 == null)
		{
			OpenChest.A_Open = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02c3;
		}
		OpenChest.A_Open = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02d3;
		IL_02b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b8;
		IL_02d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c3;
	}

	private unsafe void OnChestWindowOpen()
	{
		//IL_002d: Expected O, but got Ref
		float num = accumulatedLuck + luckPerChest;
		accumulatedLuck = num;
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		StatInventory statInventory = inventory.statInventory;
		object obj = default(object);
		string key = ((Enum)(&obj)).ToString();
		StatModifier statModifier = new StatModifier();
		statModifier.modification = accumulatedLuck;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Luck;
		((Dictionary<object, object>)(object)statInventory.movingStats).set_Item((object)key, (object)statModifier);
		bool flag = statInventory.refreshStats.Add(statModifier.stat);
	}

	public ItemCreditCardGreen(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Tick()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_0115: Expected I, but got O
		//IL_012e: Expected O, but got I
		//IL_0213: Expected O, but got I
		//IL_0213: Expected O, but got I4
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Luck);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
		float num = luckPerChestPerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"+{arg}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		string text2 = EnumUtility.EnumToReadable(EStat.ChestPriceMultiplier);
		if (text2 == null)
		{
			text2 = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
		float num2 = chestPriceIncreasePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg2 = default(object);
		string value2 = $"+{arg2}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
		object[] array = new object[1];
		if (array != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v17 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, value2);
			object obj = default(object);
			if (obj == null)
			{
				IntPtr intPtr = default(IntPtr);
				((Dictionary<string, object>)30).Add("stat1", (nint)intPtr);
				object obj2 = default(object);
				throw obj2;
			}
			array[0] = dictionary;
			if (localizedString != null)
			{
				return localizedString.GetLocalizedString(array);
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
