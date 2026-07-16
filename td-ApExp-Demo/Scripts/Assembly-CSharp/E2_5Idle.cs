using UnityEngine;

public class E2_5Idle : StateBaseEnemy
{
	private E2_5Sacrificer enemySacrificer;

	public override string Key => "Idle";

	public E2_5Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E2_5Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySacrificer = enemy as E2_5Sacrificer;
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
		if (!(enemySacrificer.TargetUnit == null))
		{
			enemySacrificer.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		if (!(enemySacrificer.TargetUnit == null))
		{
			enemySacrificer.Aim();
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
