public class E4_7Idle : StateBaseEnemy
{
	private E4_7Snowmaker enemySnowmaker;

	public override string Key => "Idle";

	public E4_7Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_7Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySnowmaker = enemy as E4_7Snowmaker;
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
		if (!(enemySnowmaker.TargetUnit == null))
		{
			enemySnowmaker.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemySnowmaker.Move();
		if (!(enemySnowmaker.TargetUnit == null))
		{
			enemySnowmaker.Aim();
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
