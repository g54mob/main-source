public class E2_B_ChainAttack : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "ChainAttack";

	public E2_B_ChainAttack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Exit" };
	}

	public E2_B_ChainAttack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		boss.TargetChainAttack();
		boss.ResetChainAttackTimer();
		boss.ChargeChainAttack();
		boss.AimChainAttack();
	}

	public override void UpdateState()
	{
		if (boss.TickChainAttack() && boss.dualBossController.BothBossesChainAttackReady)
		{
			canExit = true;
			boss.ChainAttack();
			boss.dualBossController.sm.ForceState("Idle");
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
