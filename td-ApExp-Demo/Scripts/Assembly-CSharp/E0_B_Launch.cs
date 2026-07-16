using UnityEngine;

public class E0_B_Launch : StateBaseEnemy
{
	private E0_B_APC apc;

	private float stateStartTime;

	public override string Key => "Launch";

	public E0_B_Launch(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
		apc = enemy as E0_B_APC;
	}

	public E0_B_Launch(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		apc = enemy as E0_B_APC;
	}

	public override bool CanEnter()
	{
		return enemy.TargetUnit != null;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("Launching", 1, 0f);
		stateStartTime = Time.time;
	}

	public override void UpdateState()
	{
	}

	public override bool CanExit()
	{
		return Time.time - stateStartTime >= enemy.Anim.GetCurrentAnimatorStateInfo(1).length;
	}

	public override void ExitState()
	{
	}
}
