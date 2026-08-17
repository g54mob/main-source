using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemDragonfire : ItemBase
{
	public float procChancePerAmount;

	private float procChance;

	private float burnChancePerAmount;

	private float burnChance;

	private string damageSource;

	protected override void OnInitOrAmountChanged()
	{
		float input = (float)amount * procChancePerAmount;
		float num = StatScaling.HyperbolicScaling(input);
		procChance = num;
		float input2 = (float)amount * burnChancePerAmount;
		float num2 = StatScaling.HyperbolicScaling(input2);
		burnChance = num2;
	}

	public unsafe override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0121: Expected O, but got Ref
		//IL_0138: Expected O, but got Ref
		//IL_022a: Expected O, but got Ref
		//IL_026f: Expected F4, but got I4
		//IL_026f: Expected O, but got Ref
		//IL_026f: Expected O, but got Ref
		int num = default(int);
		if (dc.element == EElement.Fire && ItemUtility.TryProc(dc.procCoefficient, burnChance))
		{
			dc.enemy.AddDebuff(EDebuff.Burn, dc, 3f, num);
		}
		if (!ItemUtility.TryProc(dc.procCoefficient, procChance))
		{
			return;
		}
		PoolManager instance = PoolManager.Instance;
		GameObject gameObject = instance.firefieldPool.Get();
		if (!(gameObject != null))
		{
			return;
		}
		Transform transform = gameObject.transform;
		Vector3 centerPosition = dc.enemy.GetCenterPosition();
		float num2 = default(float);
		Vector3 vector = RaycastUtility.RayToGround((Vector3)(&num2));
		transform.position = (Vector3)(&num2);
		float stat = PlayerStats.GetStat(EStat.SizeMultiplier);
		float num3 = stat * 6f;
		float stat2 = PlayerStats.GetStat(EStat.DurationMultiplier);
		float num4 = stat2 + stat2;
		float radius;
		if (!(1f > num3))
		{
			bool flag = num3 > 12f;
			radius = 12f;
			if (!flag)
			{
				radius = num3;
			}
		}
		else
		{
			radius = 1f;
		}
		if (1f > num4 || !(num4 > 3f))
		{
		}
		Firefield component = gameObject.GetComponent<Firefield>();
		Vector3 centerPosition2 = dc.enemy.GetCenterPosition();
		Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
		Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&num2));
		Vector3 feetPosition = dc.enemy.GetFeetPosition();
		object obj = default(object);
		float damage = default(float);
		WeaponBase weaponBase = default(WeaponBase);
		string text = default(string);
		component.Set((Vector3)(&num2), (Vector3)(&obj), radius, num, damage, weaponBase, text);
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	private void TryProcBurn(DamageContainer dc, float overrideProcCoefficient = -1f)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001804550CEh\"");
		float num = default(float);
		if (num == -1f || ItemUtility.TryProc(dc.procCoefficient, burnChance))
		{
			int stacks = default(int);
			dc.enemy.AddDebuff(EDebuff.Burn, dc, 3f, stacks);
		}
	}

	public unsafe ItemDragonfire(ItemInventory itemInventoryRef)
	{
		//IL_0025: Expected O, but got Ref
		procChancePerAmount = 0.15f;
		burnChancePerAmount = 0.15f;
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
		base._002Ector(itemInventoryRef);
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
