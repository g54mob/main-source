using UnityEngine;

public class E2_7Attach : StateBaseEnemy
{
	private E2_7Chainer chainer;

	public override string Key => "Attach";

	public E2_7Attach(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Leave" };
	}

	public E2_7Attach(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		Debug.LogWarning("Attach");
		chainer.AttachToTrain();
		if (!chainer.IsHacked)
		{
			if (!chainer.slowApplied)
			{
				chainer.IsAttached = true;
				chainer.slowApplied = true;
				Train.Instance.AddSlowDebuff(chainer.slowPercent);
			}
		}
		else
		{
			sm.ForceState("Leave");
		}
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		chainer.MoveBack();
		chainer.Aim();
	}

	public override void ExitState()
	{
		if (chainer.slowApplied)
		{
			chainer.slowApplied = false;
			Train.Instance.AddSlowDebuff(0f - chainer.slowPercent);
		}
	}

	public override bool CanExit()
	{
		return false;
	}
}
