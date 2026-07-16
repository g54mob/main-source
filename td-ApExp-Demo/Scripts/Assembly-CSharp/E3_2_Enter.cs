public class E3_2_Enter : StateBaseEnemy
{
	private E3_2_Falcon falcon;

	public override string Key => "Enter";

	public E3_2_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_2_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		falcon = enemy as E3_2_Falcon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		falcon.SetStartingPos();
		falcon.IsInPosition = false;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return falcon.IsInPosition;
	}
}
