using UnityEngine;

public class E3_1_Idle : StateBaseEnemy
{
	private E3_1_Biplane biplane;

	private float shootTimer;

	public override string Key => "Idle";

	public E3_1_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E3_1_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		biplane = enemy as E3_1_Biplane;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		shootTimer = biplane.timeBetweenShots + (float)biplane.ShotsPerBurst * biplane.TimeBetweenShotsInBurst;
	}

	public override void UpdateState()
	{
		shootTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		if (shootTimer < 0f)
		{
			biplane.Shoot();
			shootTimer = biplane.timeBetweenShots;
		}
		biplane.Move();
		biplane.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
