public class E3_3_Target : StateBaseEnemy
{
	private E3_3_Helicopter helicopter;

	public override string Key => "Target";

	public E3_3_Target(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_3_Target(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		helicopter.Target();
		helicopter.Ignite();
	}

	public override void UpdateState()
	{
	}

	public override void FixedUpdateState()
	{
		helicopter.Aim();
		helicopter.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (helicopter.IsInPosition)
		{
			return helicopter.LockedOn;
		}
		return false;
	}
}
