using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;

public class DebuffPoison : EnemyDebuff
{
	public static int numPoisonedEnemies;

	private int stacks;

	public static string poisonDamageSource;

	public float GetDamageForHpBar()
	{
		//IL_0062: Invalid comparison between I4 and F4
		//IL_0074: Expected F4, but got I4
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,edi\"");
		float stat2 = PlayerStats.GetStat(EStat.PoisonDamageMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,edi\"");
		float num = 0f * stat;
		float num2 = stat2 * num;
		bool flag = !(0f < num2);
		float num3 = 0f;
		if (!flag)
		{
			num3 = num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+10h]\"");
		return 0f * num3;
	}

	public override void MyTick()
	{
		//IL_0013: Expected O, but got I4
		//IL_00c2: Invalid comparison between I4 and F4
		//IL_00d5: Expected F4, but got I4
		string damageSource = default(string);
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		damageContainer.damageSource = poisonDamageSource;
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
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		float stat2 = PlayerStats.GetStat(EStat.PoisonDamageMultiplier);
		float num = (float)stacks * stat;
		float num2 = stat2 * num;
		bool flag = !((float)stacks < num2);
		float damage = stacks;
		if (!flag)
		{
			damage = num2;
		}
		damageContainer.damage = damage;
		damageContainer.enemy = enemy;
		damageContainer.damageEffect = EDamageEffect.Poison;
		enemy.DamageFromPlayerOther(damageContainer);
	}

	public static float GetPoisonDamagePerTick(int stacks)
	{
		float stat = PlayerStats.GetStat(EStat.DamageMultiplier);
		float stat2 = PlayerStats.GetStat(EStat.PoisonDamageMultiplier);
		float num = (float)stacks * stat;
		return stat2 * num;
	}

	public override EDebuff GetDebuffType()
	{
		return EDebuff.Poison;
	}

	public override void OnRemove(bool fromDeath)
	{
		int num = numPoisonedEnemies - 1;
		numPoisonedEnemies = num;
	}

	public override void OnAdded()
	{
		int num = numPoisonedEnemies + 1;
		numPoisonedEnemies = num;
	}

	protected override void OnResetState()
	{
		stacks = 0;
	}

	public override void OnRefresh()
	{
	}

	public override void AddStacks(int numStacks)
	{
		int num = stacks + numStacks;
		stacks = num;
	}

	public override int GetStacks()
	{
		return stacks;
	}

	public DebuffPoison()
	{
		OnRefresh();
	}

	unsafe static DebuffPoison()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		poisonDamageSource = text;
	}
}
