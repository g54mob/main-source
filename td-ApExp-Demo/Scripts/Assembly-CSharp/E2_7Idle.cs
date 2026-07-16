using UnityEngine;

public class E2_7Idle : StateBaseEnemy
{
	private E2_7Chainer chainer;

	private bool canExit;

	public override string Key => "Idle";

	public E2_7Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Throwing" };
	}

	public E2_7Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		chainer = enemy as E2_7Chainer;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Idle");
		canExit = false;
	}

	public override void UpdateState()
	{
		if (chainer.IsInRange())
		{
			canExit = true;
			ExitState();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		chainer.Move();
		chainer.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
