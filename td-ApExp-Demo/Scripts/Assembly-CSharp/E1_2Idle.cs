using UnityEngine;

public class E1_2Idle : StateBaseEnemy
{
	private E1_2Technical enemyTechnical;

	public override string Key => "Idle";

	public E1_2Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Spinning" };
	}

	public E1_2Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyTechnical = enemy as E1_2Technical;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemyTechnical.SetIdleTimer();
	}

	public override void UpdateState()
	{
		enemyTechnical.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyTechnical.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (enemyTechnical.IsInPosition)
		{
			return enemyTechnical.idleTimer <= 0f;
		}
		return false;
	}
}
