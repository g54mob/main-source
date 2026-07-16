using UnityEngine;

public class E2_2Sucking : StateBaseEnemy
{
	private E2_2CoalVacuum enemyCoalVacuum;

	public override string Key => "Sucking";

	public E2_2Sucking(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Retracting" };
	}

	public E2_2Sucking(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyCoalVacuum = enemy as E2_2CoalVacuum;
	}

	public override bool CanEnter()
	{
		return enemyCoalVacuum.IsInPosition;
	}

	public override void EnterState()
	{
		Debug.LogWarning($"{enemy}: {sm.CurrentState}");
		enemyCoalVacuum.isSuckingHoseAttached = true;
		enemyCoalVacuum.Hose.StartSuckAnim();
		enemyCoalVacuum.Hose.PlaySuckingSound();
	}

	public override void UpdateState()
	{
		enemyCoalVacuum.shotTimer -= Time.deltaTime;
		enemyCoalVacuum.Shoot();
	}

	public override void ExitState()
	{
		enemyCoalVacuum.Hose.StopSuckingAnim();
		enemyCoalVacuum.Hose.StopAudio();
		enemyCoalVacuum.Hose.Retract();
		Train.Instance.RemoveDrainer(enemyCoalVacuum);
	}

	public override bool CanExit()
	{
		return enemyCoalVacuum.LeftRange();
	}
}
