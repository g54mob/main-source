using UnityEngine;

public class E2_5Entering : StateBaseEnemy
{
	private E2_5Sacrificer enemySacrificer;

	private bool canExit;

	public override string Key => "Entering";

	public E2_5Entering(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Charging" };
	}

	public E2_5Entering(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySacrificer = enemy as E2_5Sacrificer;
		canExit = false;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Enter");
		enemySacrificer.ResetEnterTimer();
	}

	public override void UpdateState()
	{
		if (enemySacrificer.EnterTimerTick())
		{
			canExit = true;
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
