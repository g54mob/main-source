using System;
using UnityEngine;

public class E3_2_CrossOver : StateBaseEnemy
{
	private E3_2_Falcon falcon;

	private float holdTimer;

	private bool hasShot;

	private bool rotatedBack;

	private float turnTime = 0.5f;

	public override string Key => "CrossOver";

	public E3_2_CrossOver(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "GoToStart" };
	}

	public E3_2_CrossOver(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		falcon = enemy as E3_2_Falcon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		falcon.SetCrossOverPos();
		falcon.IsInPosition = false;
		falcon.ShotLoaded = true;
		falcon.LockRotation = false;
		falcon.Rotator.RotateComponentTowardsPosition(falcon.transform, falcon.TargetPos);
		holdTimer = 0.2f;
		rotatedBack = false;
		falcon.Anim.Play("FalconBomberDive");
		hasShot = false;
		falcon.MoveSpeed *= 2f;
		falcon.PlayShootSound();
	}

	public override void UpdateState()
	{
		falcon.Rotator.RotateTowardsMovementVector(90f);
		if (falcon.IsInPosition)
		{
			holdTimer -= Time.deltaTime;
		}
		if (falcon.ShotLoaded && MathF.Abs(falcon.transform.position.y) < 0.5f)
		{
			falcon.Shoot();
			if (!rotatedBack)
			{
				rotatedBack = true;
				falcon.Rotator.RotateToAngle(falcon.transform, 0f);
			}
			hasShot = true;
		}
	}

	public override void ExitState()
	{
		falcon.Anim.Play("FalconBomberFlight");
		falcon.Rotator.RotateToAngle(falcon.transform, 0f);
		falcon.MoveSpeed *= 0.5f;
	}

	public override bool CanExit()
	{
		if (hasShot)
		{
			return holdTimer <= 0f;
		}
		return false;
	}
}
