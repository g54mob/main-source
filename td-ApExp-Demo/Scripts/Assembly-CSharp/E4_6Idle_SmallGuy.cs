public class E4_6Idle_SmallGuy : StateBaseEnemy
{
	private E4_6SmallGuy enemySmallGuy;

	public override string Key => "Idle";

	public E4_6Idle_SmallGuy(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_6Idle_SmallGuy(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySmallGuy = enemy as E4_6SmallGuy;
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
		if (enemySmallGuy.TargetUnit == null)
		{
			enemySmallGuy.Target();
		}
		if (!(enemySmallGuy.TargetUnit == null))
		{
			enemySmallGuy.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		if (enemySmallGuy.TargetUnit == null)
		{
			enemySmallGuy.Target();
		}
		if (!(enemySmallGuy.TargetUnit == null))
		{
			enemySmallGuy.Aim();
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
