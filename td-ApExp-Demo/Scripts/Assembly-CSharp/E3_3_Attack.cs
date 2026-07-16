using UnityEngine;

public class E3_3_Attack : StateBaseEnemy
{
	private E3_3_Helicopter helicopter;

	private float burnTimer;

	public override string Key => "Attack";

	public E3_3_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_3_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		helicopter = enemy as E3_3_Helicopter;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		helicopter.Shoot();
		burnTimer = helicopter.FlameDuration;
	}

	public override void UpdateState()
	{
		burnTimer -= Time.deltaTime;
		helicopter.TickDamage();
	}

	public override void FixedUpdateState()
	{
		helicopter.Swivel();
		helicopter.Hover();
	}

	public override void ExitState()
	{
		if (helicopter.isFiring)
		{
			helicopter.ApplyBurn();
		}
		helicopter.Extinguish();
		helicopter.TargetUnit = null;
	}

	public override bool CanExit()
	{
		return burnTimer < 0f;
	}
}
