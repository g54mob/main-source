public class E1_2Firing : StateBaseEnemy
{
	private E1_2Technical technical;

	public override string Key => "Firing";

	public E1_2Firing(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Cooling" };
	}

	public E1_2Firing(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		technical = enemy as E1_2Technical;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		technical.SwapTargets();
		technical.RotationProgress = 0f;
		technical.ShootAnim();
	}

	public override void UpdateState()
	{
		if (!technical.IsEnemy && technical.TargetUnits.Item2 == null)
		{
			technical.Target();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		technical.Aim();
	}

	public override void ExitState()
	{
		technical.StopShooting();
	}

	public override bool CanExit()
	{
		if (!technical.IsEnemy)
		{
			return false;
		}
		return technical.RotationProgress >= 0.95f;
	}
}
