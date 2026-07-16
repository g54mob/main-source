public class E2_B_ChangeLocation : StateBaseEnemy
{
	private E2_B_BossController boss;

	private bool canExit;

	public override string Key => "Move";

	public E2_B_ChangeLocation(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[3] { "ChainAttack", "BasicAttack", "Exit" };
	}

	public E2_B_ChangeLocation(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
