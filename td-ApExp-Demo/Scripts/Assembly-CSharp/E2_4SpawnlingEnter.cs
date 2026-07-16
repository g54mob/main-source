public class E2_4SpawnlingEnter : StateBaseEnemy
{
	private E2_4Spawnling spawnling;

	public override string Key => "Enter";

	public E2_4SpawnlingEnter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_4SpawnlingEnter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		spawnling = enemy as E2_4Spawnling;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		spawnling.SetEnterPos();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		spawnling.EnterBattle();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
