public class E2_3MedicSquadIdle : StateBase
{
	private E2_3MedicSquad enemySquad;

	public override string Key => "Idle";

	public E2_3MedicSquadIdle(StateMachine sm, E2_3MedicSquad enemy)
		: base(sm)
	{
		enemySquad = enemy;
		transitionStates = new string[1] { "Charging" };
	}

	public E2_3MedicSquadIdle(StateMachine sm, E2_3MedicSquad enemy, string[] transitionStates)
		: base(sm, transitionStates)
	{
		enemySquad = enemy;
	}

	public override void Initialize()
	{
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		foreach (E2_3Medic medic in enemySquad.Medics)
		{
			medic.sm.ForceState("Idle");
		}
	}

	public override void UpdateState()
	{
		if (enemySquad.TargetUnit == null)
		{
			enemySquad.Target();
		}
		_ = enemySquad.TargetUnit == null;
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemySquad.chargingTimer > 0f;
	}
}
