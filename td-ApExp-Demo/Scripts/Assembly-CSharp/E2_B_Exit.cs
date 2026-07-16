public class E2_B_Exit : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	private float preExitMS;

	public override string Key => "Exit";

	public E2_B_Exit(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Enter" };
	}

	public E2_B_Exit(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		boss = enemy as E2_B_BossController;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		canExit = false;
		boss.CancelChainAttack();
		boss.ResetChainAttackTimer();
		boss.StateSwitchBlocked = true;
		boss.ResetExitTimer();
	}

	public override void UpdateState()
	{
		if (boss.TickExit())
		{
			canExit = true;
			boss.dualBossController.ChainAttackComplete = true;
			boss.dualBossController.ChainsBroke = true;
			boss.StateSwitchBlocked = false;
			sm.SwitchState("Idle");
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
