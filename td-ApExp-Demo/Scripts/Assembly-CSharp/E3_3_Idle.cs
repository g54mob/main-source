using UnityEngine;

public class E3_3_Idle : StateBaseEnemy
{
	private E3_3_Helicopter helicopter;

	public override string Key => "Idle";

	public E3_3_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Target" };
	}

	public E3_3_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		helicopter = enemy as E3_3_Helicopter;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		helicopter.SetRandomTargetPos();
		helicopter.TargetUnit = null;
		helicopter.SetIdleTimer();
	}

	public override void UpdateState()
	{
		if (helicopter.IsInPosition)
		{
			helicopter.SetRandomTargetPos();
		}
		helicopter.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		helicopter.Move();
		helicopter.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return helicopter.idleTimer < 0f;
	}
}
