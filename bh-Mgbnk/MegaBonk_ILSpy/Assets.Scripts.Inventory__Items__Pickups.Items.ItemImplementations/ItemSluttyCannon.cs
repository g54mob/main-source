using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSluttyCannon : ItemBase
{
	private float procChance;

	public float procChancePerAmount;

	public float damageRatio;

	public float damageRatioPerAmount;

	private string damageSource;

	private Dictionary<GameObject, Rocket> rocketLookup;

	private int maxProcsPerTick;

	private int numProcsThisTick;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		float input = (float)amount * procChancePerAmount;
		if ((procChance = StatScaling.HyperbolicScaling(input)) > 0.6f)
		{
			procChance = 0.6f;
		}
		object obj = amount * damageRatioPerAmount;
		float num = (float)obj + 1f;
		damageRatio = num;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0148: Expected O, but got Ref
		if (numProcsThisTick >= maxProcsPerTick || !ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			return;
		}
		int num = numProcsThisTick + 1;
		numProcsThisTick = num;
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.rocketPool.Get();
		if (gameObject != null)
		{
			if (!rocketLookup.ContainsKey(gameObject))
			{
				Rocket component = gameObject.GetComponent<Rocket>();
				((Dictionary<object, object>)(object)rocketLookup).Add((object)gameObject, (object)component);
			}
			Rocket rocket = rocketLookup.get_Item(gameObject);
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			float damage = damageRatio * dc.damage;
			object obj = default(object);
			WeaponBase weaponBase = default(WeaponBase);
			bool useGenericPool = default(bool);
			string text = default(string);
			rocket.Set((Vector3)(&obj), damage, 0f, weaponBase, useGenericPool, text);
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public override void Tick()
	{
		numProcsThisTick = 0;
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

	public unsafe ItemSluttyCannon(ItemInventory itemInventoryRef)
	{
		//IL_0062: Expected O, but got Ref
		procChancePerAmount = 0.2f;
		damageRatio = 1f;
		damageRatioPerAmount = 0.4f;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
		Dictionary<GameObject, Rocket> dictionary = (Dictionary<GameObject, Rocket>)(object)new Dictionary<object, object>(200);
		((Dictionary<object, object>)(object)dictionary)._002Ector(200);
		rocketLookup = dictionary;
		maxProcsPerTick = 4;
		base._002Ector(itemInventoryRef);
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
