using UnityEngine;

public class E2_3MedicSquadCharging : StateBase
{
	private E2_3MedicSquad enemySquad;

	public override string Key => "Charging";

	public E2_3MedicSquadCharging(StateMachine sm, E2_3MedicSquad enemy)
		: base(sm)
	{
		enemySquad = enemy;
		transitionStates = new string[1] { "Revive" };
	}

	public E2_3MedicSquadCharging(StateMachine sm, E2_3MedicSquad enemy, string[] transitionStates)
		: base(sm, transitionStates)
	{
		enemySquad = enemy;
	}

	public override void Initialize()
	{
	}

	public override bool CanEnter()
	{
		return enemySquad.chargingTimer > 0f;
	}

	public override void EnterState()
	{
		enemySquad.chargingTimer = enemySquad.ChargeTime;
		foreach (E2_3Medic medic in enemySquad.Medics)
		{
			medic.sm.ForceState("Charging");
		}
	}

	public override void UpdateState()
	{
		if ((enemySquad.chargingTimer -= Time.deltaTime) <= 0f)
		{
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return enemySquad.chargingTimer <= 0f;
	}
}
