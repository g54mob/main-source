using UnityEngine;

public class E3_5_Attack : StateBaseEnemy
{
	private E3_5_StealthBomber stealthBomber;

	private bool startedStealthing;

	private float stealthTimer;

	private float unstealthTimer;

	public override string Key => "Attack";

	public E3_5_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_5_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		stealthBomber = enemy as E3_5_StealthBomber;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Start Attack");
		stealthBomber.Unstealth();
		stealthBomber.ShotFired = false;
		startedStealthing = false;
		stealthTimer = stealthBomber.stealthTime;
		unstealthTimer = stealthBomber.unstealthTime;
	}

	public override void UpdateState()
	{
		if (!stealthBomber.hasUnstealthed || startedStealthing)
		{
			return;
		}
		unstealthTimer -= Time.deltaTime;
		if (unstealthTimer < 0f && !stealthBomber.ShotFired)
		{
			stealthBomber.Shoot();
		}
		else if (unstealthTimer < 0f && stealthBomber.ShotFired)
		{
			stealthTimer -= Time.deltaTime;
			if (stealthTimer < 0f && !startedStealthing)
			{
				stealthBomber.Stealth();
				startedStealthing = true;
			}
		}
	}

	public override void FixedUpdateState()
	{
		if (unstealthTimer > 0f)
		{
			stealthBomber.Rotator.RotateTowardsPosition(new Vector2(0f, 0f), 60f, 90f);
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return stealthBomber.hasStealthed;
	}
}
