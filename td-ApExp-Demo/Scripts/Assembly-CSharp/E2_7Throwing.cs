using UnityEngine;

public class E2_7Throwing : StateBaseEnemy
{
	private E2_7Chainer chainer;

	private bool canExit;

	public override string Key => "Throwing";

	public E2_7Throwing(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attach" };
	}

	public E2_7Throwing(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		if (chainer.IsThrowing)
		{
			ExitState();
		}
		Debug.LogWarning("Throwing");
		canExit = false;
		chainer.Shoot();
	}

	public override void UpdateState()
	{
		if (chainer.IsThrowing)
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
