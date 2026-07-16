public class E2_6Idle : StateBaseEnemy
{
	private E2_6MolotovBiker biker;

	private bool exitConditionMet;

	public override string Key => "Idle";

	public E2_6Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Throwing" };
	}

	public E2_6Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		biker = enemy as E2_6MolotovBiker;
		exitConditionMet = false;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		exitConditionMet = false;
		biker.SetIdleTimer();
	}

	public override void UpdateState()
	{
		if (biker.IdleTimerTick())
		{
			exitConditionMet = true;
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return exitConditionMet;
	}
}
