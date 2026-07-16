public class E3_6_Chicken_Despawn : StateBaseEnemy
{
	private E3_6_Chicken chicken;

	public override string Key => "Despawn";

	public E3_6_Chicken_Despawn(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_6_Chicken_Despawn(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		chicken = enemy as E3_6_Chicken;
	}

	public override bool CanEnter()
	{
		return chicken.readyToRetreat;
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		chicken.Retreat();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
