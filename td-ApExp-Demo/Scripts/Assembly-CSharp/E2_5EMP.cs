using UnityEngine;

public class E2_5EMP : BEMPState
{
	private E2_5Sacrificer sacrificer;

	public override string Key => "EMP";

	public E2_5EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Entering", "Idle" };
	}

	public E2_5EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		Debug.LogWarning("EMP");
		sacrificer = enemy as E2_5Sacrificer;
		if (!sacrificer.CompletedSacrifice)
		{
			sacrificer.InterruptSacrifice();
		}
		base.EnterState();
	}

	public override bool CanExit()
	{
		if (base.CanExit())
		{
			if (sacrificer.CompletedSacrifice)
			{
				transitionStates = new string[1] { "Idle" };
			}
			else
			{
				transitionStates = new string[1] { "Entering" };
			}
			return true;
		}
		return false;
	}
}
