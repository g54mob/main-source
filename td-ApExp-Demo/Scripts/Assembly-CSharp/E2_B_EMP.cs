public class E2_B_EMP : BEMPState
{
	private E2_B_BossController boss;

	public override string Key => "EMP";

	public E2_B_EMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_EMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		boss = enemy as E2_B_BossController;
	}

	public override void EnterState()
	{
		base.EnterState();
	}

	public override void ExitState()
	{
		base.ExitState();
		transitionStates = new string[1] { sm.PreviousState.ToString() };
	}
}
