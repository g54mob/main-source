public class E3_8_EMPState : BEMPState
{
	private E3_8_LaserDesignator laserDesignator;

	public override string Key => "EMP";

	public E3_8_EMPState(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		laserDesignator = enemy as E3_8_LaserDesignator;
		transitionStates = new string[2] { "Idle", "Move" };
	}

	public E3_8_EMPState(StateMachine sm, EnemyBase enemy, params string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		laserDesignator = enemy as E3_8_LaserDesignator;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		base.EnterState();
		laserDesignator.TryInterruptShoot();
	}

	public override void ExitState()
	{
		base.ExitState();
	}

	public override bool CanExit()
	{
		return base.CanExit();
	}
}
