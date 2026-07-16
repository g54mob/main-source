using UnityEngine;

public class E4_B_Armored : StateBaseEnemy
{
	private E4_B_Warlord enemyWarlord;

	private float timer;

	public override string Key => "Armored";

	public E4_B_Armored(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Vulnerable" };
	}

	public E4_B_Armored(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		ApplyArmorToEnemies();
		timer = enemyWarlord.ArmorApplicationInterval;
	}

	public override void UpdateState()
	{
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			ApplyArmorToEnemies();
			timer = enemyWarlord.ArmorApplicationInterval;
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

	private void ApplyArmorToEnemies()
	{
		enemyWarlord.ArmoredPs.Play();
		foreach (EnemyBase enemy in EnemyManager.Instance.Enemies)
		{
			if (!enemy.IsBoss)
			{
				enemy.HealthComponent.ApplyArmor();
			}
		}
	}
}
