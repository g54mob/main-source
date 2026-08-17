using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemChonkplate : ItemBase
{
	private float overhealPerAmount = 0.75f;

	private float lifestealPerAmount = 0.2f;

	protected override void OnInitOrAmountChanged()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Overheal;
		float modification = (float)amount * overhealPerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		statModifier2.modifyType = EStatModifyType.Flat;
		statModifier2.stat = EStat.Lifesteal;
		float modification2 = (float)amount * lifestealPerAmount;
		statModifier2.modification = modification2;
		SetStat(statModifier2);
	}

	public ItemChonkplate(ItemInventory itemInventoryRef)
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.MaxHealth);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			string text2 = EnumUtility.EnumToReadable(EStat.Overheal);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			string text3 = EnumUtility.EnumToReadable(EStat.Lifesteal);
			if (text3 == null)
			{
				text3 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat3", (object)text3);
			float num = overhealPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			float num2 = lifestealPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
