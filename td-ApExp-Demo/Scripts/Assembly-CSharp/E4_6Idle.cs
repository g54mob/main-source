public class E4_6Idle : StateBaseEnemy
{
	private E4_6BigGuy enemyBigGuy;

	public override string Key => "Idle";

	public E4_6Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Dead" };
	}

	public E4_6Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyBigGuy = enemy as E4_6BigGuy;
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
		if (enemyBigGuy.TargetUnit == null)
		{
			enemyBigGuy.Target();
		}
		if (!(enemyBigGuy.TargetUnit == null))
		{
			enemyBigGuy.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyBigGuy.Move();
		if (enemyBigGuy.TargetUnit == null)
		{
			enemyBigGuy.Target();
		}
		if (!(enemyBigGuy.TargetUnit == null))
		{
			enemyBigGuy.Aim();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemyBigGuy.HealthComponent.IsDead;
	}
}
