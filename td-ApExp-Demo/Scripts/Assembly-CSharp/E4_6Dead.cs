public class E4_6Dead : StateBaseEnemy
{
	private E4_6BigGuy enemyBigGuy;

	public override string Key => "Dead";

	public E4_6Dead(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_6Dead(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
