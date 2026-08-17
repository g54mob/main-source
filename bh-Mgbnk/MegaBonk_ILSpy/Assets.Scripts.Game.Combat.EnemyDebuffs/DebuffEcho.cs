using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs;

public class DebuffEcho : EnemyDebuff
{
	public override int GetStacks()
	{
		return 0;
	}

	public override void MyTick()
	{
	}

	public override EDebuff GetDebuffType()
	{
		return EDebuff.Echo;
	}

	public unsafe override void OnRemove(bool fromDeath)
	{
		//IL_012b: Invalid comparison between I4 and F4
		//IL_001d: Expected O, but got Ref
		//IL_002f: Expected O, but got I
		//IL_0067: Expected O, but got I4
		Enemy enemy = base.enemy;
		if (0f < enemy.echoDamage)
		{
			object obj = default(object);
			string damageSource = ((Enum)(&obj)).ToString();
			IntPtr intPtr = default(IntPtr);
			DamageContainer damageContainer = new DamageContainer(0f, (string)(nint)intPtr);
			damageContainer.damageSource = damageSource;
			damageContainer.procCoefficient = 0f;
			damageContainer.direction = (Vector3)0;
			_ = 0;
			damageContainer.crit = false;
			damageContainer.knockback = 0f;
			damageContainer.enemy = null;
			damageContainer.damageEffect = EDamageEffect.None;
			damageContainer.damageBlockedByArmor = 0;
			damageContainer.isExecute = false;
			damageContainer.canProcJoe = false;
			damageContainer.damage = enemy.echoDamage;
			damageContainer.damageEffect = EDamageEffect.Echo;
			damageContainer.enemy = enemy;
			enemy.DamageFromPlayerWeapon(damageContainer);
			enemy.echoDamage = 0f;
		}
	}

	protected override void OnResetState()
	{
	}

	public override void OnAdded()
	{
	}

	public override void OnRefresh()
	{
	}

	public override void AddStacks(int numStacks)
	{
	}
}
