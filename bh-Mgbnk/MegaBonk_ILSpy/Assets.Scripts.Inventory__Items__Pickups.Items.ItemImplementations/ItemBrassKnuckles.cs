using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBrassKnuckles : ItemBase
{
	private float damagePerAmount = 0.25f;

	private float flatValue;

	private float radius;

	private float baseRadius = 8f;

	private float radiusAddPerAmount = 2f;

	protected override void OnInitOrAmountChanged()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		object obj = amount * radiusAddPerAmount;
		float num = (float)obj + baseRadius;
		radius = num;
		float num2 = (float)amount * damagePerAmount;
		flatValue = num2;
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
		Enemy enemy = dc.enemy;
		EnemyMovementRb enemyMovement = enemy.enemyMovement;
		if (!(enemyMovement.distanceToTarget > radius))
		{
			float num = flatValue + itemAttackModifier._003CbaseValue_003Ek__BackingField;
			itemAttackModifier.hasModifications = true;
			itemAttackModifier._003CbaseValue_003Ek__BackingField = num;
		}
	}

	public override bool HasPreAttackProc()
	{
		return true;
	}

	public ItemBrassKnuckles(ItemInventory itemInventoryRef)
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
		float num = damagePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string value = $"+{arg}%";
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
