using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSpikyShield : ItemBase
{
	private float armorPerAmount = 0.1f;

	private float retaliationPerArmorPerAmount = 200f;

	private float lastStoredArmor;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.Armor;
		float modification = (float)amount * armorPerAmount;
		statModifier.modification = modification;
		SetStat(statModifier);
		float num = MyTime.time + 1f;
		nextUpdateTime = num;
	}

	private void UpdateRetaliation()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		float statRaw = PlayerStats.GetStatRaw(EStat.Armor);
		bool flag = lastStoredArmor == statRaw;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180467B05h\"");
		if (!flag)
		{
			object obj = amount * retaliationPerArmorPerAmount;
			StatModifier statModifier = new StatModifier();
			float modification = (float)obj * statRaw;
			statModifier.modifyType = EStatModifyType.Flat;
			statModifier.stat = EStat.Thorns;
			statModifier.modification = modification;
			SetStat(statModifier);
			lastStoredArmor = statRaw;
		}
	}

	public override void Tick()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (!(nextUpdateTime > MyTime.time))
		{
			float num = MyTime.time + 1f;
			nextUpdateTime = num;
			float statRaw = PlayerStats.GetStatRaw(EStat.Armor);
			bool flag = lastStoredArmor == statRaw;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180467A41h\"");
			if (!flag)
			{
				object obj = amount * retaliationPerArmorPerAmount;
				StatModifier statModifier = new StatModifier();
				float modification = (float)obj * statRaw;
				statModifier.modifyType = EStatModifyType.Flat;
				statModifier.stat = EStat.Thorns;
				statModifier.modification = modification;
				SetStat(statModifier);
				lastStoredArmor = statRaw;
			}
		}
	}

	public ItemSpikyShield(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
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
		string text = EnumUtility.EnumToReadable(EStat.Thorns);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			string text2 = EnumUtility.EnumToReadable(EStat.Armor);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			float num = retaliationPerArmorPerAmount / 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"+{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)"1%");
			float num2 = armorPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value3", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
