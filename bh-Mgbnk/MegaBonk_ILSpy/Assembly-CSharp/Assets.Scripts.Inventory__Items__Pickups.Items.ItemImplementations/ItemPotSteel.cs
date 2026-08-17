using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemPotSteel : ItemBase
{
	private int weaponLevelsPerAmountMax = 10;

	private int weaponLevelsPerAmountMin = 2;

	private int startFalloffAtAmount = 1;

	public int weaponLevels;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0011: Expected O, but got I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected I4, but got Unknown
		object obj = amount - startFalloffAtAmount;
		if ((nint)obj > 0)
		{
			int num = weaponLevelsPerAmountMin;
			int num2 = weaponLevelsPerAmountMax - obj;
			if (num2 >= weaponLevelsPerAmountMin)
			{
				num = num2;
			}
			int num3 = weaponLevels + num;
			weaponLevels = num3;
		}
		else
		{
			int num4 = weaponLevelsPerAmountMax + weaponLevels;
			weaponLevels = num4;
		}
	}

	private int GetLevelsForAmount(int minPerAmount, int maxPerAmount)
	{
		//IL_0011: Expected O, but got I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected I4, but got Unknown
		object obj = amount - startFalloffAtAmount;
		int num = default(int);
		int result;
		if ((nint)obj > 0)
		{
			num -= obj;
			bool flag = num < minPerAmount;
			result = minPerAmount;
			if (flag)
			{
				goto IL_006f;
			}
		}
		result = num;
		goto IL_006f;
		IL_006f:
		return result;
	}

	public ItemPotSteel(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
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
		//IL_0100: Expected O, but got I4
		//IL_0124: Expected I, but got O
		//IL_013d: Expected O, but got I
		//IL_016a: Expected O, but got I
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"{obj}";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text = "{0}";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value2 = $"{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string text2 = $"{arg2}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value3", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num = 0;
			obj2 = text2;
			obj3 = 1;
			text = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v16 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num = 0;
				obj2 = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v16 (Il2CppClass<System.Object[]>)+40]");
				obj3 = 0;
				text = (string)(object)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)(object)text).Add((string)obj3, obj2);
					object obj5 = default(object);
					throw obj5;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				text = (string)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				num = 0;
				obj2 = text2;
				obj3 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
