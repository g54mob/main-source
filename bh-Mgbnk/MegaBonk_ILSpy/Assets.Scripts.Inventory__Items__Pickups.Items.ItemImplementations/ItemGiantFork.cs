using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemGiantFork : ItemBase
{
	private float critChancePerAmount = 0.15f;

	private float megaCritChancePerAmount = 0.14f;

	private float megaCritChance;

	private float megaCritDamageMultiplier = 4f;

	private float extraDamageMultiplierPerAmount = 0.15f;

	private float finalMegacritMultiplier = 4f;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0089: Expected O, but got I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		float num = (float)amount * megaCritChancePerAmount;
		megaCritChance = num;
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.CritChance;
		float modification = (float)amount * critChancePerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
		finalMegacritMultiplier = megaCritDamageMultiplier;
		if (amount > 1)
		{
			object obj = amount - 1;
			object obj2 = obj * extraDamageMultiplierPerAmount;
			float num2 = (float)obj2 + megaCritDamageMultiplier;
			finalMegacritMultiplier = num2;
		}
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
		if (dc.crit && dc.enemy != null && ItemUtility.TryProc(megaCritChance, dc.procCoefficient))
		{
			dc.damageEffect = EDamageEffect.Megacrit;
			itemAttackModifier.AddMultiplier(finalMegacritMultiplier);
		}
	}

	public override bool HasPreAttackProc()
	{
		return true;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public ItemGiantFork(ItemInventory itemInventoryRef)
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

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_00fe: Expected I, but got O
		//IL_0117: Expected O, but got I
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = megaCritChancePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"{obj}";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
		string text = EnumUtility.EnumToReadable(EStat.CritChance);
		if (text == null)
		{
			text = "";
		}
		((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text);
		float num2 = critChancePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value2 = $"+{arg}%";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
		float num3 = extraDamageMultiplierPerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg2 = default(object);
		string value3 = $"{arg2}";
		((Dictionary<object, object>)(object)dictionary).Add((object)"value3", (object)value3);
		object[] array = new object[1];
		if (array != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rdx_v18 (Il2CppClass<System.Object[]>)+40]");
			dictionary.Add((string)0, value3);
			object obj2 = default(object);
			if (obj2 == null)
			{
				((Dictionary<string, object>)(object)"{0}").Add((string)obj, (object)null);
				object obj3 = default(object);
				throw obj3;
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
