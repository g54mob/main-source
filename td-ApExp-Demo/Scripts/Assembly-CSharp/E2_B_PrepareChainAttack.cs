public class E2_B_PrepareChainAttack : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "PrepareChainAttack";

	public E2_B_PrepareChainAttack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "ChainAttack", "Exit" };
	}

	public E2_B_PrepareChainAttack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		boss.SetTargetLocation(ScreenPositions.Center);
		boss.movingToChainAttackPos = true;
	}

	public override void UpdateState()
	{
		if (boss.dualBossController.BothBossesInPosition)
		{
			canExit = true;
			sm.SwitchState("ChainAttack");
		}
	}

	public override void ExitState()
	{
		boss.movingToChainAttackPos = false;
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
