public class E2_B_DB_Dead : StateBaseEnemy
{
	private E2_B_DualBossController dualBoss;

	private bool canExit;

	public override string Key => "Dead";

	public E2_B_DB_Dead(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E2_B_DB_Dead(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		dualBoss.bossA.sm.ForceState("FullDead");
		dualBoss.bossB.sm.ForceState("FullDead");
	}

	public override void UpdateState()
	{
		if (!canExit && (dualBoss.bossA == null || dualBoss.bossB == null))
		{
			canExit = true;
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
