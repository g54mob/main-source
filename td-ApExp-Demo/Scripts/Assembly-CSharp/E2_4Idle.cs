using UnityEngine;

public class E2_4Idle : StateBaseEnemy
{
	private E2_4Spawner enemySpawner;

	public override string Key => "Idle";

	public E2_4Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Spawn" };
	}

	public E2_4Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySpawner = enemy as E2_4Spawner;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemySpawner.SetIdleTimer();
	}

	public override void UpdateState()
	{
		if ((enemySpawner.idleTimer -= Time.deltaTime) <= 0f)
		{
			ExitState();
		}
		if (enemySpawner.TargetUnit == null)
		{
			enemySpawner.Target();
		}
		_ = enemySpawner.TargetUnit == null;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemySpawner.idleTimer <= 0f;
	}
}
