public class E2_1Shoot : StateBaseEnemy
{
	private E2_1EMPLauncher empLauncher;

	public override string Key => "Shoot";

	public E2_1Shoot(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
		empLauncher = enemy as E2_1EMPLauncher;
	}

	public E2_1Shoot(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		empLauncher = enemy as E2_1EMPLauncher;
	}

	public override bool CanEnter()
	{
		return enemy.TargetUnit != null;
	}

	public override void EnterState()
	{
		empLauncher.Shoot();
		empLauncher.Target();
	}

	public override void UpdateState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}

	public override void ExitState()
	{
	}
}
