using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemEagleClaw : ItemBase
{
	public float procChancePerAmount = 0.08f;

	private float procChance;

	public float damageAddition = 0.66f;

	public float damageAdditionPerAmount = 0.66f;

	private float knockupForce = 3.5f;

	protected override void OnInitOrAmountChanged()
	{
		float input = (float)amount * procChancePerAmount;
		float num = StatScaling.HyperbolicScaling(input);
		procChance = num;
		float num2 = (float)amount * damageAdditionPerAmount;
		damageAddition = num2;
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
		//IL_008c: Expected O, but got I4
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00f8: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		Enemy enemy = dc.enemy;
		if ((object)dc.enemy != null)
		{
			EnemyMovementRb enemyMovement = enemy.enemyMovement;
			object obj;
			if ((object)enemy.enemyMovement != null)
			{
				bool? flag = enemyMovement._003Cgrounded_003Ek__BackingField;
				obj = 0;
			}
			else
			{
				obj = 0;
			}
			object obj2 = obj >> 8;
			object obj3 = obj2 - 1;
			bool flag2 = obj3 == null;
			object obj4 = obj & flag2;
			bool flag3 = obj4 == null;
			object obj5 = !flag3;
			if (obj5 != null)
			{
				return;
			}
		}
		itemAttackModifier.AddAdditive(damageAddition);
	}

	public override bool HasPreAttackProc()
	{
		return true;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_010b: Expected O, but got Ref
		Enemy enemy = dc.enemy;
		EnemyMovementRb enemyMovement = enemy.enemyMovement;
		if (enemyMovement._003Cgrounded_003Ek__BackingField && ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			Enemy enemy2 = dc.enemy;
			float stat = PlayerStats.GetStat(EStat.KnockbackMultiplier);
			float knockbackForce = knockupForce * stat;
			enemy2.enemyMovement.KnockUp(knockbackForce);
			Enemy enemy3 = dc.enemy;
			float stat2 = PlayerStats.GetStat(EStat.KnockbackMultiplier);
			float knockback = knockupForce * stat2;
			object obj = default(object);
			enemy3.enemyMovement.Knockback((Vector3)(&obj), knockback);
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public ItemEagleClaw(ItemInventory itemInventoryRef)
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
			float num = damageAdditionPerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			float num2 = procChancePerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
