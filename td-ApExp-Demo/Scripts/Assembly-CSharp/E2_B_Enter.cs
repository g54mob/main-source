public class E2_B_Enter : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "Enter";

	public E2_B_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		boss.StateSwitchBlocked = true;
		boss.dualBossController.sm.ForceState("Enter");
		boss.Enter();
	}

	public override void UpdateState()
	{
		if (boss.IsInPosition)
		{
			boss.StateSwitchBlocked = false;
			ExitState();
		}
	}

	public override void ExitState()
	{
		boss.dualBossController.BossesInScreen = true;
	}

	public override bool CanExit()
	{
		return !boss.StateSwitchBlocked;
	}
}
