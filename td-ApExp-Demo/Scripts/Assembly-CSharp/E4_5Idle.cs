public class E4_5Idle : StateBaseEnemy
{
	private E4_5Hunter enemyHunter;

	public override string Key => "Idle";

	public E4_5Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_5Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyHunter = enemy as E4_5Hunter;
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
		if (enemyHunter.TargetUnit == null)
		{
			enemyHunter.Target();
		}
		if (!(enemyHunter.TargetUnit == null))
		{
			enemyHunter.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		if (enemyHunter.TargetUnit == null)
		{
			enemyHunter.Target();
		}
		if (!(enemyHunter.TargetUnit == null))
		{
			enemyHunter.Aim();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
