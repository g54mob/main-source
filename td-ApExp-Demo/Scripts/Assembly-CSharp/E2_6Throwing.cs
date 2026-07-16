public class E2_6Throwing : StateBaseEnemy
{
	private E2_6MolotovBiker biker;

	private bool exitConditionMet;

	public override string Key => "Throwing";

	public E2_6Throwing(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_6Throwing(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		biker.ResetMolotovThrown();
		biker.Shoot();
	}

	public override void UpdateState()
	{
		if (biker.MolotovThrowComplete)
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
