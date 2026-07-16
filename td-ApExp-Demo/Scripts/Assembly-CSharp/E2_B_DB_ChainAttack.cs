using UnityEngine;

public class E2_B_DB_ChainAttack : StateBaseEnemy
{
	private E2_B_DualBossController dualBoss;

	private bool canExit;

	public override string Key => "ChainAttack";

	public E2_B_DB_ChainAttack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "Exit" };
	}

	public E2_B_DB_ChainAttack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		dualBoss.StartChainAttack();
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (!dualBoss.ChainAttackComplete)
		{
			return dualBoss.ChainsBroke;
		}
		return true;
	}
}
