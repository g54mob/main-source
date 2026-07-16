public class E2_3EMP : BEMPState
{
	public override string Key => "EMP";

	public E2_3EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_3EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		enemy.Anim.Play("EMP", 1);
		if (enemy is E2_3Medic e2_3Medic)
		{
			e2_3Medic.StopChargingAnim();
		}
		base.EnterState();
	}

	public override void ExitState()
	{
		base.ExitState();
	}
}
