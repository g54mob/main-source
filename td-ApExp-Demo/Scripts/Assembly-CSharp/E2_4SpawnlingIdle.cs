public class E2_4SpawnlingIdle : StateBaseEnemy
{
	private E2_4Spawnling enemySpawnling;

	public override string Key => "Idle";

	public E2_4SpawnlingIdle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E2_4SpawnlingIdle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySpawnling = enemy as E2_4Spawnling;
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
		if (enemySpawnling.TargetUnit == null)
		{
			enemySpawnling.Target();
		}
		if (!(enemySpawnling.TargetUnit == null))
		{
			enemySpawnling.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemySpawnling.Move();
		enemySpawnling.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
