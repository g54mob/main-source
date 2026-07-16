public class E4_B_Fireshooter_Idle : StateBaseEnemy
{
	private E4_B_Fireshooter enemyFireshooter;

	public override string Key => "Idle";

	public E4_B_Fireshooter_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_B_Fireshooter_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyFireshooter = enemy as E4_B_Fireshooter;
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
		if (enemyFireshooter.TargetUnit == null)
		{
			enemyFireshooter.Target();
		}
		if (!(enemyFireshooter.TargetUnit == null))
		{
			enemyFireshooter.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyFireshooter.Move();
		if (enemyFireshooter.TargetUnit == null)
		{
			enemyFireshooter.Target();
		}
		if (!(enemyFireshooter.TargetUnit == null))
		{
			enemyFireshooter.Aim();
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
