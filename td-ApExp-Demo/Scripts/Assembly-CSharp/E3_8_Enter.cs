public class E3_8_Enter : StateBaseEnemy
{
	private E3_8_LaserDesignator designator;

	public override string Key => "Enter";

	public E3_8_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_8_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		designator = enemy as E3_8_LaserDesignator;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		designator.SetTargetPos();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		designator.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return designator.IsInPosition;
	}
}
