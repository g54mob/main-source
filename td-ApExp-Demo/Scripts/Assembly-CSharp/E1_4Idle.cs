using UnityEngine;

public class E1_4Idle : StateBaseEnemy
{
	private E1_4Bus bus;

	public override string Key => "Idle";

	public E1_4Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "OpenFireClose" };
	}

	public E1_4Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bus = enemy as E1_4Bus;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		bus.SetIdleAnim();
		bus.SetIdleTimer();
		bus.HealthComponent.IsImmune = true;
	}

	public override void UpdateState()
	{
		bus.idleTimer -= Time.deltaTime;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return bus.idleTimer <= 0f;
	}
}
