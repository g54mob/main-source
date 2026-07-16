using UnityEngine;

public class E2_4Enter : StateBaseEnemy
{
	private E2_4Spawner enemySpawner;

	public override string Key => "Enter";

	public E2_4Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_4Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void UpdateState()
	{
		if ((enemySpawner.enterTimer -= Time.deltaTime) <= 0f)
		{
			sm.ForceState("Idle");
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
		return enemySpawner.enterTimer <= 0f;
	}
}
