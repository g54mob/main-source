public class E2_B_DB_Idle : StateBaseEnemy
{
	private E2_B_DualBossController dualBoss;

	private bool canExit;

	public override string Key => "Idle";

	public E2_B_DB_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[4] { "ChainAttack", "BasicAttack", "Exit", "Reviving" };
	}

	public E2_B_DB_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		dualBoss.ResetChainAttackTimer();
		dualBoss.ChainsBroke = false;
		dualBoss.ChainAttackComplete = false;
		dualBoss.bossB.laserChargePs.Stop();
	}

	public override void UpdateState()
	{
		if (dualBoss.TickChainAttack() && dualBoss.BossesReadyForChainAttack())
		{
			canExit = true;
			sm.SwitchState("ChainAttack");
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
