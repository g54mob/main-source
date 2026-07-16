using UnityEngine;

public class E3_4_Idle : StateBaseEnemy
{
	private E3_4_EjectorBomber ejector;

	public override string Key => "Idle";

	public E3_4_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_4_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		ejector = enemy as E3_4_EjectorBomber;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		ejector.lockHover = false;
		ejector.SetIdleTimer();
		ejector.Target();
	}

	public override void UpdateState()
	{
		ejector.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		ejector.ResetRotation();
		ejector.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (ejector.idleTimer < 0f)
		{
			return ejector.IsInPosition;
		}
		return false;
	}
}
