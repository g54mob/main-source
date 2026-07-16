public class E3_3_Enter : StateBaseEnemy
{
	private E3_3_Helicopter helicopter;

	public override string Key => "Enter";

	public E3_3_Enter(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_3_Enter(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		helicopter = enemy as E3_3_Helicopter;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		helicopter.SetEnterPos();
		helicopter.TargetUnit = null;
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		helicopter.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return helicopter.IsInPosition;
	}
}
