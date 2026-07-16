using UnityEngine;

public class E2_5Sacrifice : StateBaseEnemy
{
	private E2_5Sacrificer sacrificer;

	private bool canExit;

	public override string Key => "Sacrifice";

	public E2_5Sacrifice(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_5Sacrifice(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		sacrificer = enemy as E2_5Sacrificer;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Sacrifice");
		canExit = false;
		if (sacrificer.CompletedSacrifice)
		{
			canExit = true;
			ExitState();
		}
		sacrificer.Sacrifice();
		sacrificer.StartTransition();
		sacrificer.ResetTransitionTimer();
	}

	public override void UpdateState()
	{
		if (sacrificer.TransitionTimerTick())
		{
			canExit = true;
			ExitState();
		}
	}

	public override void ExitState()
	{
		sacrificer.DoTransition();
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
