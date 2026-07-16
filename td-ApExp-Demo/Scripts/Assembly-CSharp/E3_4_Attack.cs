using UnityEngine;

public class E3_4_Attack : StateBaseEnemy
{
	private E3_4_EjectorBomber ejector;

	private float aimingTimer;

	private float resetingTimer;

	private bool startedShooting;

	public override string Key => "Attack";

	public E3_4_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_4_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		ejector = enemy as E3_4_EjectorBomber;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		aimingTimer = 2f;
		startedShooting = false;
		resetingTimer = 2f;
		ejector.Hover(enterHover: true);
		ejector.lockHover = true;
		ejector.finishedShooting = false;
	}

	public override void UpdateState()
	{
		aimingTimer -= Time.deltaTime;
		if (ejector.finishedShooting)
		{
			resetingTimer -= Time.deltaTime;
		}
	}

	public override void FixedUpdateState()
	{
		ejector.Move();
		ejector.Aim();
		if (aimingTimer < 0f && !startedShooting)
		{
			ejector.Shoot();
			startedShooting = true;
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return resetingTimer < 0f;
	}
}
