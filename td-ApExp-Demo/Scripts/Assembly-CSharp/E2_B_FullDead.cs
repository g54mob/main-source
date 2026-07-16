public class E2_B_FullDead : StateBaseEnemy
{
	private E2_B_BossController boss;

	private float deathTimer = 5f;

	public override string Key => "FullDead";

	public E2_B_FullDead(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[0];
	}

	public E2_B_FullDead(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		boss.CancelChainAttack();
		boss.OnFullDead();
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
