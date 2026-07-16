public class E2_4Spawn : StateBaseEnemy
{
	private E2_4Spawner enemySpawner;

	public override string Key => "Spawn";

	public E2_4Spawn(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_4Spawn(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySpawner = enemy as E2_4Spawner;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemySpawner.OpenDoor();
	}

	public override void UpdateState()
	{
		if (enemySpawner.spawnFinished)
		{
			enemySpawner.spawnFinished = false;
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
