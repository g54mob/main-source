using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemRollerblades : ItemBase
{
	private float cap;

	private float maxAttackSpeedPerAmount = 0.4f;

	private float updateStatsInterval = 0.25f;

	private float nextUpdateTime;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * maxAttackSpeedPerAmount;
		cap = num;
	}

	public ItemRollerblades(ItemInventory itemInventoryRef)
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
		//IL_0057: Invalid comparison between I4 and F4
		//IL_00a4: Expected F4, but got I4
		if (nextUpdateTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + updateStatsInterval;
		nextUpdateTime = num;
		MyPlayer instance = MyPlayer.Instance;
		float speedHorizontal = instance.playerMovement.GetSpeedHorizontal();
		MyPlayer instance2 = MyPlayer.Instance;
		float num2 = speedHorizontal / instance2._003CbaseMovementSpeed_003Ek__BackingField;
		float num3 = num2 - 1f;
		if (!(0f > num3))
		{
			if (num3 > cap)
			{
				num3 = cap;
			}
		}
		else
		{
			num3 = 0f;
		}
		StatModifier statModifier = new StatModifier();
		float modification = (float)amount * num3;
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.AttackSpeed;
		statModifier.modification = modification;
		SetStat(statModifier);
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
		string text = EnumUtility.EnumToReadable(EStat.AttackSpeed);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = maxAttackSpeedPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
