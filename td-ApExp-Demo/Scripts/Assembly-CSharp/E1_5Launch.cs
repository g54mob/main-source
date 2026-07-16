using UnityEngine;

public class E1_5Launch : StateBaseEnemy
{
	private E1_5APC apc;

	private float stateStartTime;

	public override string Key => "Launch";

	public E1_5Launch(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
		apc = enemy as E1_5APC;
	}

	public E1_5Launch(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		apc = enemy as E1_5APC;
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
