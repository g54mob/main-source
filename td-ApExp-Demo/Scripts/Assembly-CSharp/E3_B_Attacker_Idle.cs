using UnityEngine;

public class E3_B_Attacker_Idle : StateBaseEnemy
{
	private E3_B_Phase1Plane bossPlane;

	public override string Key => "Idle";

	public E3_B_Attacker_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_B_Attacker_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		bossPlane = enemy as E3_B_Phase1Plane;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		if (bossPlane.startingMoveSpeed > 0f)
		{
			bossPlane.MoveSpeed = bossPlane.startingMoveSpeed;
		}
		bossPlane.HealthComponent.IsImmune = false;
		bossPlane.LockRotation = true;
		bossPlane.SetIdleTimer();
		bossPlane.Target();
	}

	public override void UpdateState()
	{
		bossPlane.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		bossPlane.Move();
		bossPlane.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return bossPlane.idleTimer <= 0f;
	}
}
