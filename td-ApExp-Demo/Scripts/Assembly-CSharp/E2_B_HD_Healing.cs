public class E2_B_HD_Healing : StateBaseEnemy
{
	private E2_B_HealDrone drone;

	private bool canExit;

	public override string Key => "Healing";

	public E2_B_HD_Healing(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E2_B_HD_Healing(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
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
		drone.StartHealingParticles();
	}

	public override void UpdateState()
	{
		drone.Heal();
		if (drone.targetLeftRange)
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
		drone.StopHealingParticles();
	}
}
