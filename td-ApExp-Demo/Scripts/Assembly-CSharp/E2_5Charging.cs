using UnityEngine;

public class E2_5Charging : StateBaseEnemy
{
	private E2_5Sacrificer sacrificer;

	private bool canExit;

	public override string Key => "Charging";

	public E2_5Charging(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Sacrifice" };
	}

	public E2_5Charging(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		sacrificer = enemy as E2_5Sacrificer;
		canExit = false;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Charging");
		if (sacrificer.CompletedSacrifice)
		{
			canExit = true;
			ExitState();
		}
		sacrificer.StartCastingAnim();
		sacrificer.ResetChargingTimer();
		sacrificer.ChoseEnemiesToSacrifice();
		sacrificer.ApplyDamageReduction();
	}

	public override void UpdateState()
	{
		if (sacrificer.ChargingTimerTick())
		{
			canExit = true;
			ExitState();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
