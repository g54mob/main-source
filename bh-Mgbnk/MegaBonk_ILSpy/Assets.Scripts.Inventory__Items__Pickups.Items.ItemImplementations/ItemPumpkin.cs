using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemPumpkin : ItemBase
{
	private int extraPotsPerAmount = 8;

	private float rewardMultiplierPerAmount = 0.18f;

	public float GetRewardMultiplier()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		object obj = amount * rewardMultiplierPerAmount;
		return (float)obj + 1f;
	}

	public int GetExtraPotsSmall()
	{
		return extraPotsPerAmount * amount;
	}

	public int GetExtraPotsBig()
	{
		//IL_0011: Expected O, but got I4
		object obj = extraPotsPerAmount * amount;
		float num = (float)obj * 0.25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public ItemPumpkin(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	protected override void OnInitOrAmountChanged()
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
		//IL_00da: Expected O, but got I4
		//IL_00fe: Expected I, but got O
		//IL_0117: Expected O, but got I
		//IL_0144: Expected O, but got I
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"+{obj}";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text = "+{0}";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value", (object)value);
			float num = rewardMultiplierPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num2 = 0;
			obj2 = text2;
			obj3 = 1;
			text = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num2 = 0;
				obj2 = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
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
				num2 = 0;
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
