public class E2_3SquadEMP : BEMPState
{
	public override string Key => "EMP";

	public E2_3SquadEMP(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_3SquadEMP(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void EnterState()
	{
		base.EnterState();
	}
}
