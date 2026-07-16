using UnityEngine;

public class E2_9EMP : BEMPState
{
	private E2_9RatBiker biker;

	public override string Key => "EMP";

	public E2_9EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_9EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		Debug.LogWarning("EMP");
		base.EnterState();
	}
}
