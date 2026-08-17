using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemIceCrystal(ItemInventory itemInventoryRef) : ItemBase(itemInventoryRef)
{
	private float freezeTime;

	public float procChancePerAmount = 0.075f;

	private float procChance;

	protected override void OnInitOrAmountChanged()
	{
		//IL_005f: Invalid comparison between I4 and F4
		//IL_006e: Expected F4, but got I4
		float input = (float)amount * procChancePerAmount;
		float num = StatScaling.HyperbolicScaling(input, 1f, 0.75f);
		procChance = num;
		float num2 = (float)amount * 0.1f;
		float num3 = num2 + 2.5f;
		bool flag = 0f > num3;
		float num4 = 0f;
		if (!flag)
		{
			bool flag2 = num3 > 6f;
			num4 = 6f;
			if (!flag2)
			{
				freezeTime = num3;
				return;
			}
		}
		freezeTime = num4;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
		if (ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			int stacks = default(int);
			dc.enemy.AddDebuff(EDebuff.Freeze, dc, freezeTime, stacks);
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = procChancePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
