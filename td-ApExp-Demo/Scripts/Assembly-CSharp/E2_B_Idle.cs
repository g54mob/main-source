public class E2_B_Idle : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "Idle";

	public E2_B_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[4] { "PrepareChainAttack", "SpecialAtack", "Exit", "Reviving" };
	}

	public E2_B_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		boss.ResetBasicAttack1Timer();
		boss.ResetBasicAttack2Timer();
		boss.ResetSpecialAttackTimer();
		boss.Target();
	}

	public override void UpdateState()
	{
		boss.Aim();
		if (boss.TickSwitchPosition())
		{
			boss.TryChangePosition();
			boss.ResetSwitchPositionTimer();
		}
		if (boss.TickBacicAttack1())
		{
			boss.ResetBasicAttack1Timer();
			boss.BasicAttack1();
		}
		if (boss.TickBasicAttack2())
		{
			boss.ResetBasicAttack2Timer();
			boss.BasicAttack2();
		}
		if (boss.TickSpecialAttack())
		{
			boss.ResetSpecialAttackTimer();
			canExit = true;
			sm.SwitchState("SpecialAttack");
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (canExit)
		{
			return !boss.StateSwitchBlocked;
		}
		return false;
	}
}
