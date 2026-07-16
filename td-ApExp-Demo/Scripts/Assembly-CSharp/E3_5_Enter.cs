using UnityEngine;

public class E3_5_Enter : StateBaseEnemy
{
	private E3_5_StealthBomber stealthBomber;

	public override string Key => "Enter";

	public E3_5_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_5_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		stealthBomber = enemy as E3_5_StealthBomber;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Enter");
		stealthBomber.SetNewTargetPos();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		stealthBomber.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return stealthBomber.IsInPosition;
	}
}
