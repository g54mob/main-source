public class E2_B_Dead : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "Dead";

	public E2_B_Dead(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_Dead(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void UpdateState()
	{
		if (boss.Revived)
		{
			boss.HealthComponent.StopBurn();
			canExit = true;
			ExitState();
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
