using UnityEngine;

public class E2_2Idle : StateBaseEnemy
{
	private E2_2CoalVacuum enemyCoalVacuum;

	public override string Key => "Idle";

	public E2_2Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Expanding" };
	}

	public E2_2Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyCoalVacuum = enemy as E2_2CoalVacuum;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		enemyCoalVacuum.SetIdleTimer();
		enemyCoalVacuum.Hose.IsLocked = true;
		enemyCoalVacuum.Hose.ExtensionState = ExtensionState.None;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		enemyCoalVacuum.DisableInertia();
	}

	public override bool CanExit()
	{
		return enemyCoalVacuum.IsInPosition;
	}
}
