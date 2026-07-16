using UnityEngine;

public class E3_5_Idle : StateBaseEnemy
{
	private E3_5_StealthBomber stealthBomber;

	public override string Key => "Idle";

	public E3_5_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_5_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		stealthBomber = enemy as E3_5_StealthBomber;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Idle");
		stealthBomber.SetNewTargetPos();
		stealthBomber.SetIdleTimer();
	}

	public override void UpdateState()
	{
		if (stealthBomber.IsInPosition)
		{
			stealthBomber.idleTimer -= Time.deltaTime;
		}
	}

	public override void FixedUpdateState()
	{
		stealthBomber.Move();
		stealthBomber.Rotator.RotateToAngle(stealthBomber.transform, 0f);
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (stealthBomber.IsInPosition)
		{
			return stealthBomber.idleTimer <= 0f;
		}
		return false;
	}
}
