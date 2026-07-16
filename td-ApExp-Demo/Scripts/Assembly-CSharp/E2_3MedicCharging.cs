public class E2_3MedicCharging : StateBaseEnemy
{
	private E2_3Medic medic;

	public override string Key => "Charging";

	public E2_3MedicCharging(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Revive", "Dead" };
	}

	public E2_3MedicCharging(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		medic = enemy as E2_3Medic;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		medic.SetChargingAnim();
	}

	public override void UpdateState()
	{
		if (!medic.HealthComponent.IsDead)
		{
			if (medic.TargetUnit == null)
			{
				medic.Target();
			}
			if (!(medic.TargetUnit == null))
			{
				medic.Aim();
				medic.Shoot();
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
