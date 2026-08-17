using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBeer : ItemBase
{
	private float damagePerStack = 0.2f;

	private float maxHealthPerStack = -0.05f;

	protected override void OnInitOrAmountChanged()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.DamageMultiplier;
		float modification = (float)amount * damagePerStack;
		statModifier.modification = modification;
		SetStat(statModifier);
		StatModifier statModifier2 = new StatModifier();
		statModifier2.stat = EStat.MaxHealth;
		float modification2 = (float)amount * maxHealthPerStack;
		statModifier2.modification = modification2;
		SetStat(statModifier2);
	}

	public ItemBeer(ItemInventory itemInventoryRef)
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
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = damagePerStack * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"+{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			string text2 = EnumUtility.EnumToReadable(EStat.MaxHealth);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			float num2 = maxHealthPerStack * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
