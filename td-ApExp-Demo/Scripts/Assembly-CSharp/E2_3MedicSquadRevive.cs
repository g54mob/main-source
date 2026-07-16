public class E2_3MedicSquadRevive : StateBase
{
	private E2_3MedicSquad enemySquad;

	public override string Key => "Revive";

	public E2_3MedicSquadRevive(StateMachine sm, E2_3MedicSquad enemy)
		: base(sm)
	{
		enemySquad = enemy;
		transitionStates = new string[1] { "Idle" };
	}

	public E2_3MedicSquadRevive(StateMachine sm, E2_3MedicSquad enemy, string[] transitionStates)
		: base(sm, transitionStates)
	{
		enemySquad = enemy;
	}

	public override void Initialize()
	{
	}

	public override bool CanEnter()
	{
		return enemySquad.chargingTimer <= 0f;
	}

	public override void EnterState()
	{
		foreach (E2_3Medic medic in enemySquad.Medics)
		{
			medic.sm.ForceState("Revive");
		}
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
