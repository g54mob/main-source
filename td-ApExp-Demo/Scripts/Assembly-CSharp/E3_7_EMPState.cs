public class E3_7_EMPState : BEMPState
{
	private E3_7_Scrambler scrambler;

	public override string Key => "EMP";

	public E3_7_EMPState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		scrambler = enemy as E3_7_Scrambler;
		transitionStates = new string[2] { "Idle", "Move" };
	}

	public E3_7_EMPState(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		scrambler = enemy as E3_7_Scrambler;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		base.EnterState();
		scrambler.Unscramble();
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override bool CanExit()
	{
		return base.CanExit();
	}
}
