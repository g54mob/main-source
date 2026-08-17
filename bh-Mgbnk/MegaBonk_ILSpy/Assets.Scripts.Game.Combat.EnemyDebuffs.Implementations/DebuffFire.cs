using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffFire : EnemyDebuff
{
	private static string damageSource;

	private DamageContainer dc;

	private bool canDamage;

	public override int GetStacks()
	{
		return 0;
	}

	public override void MyTick()
	{
		bool flag = !canDamage;
		canDamage = flag;
		if (!canDamage)
		{
			dc.Reuse(0f, damageSource);
			DamageContainer damageContainer = dc;
			MyPlayer instance = MyPlayer.Instance;
			float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
			float num = instance.baseDamage * 0.85f;
			float damage = stat * num;
			damageContainer.damage = damage;
			DamageContainer damageContainer2 = dc;
			damageContainer2.enemy = enemy;
			DamageContainer damageContainer3 = dc;
			damageContainer3.damageEffect = EDamageEffect.Fire;
			DamageContainer damageContainer4 = dc;
			damageContainer4.element = EElement.Fire;
			enemy.DamageFromPlayerOther(dc);
		}
	}

	private float GetDamage()
	{
		MyPlayer instance = MyPlayer.Instance;
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		float num = instance.baseDamage * 0.85f;
		return stat * num;
	}

	protected override void OnResetState()
	{
		canDamage = false;
	}

	public override EDebuff GetDebuffType()
	{
		return EDebuff.Burn;
	}

	public override void OnRemove(bool fromDeath)
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

	public DebuffFire()
	{
		//IL_0013: Expected O, but got I4
		string text = default(string);
		DamageContainer damageContainer = new DamageContainer(0f, text)
		{
			damageSource = damageSource,
			procCoefficient = 0f,
			direction = (Vector3)0
		};
		_ = 0;
		damageContainer.crit = false;
		damageContainer.knockback = 0f;
		damageContainer.enemy = null;
		damageContainer.damageEffect = EDamageEffect.None;
		damageContainer.damageBlockedByArmor = 0;
		damageContainer.isExecute = false;
		damageContainer.canProcJoe = false;
		dc = damageContainer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}

	unsafe static DebuffFire()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
