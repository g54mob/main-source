public class E3_5_EMPState : BEMPState
{
	private E3_5_StealthBomber stealth;

	public override string Key => "EMP";

	public E3_5_EMPState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		stealth = enemy as E3_5_StealthBomber;
		transitionStates = new string[2] { "Idle", "Move" };
	}

	public E3_5_EMPState(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		stealth = enemy as E3_5_StealthBomber;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		base.EnterState();
		stealth.Unstealth();
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
		base.ExitState();
		stealth.Stealth();
	}

	public override bool CanExit()
	{
		return base.CanExit();
	}
}
