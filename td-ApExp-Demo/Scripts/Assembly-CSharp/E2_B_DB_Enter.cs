public class E2_B_DB_Enter : StateBaseEnemy
{
	private E2_B_DualBossController dualBoss;

	private bool canExit;

	public override string Key => "Enter";

	public E2_B_DB_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_DB_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		dualBoss = enemy as E2_B_DualBossController;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		canExit = false;
	}

	public override void UpdateState()
	{
		if (dualBoss.BossesInScreen)
		{
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return dualBoss.BossesInScreen;
	}
}
