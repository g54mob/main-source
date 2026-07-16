public class E2_3MedicIdle : StateBaseEnemy
{
	private E2_3Medic enemyBiker;

	public override string Key => "Idle";

	public E2_3MedicIdle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Charging", "Dead" };
	}

	public E2_3MedicIdle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyBiker = enemy as E2_3Medic;
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
		if (!enemyBiker.HealthComponent.IsDead)
		{
			if (enemyBiker.TargetUnit == null)
			{
				enemyBiker.Target();
			}
			if (!(enemyBiker.TargetUnit == null))
			{
				enemyBiker.Aim();
				enemyBiker.Shoot();
			}
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
