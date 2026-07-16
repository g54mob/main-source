using System;
using UnityEngine;

public class E2_2Expanding : StateBaseEnemy
{
	private E2_2CoalVacuum enemyCoalVacuum;

	private float extensionTimer;

	public override string Key => "Expanding";

	public E2_2Expanding(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Sucking", "Retracting" };
	}

	public E2_2Expanding(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyCoalVacuum = enemy as E2_2CoalVacuum;
	}

	public override bool CanEnter()
	{
		if (enemyCoalVacuum.IsInPosition)
		{
			return enemyCoalVacuum.TargetUnit != null;
		}
		return false;
	}

	public override void EnterState()
	{
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		enemyCoalVacuum.Hose.PlayExpandingSound();
		enemyCoalVacuum.Hose.Retracted = false;
		extensionTimer = 0f;
		enemyCoalVacuum.Hose.IsLocked = false;
		enemyCoalVacuum.Hose.ExtensionState = ExtensionState.Expanding;
	}

	public override void UpdateState()
	{
		extensionTimer += Time.deltaTime * enemyCoalVacuum.Hose.expansionSpeed;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyCoalVacuum.Hose.SetExpansion(MathF.Min(extensionTimer, 1f));
	}

	public override void ExitState()
	{
		enemyCoalVacuum.Hose.StopAudio();
	}

	public override bool CanExit()
	{
		return enemyCoalVacuum.Hose.IsAttached;
	}
}
