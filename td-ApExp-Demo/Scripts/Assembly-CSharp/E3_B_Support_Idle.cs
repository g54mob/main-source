using UnityEngine;

public class E3_B_Support_Idle : StateBaseEnemy
{
	private E3_B_Phase1Plane_Support bossPlane;

	public override string Key => "Idle";

	public E3_B_Support_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Heal" };
	}

	public E3_B_Support_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bossPlane = enemy as E3_B_Phase1Plane_Support;
	}

	public override bool CanEnter()
	{
		return bossPlane.FinishedHealing;
	}

	public override void EnterState()
	{
		if (bossPlane.startingMoveSpeed > 0f)
		{
			bossPlane.MoveSpeed = bossPlane.startingMoveSpeed;
		}
		bossPlane.HealthComponent.IsImmune = false;
		Debug.LogWarning("Entering Idle State");
		bossPlane.SetIdleTimer();
		bossPlane.LockRotation = true;
	}

	public override void UpdateState()
	{
		bossPlane.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		bossPlane.Move();
	}

	public override void ExitState()
	{
		bossPlane.ResetHealingTimer();
	}

	public override bool CanExit()
	{
		return bossPlane.idleTimer <= 0f;
	}
}
