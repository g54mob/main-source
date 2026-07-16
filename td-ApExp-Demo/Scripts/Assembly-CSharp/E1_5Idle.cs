using UnityEngine;

public class E1_5Idle : StateBaseEnemy
{
	private E1_5APC apc;

	public override string Key => "Idle";

	public E1_5Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Launch" };
	}

	public E1_5Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		apc = enemy as E1_5APC;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("Idle", 1, 0f);
		apc.SetIdleTimer();
	}

	public override void UpdateState()
	{
		apc.Aim();
		apc.idleTimer -= Time.deltaTime;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (apc.IsInPosition)
		{
			return apc.idleTimer <= 0f;
		}
		return false;
	}
}
