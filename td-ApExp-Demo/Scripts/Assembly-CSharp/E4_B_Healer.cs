using System.Linq;
using UnityEngine;

public class E4_B_Healer : StateBaseEnemy
{
	private E4_B_Warlord enemyWarlord;

	private float timer;

	public override string Key => "Healer";

	public E4_B_Healer(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Vulnerable" };
	}

	public E4_B_Healer(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyWarlord = enemy as E4_B_Warlord;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		HealLowestEnemy();
		timer = enemyWarlord.HealerInterval;
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			HealLowestEnemy();
			timer = enemyWarlord.HealerInterval;
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyWarlord.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemyWarlord.IsWaveDead;
	}

	private void HealLowestEnemy()
	{
		float num = 0f;
		EnemyBase enemyBase = null;
		enemyWarlord.HealerPs.Play();
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if (!enemy.IsBoss && !enemy.IsEnemyGadget && enemy.HealthComponent.HealthMissing > num)
			{
				num = enemy.HealthComponent.HealthMissing;
				enemyBase = enemy;
			}
		}
		if (enemyBase == null)
		{
			enemyBase = EnemyManager.Instance.Enemies.Where((EnemyBase e) => e.IsEnemy && !e.IsEnemyGadget && !e.IsBoss).FirstOrDefault();
		}
		if (enemyBase != null)
		{
			enemyBase.HealthComponent.Heal(enemyWarlord.HealerHealPercent, enemyWarlord, isPercent: true);
		}
	}
}
