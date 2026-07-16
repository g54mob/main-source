using UnityEngine;

public class E3_7_Enter : StateBaseEnemy
{
	private E3_7_Scrambler scrambler;

	public override string Key => "Enter";

	public E3_7_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_7_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		scrambler = enemy as E3_7_Scrambler;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Enter");
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		scrambler.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return scrambler.IsInPosition;
	}
}
