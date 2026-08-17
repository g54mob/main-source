using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemUnstableTransfusion : ItemBase
{
	private float chanceToStackPerAmount = 0.35f;

	private float totalChance;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * chanceToStackPerAmount;
		totalChance = num;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_003c: Invalid comparison between F4 and I4
		//IL_004e: Expected F8, but got I4
		double num;
		if (ItemUtility.TryProc(dc.procCoefficient, totalChance))
		{
			bool flag = !(chanceToStackPerAmount > 0f);
			num = 0.0;
			if (!flag)
			{
				goto IL_0061;
			}
			goto IL_00a3;
		}
		return;
		IL_00a3:
		float baseProcChance = totalChance - (float)num;
		if (ItemUtility.TryProc(dc.procCoefficient, baseProcChance))
		{
			int stacks = default(int);
			dc.enemy.AddDebuff(EDebuff.Bloodmark, dc, 5f, stacks);
			return;
		}
		goto IL_0061;
		IL_0061:
		double num2 = Math.Floor(totalChance);
		num = num2;
		goto IL_00a3;
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public ItemUnstableTransfusion(ItemInventory itemInventoryRef)
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

	public unsafe override string GetDescription(LocalizedString localizedString)
	{
		//IL_0037: Expected O, but got Ref
		//IL_0088: Expected I, but got O
		//IL_00a1: Expected O, but got I
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = chanceToStackPerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"+{obj}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		object obj2 = default(object);
		string key = ((Enum)(&obj2)).ToString();
		string text = LocalizationUtility.GetLocalizedString("DamageSources", key);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"bloodmark", (object)text);
		object[] array = new object[1];
		if (array != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, text);
			object obj3 = default(object);
			if (obj3 == null)
			{
				((Dictionary<string, object>)(object)"+{0}%").Add((string)obj, (object)null);
				object obj4 = default(object);
				throw obj4;
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
