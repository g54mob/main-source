public class E2_9Idle : StateBaseEnemy
{
	private E2_9RatBiker enemyBiker;

	public override string Key => "Idle";

	public E2_9Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E2_9Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyBiker = enemy as E2_9RatBiker;
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
		if (enemyBiker.TargetUnit == null)
		{
			enemyBiker.Target();
		}
		if (!(enemyBiker.TargetUnit == null))
		{
			enemyBiker.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyBiker.Move();
		if (!(enemyBiker.TargetUnit == null))
		{
			enemyBiker.Aim();
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
