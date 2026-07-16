using UnityEngine;

public class E2_1Idle : StateBaseEnemy
{
	private E2_1EMPLauncher empLauncher;

	public override string Key => "Idle";

	public E2_1Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Shoot" };
	}

	public E2_1Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		empLauncher = enemy as E2_1EMPLauncher;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		empLauncher.LoadEmp();
		empLauncher.SetIdleTimer();
	}

	public override void UpdateState()
	{
		empLauncher.idleTimer -= Time.deltaTime;
		if (empLauncher.TargetUnit == null)
		{
			empLauncher.Target();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return empLauncher.idleTimer <= 0f;
	}
}
