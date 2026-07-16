using UnityEngine;

public class E2_2Retracting : StateBaseEnemy
{
	private E2_2CoalVacuum enemyCoalVacuum;

	private float retractTimer;

	public override string Key => "Retracting";

	public E2_2Retracting(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Expanding" };
	}

	public E2_2Retracting(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		enemyCoalVacuum.Hose.PlayExpandingSound();
		retractTimer = 1f;
		enemyCoalVacuum.Hose.IsLocked = false;
		enemyCoalVacuum.Hose.ExtensionState = ExtensionState.Retracting;
	}

	public override void UpdateState()
	{
		retractTimer -= Time.deltaTime * enemyCoalVacuum.Hose.expansionSpeed;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyCoalVacuum.Hose.SetExpansion(Mathf.Max(retractTimer, 0f));
	}

	public override void ExitState()
	{
		enemyCoalVacuum.Hose.StopAudio();
		enemyCoalVacuum.EnableInertia();
	}

	public override bool CanExit()
	{
		return enemyCoalVacuum.Hose.Retracted;
	}
}
