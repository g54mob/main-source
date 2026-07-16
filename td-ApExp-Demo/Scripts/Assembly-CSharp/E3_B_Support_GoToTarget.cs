using UnityEngine;

public class E3_B_Support_GoToTarget : StateBaseEnemy
{
	private E3_B_Phase1Plane_Support bossPlane;

	public override string Key => "GoToTarget";

	public E3_B_Support_GoToTarget(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Heal", "Idle" };
	}

	public E3_B_Support_GoToTarget(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bossPlane = enemy as E3_B_Phase1Plane_Support;
	}

	public override bool CanEnter()
	{
		return false;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Entering GoToTarget State");
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
