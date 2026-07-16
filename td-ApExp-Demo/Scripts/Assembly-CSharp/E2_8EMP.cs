using UnityEngine;

public class E2_8EMP : BEMPState
{
	private E2_8MedDart medDart;

	public override string Key => "EMP";

	public E2_8EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_8EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		Debug.LogWarning("EMP");
		base.EnterState();
	}
}
