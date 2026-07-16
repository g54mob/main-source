public class E1_B_Idle : StateBaseEnemy
{
	private EnemyCentipede part;

	public override string Key => "Idle";

	public E1_B_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "OpenAndArm" };
		part = enemy as EnemyCentipede;
	}

	public E1_B_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		part = enemy as EnemyCentipede;
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

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return !part.controller.offScreen;
	}
}
