public class E2_B_DB_EMP : BEMPState
{
	private E2_B_DualBossController dualBoss;

	public override string Key => "EMP";

	public E2_B_DB_EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_DB_EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		base.EnterState();
	}
}
