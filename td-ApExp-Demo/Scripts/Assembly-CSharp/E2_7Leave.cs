using UnityEngine;

public class E2_7Leave : StateBaseEnemy
{
	private E2_7Chainer chainer;

	private float stayDuration;

	public override string Key => "Leave";

	public E2_7Leave(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E2_7Leave(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void UpdateState()
	{
		if (chainer.transform.position.x <= -5f)
		{
			if (chainer.TargetUnitTf != null && chainer.TargetUnitTf.gameObject.GetComponent<EnemyBase>() != null)
			{
				chainer.TargetUnitTf.gameObject.GetComponent<EnemyBase>().KillSelf();
			}
			chainer.KillSelf();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		if (chainer.enemyChained)
		{
			stayDuration -= Time.deltaTime;
			if (stayDuration <= 0f)
			{
				chainer.MoveAway();
				chainer.Aim();
			}
		}
		else
		{
			chainer.MoveAway();
			chainer.Aim();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
