using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBeefyRing : ItemBase
{
	private int maxHpPerStack = 10;

	private float powerPerHpPerAmount = 0.002f;

	private int lastStoredMaxHp;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.MaxHealth;
		float modification = (float)maxHpPerStack * (float)amount;
		statModifier.modification = modification;
		SetStat(statModifier);
		float num = MyTime.time + 1f;
		nextUpdateTime = num;
	}

	private void RefreshPower()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		int combinedMaxHp = inventory.playerHealth.GetCombinedMaxHp();
		if (combinedMaxHp != lastStoredMaxHp)
		{
			StatModifier statModifier = new StatModifier();
			statModifier.stat = EStat.DamageMultiplier;
			object obj = combinedMaxHp * powerPerHpPerAmount;
			float modification = (float)obj * (float)amount;
			statModifier.modification = modification;
			SetStat(statModifier);
			lastStoredMaxHp = combinedMaxHp;
		}
	}

	public override void Tick()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		if (!(nextUpdateTime > MyTime.time))
		{
			float num = MyTime.time + 1f;
			nextUpdateTime = num;
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int combinedMaxHp = inventory.playerHealth.GetCombinedMaxHp();
			if (combinedMaxHp != lastStoredMaxHp)
			{
				StatModifier statModifier = new StatModifier();
				statModifier.stat = EStat.DamageMultiplier;
				object obj = combinedMaxHp * powerPerHpPerAmount;
				float modification = (float)obj * (float)amount;
				statModifier.modification = modification;
				SetStat(statModifier);
				lastStoredMaxHp = combinedMaxHp;
			}
		}
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public ItemBeefyRing(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
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
			string text2 = EnumUtility.EnumToReadable(EStat.MaxHealth);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat2", (object)text2);
			float num = powerPerHpPerAmount * 100f;
			float num2 = num * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"+{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
