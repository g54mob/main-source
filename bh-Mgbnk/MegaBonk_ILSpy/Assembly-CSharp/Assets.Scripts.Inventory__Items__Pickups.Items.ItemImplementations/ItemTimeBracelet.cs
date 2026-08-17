using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemTimeBracelet : ItemBase
{
	private float damagePerAmount = 0.08f;

	protected override void OnInitOrAmountChanged()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.XpIncreaseMultiplier;
		float modification = (float)amount * damagePerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
	}

	public ItemTimeBracelet(ItemInventory itemInventoryRef)
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
		//IL_0229: Expected O, but got I
		//IL_00e8: Expected O, but got I4
		//IL_00f6: Expected I, but got O
		//IL_010c: Expected I, but got O
		//IL_0125: Expected O, but got I
		//IL_014d: Expected O, but got I
		//IL_0155: Expected I, but got O
		//IL_025a: Expected O, but got I
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.XpIncreaseMultiplier);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 32;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = damagePerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"+{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			string localizedString2 = LocalizationUtility.GetLocalizedString("ItemsGray", "TimeBracelet_NAME");
			((Dictionary<object, object>)(object)dictionary).Add((object)"time_bracelet", (object)localizedString2);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = localizedString2;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v14 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, localizedString2);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = localizedString2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v14 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num = (nint)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)num).Add((string)obj2, obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				num = (nint)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = localizedString2;
				obj2 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
