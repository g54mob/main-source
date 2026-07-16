public class E2_B_Reviving : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "Reviving";

	public E2_B_Reviving(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_Reviving(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		boss.StartReviveChargeUp();
	}

	public override void UpdateState()
	{
		if (!boss.GetOtherBossController().HealthComponent.IsDead)
		{
			boss.StateSwitchBlocked = false;
			boss.dualBossController.HealingComplete = true;
			boss.reviveAnim.SetTrigger("Revive");
			ExitState();
		}
		if (boss.TickReviveChargeUp())
		{
			boss.ReviveOtherBoss();
			boss.StateSwitchBlocked = false;
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return !boss.StateSwitchBlocked;
	}
}
