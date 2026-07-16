public class E2_B_HD_Idle : StateBaseEnemy
{
	private E2_B_HealDrone drone;

	private bool canExit;

	public override string Key => "Idle";

	public E2_B_HD_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Healing" };
	}

	public E2_B_HD_Idle(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		drone = enemy as E2_B_HealDrone;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		canExit = false;
	}

	public override void UpdateState()
	{
		if (drone.targetEnteredRange)
		{
			canExit = true;
		}
	}

	public override bool CanExit()
	{
		return canExit;
	}

	public override void ExitState()
	{
	}
}
