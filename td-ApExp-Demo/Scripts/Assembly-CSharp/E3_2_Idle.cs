using UnityEngine;

public class E3_2_Idle : StateBaseEnemy
{
	private E3_2_Falcon falcon;

	public override string Key => "Idle";

	public E3_2_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "CrossOver" };
	}

	public E3_2_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		falcon = enemy as E3_2_Falcon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		falcon.SetIdleTimer();
		falcon.SetStartingPos();
	}

	public override void UpdateState()
	{
		falcon.idleTimer -= Time.deltaTime;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return falcon.idleTimer <= 0f;
	}
}
