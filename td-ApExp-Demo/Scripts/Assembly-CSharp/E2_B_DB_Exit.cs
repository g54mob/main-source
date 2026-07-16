using UnityEngine;

public class E2_B_DB_Exit : StateBaseEnemy
{
	private E2_B_DualBossController dualBoss;

	private bool canExit;

	public override string Key => "Exit";

	public E2_B_DB_Exit(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Enter" };
	}

	public E2_B_DB_Exit(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		dualBoss = enemy as E2_B_DualBossController;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning($"{dualBoss}: {sm.CurrentState}");
		canExit = false;
		dualBoss.Exit();
		Train.Instance.RemoveSlowDebuff();
	}

	public override void UpdateState()
	{
		dualBoss.sm.ForceState("Idle");
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
