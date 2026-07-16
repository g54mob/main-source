using UnityEngine;

public class E3_2_GoToStart : StateBaseEnemy
{
	private E3_2_Falcon falcon;

	private float holdTimer;

	public override string Key => "GoToStart";

	public E3_2_GoToStart(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Idle" };
	}

	public E3_2_GoToStart(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		falcon.SetStartingPos();
		falcon.IsInPosition = false;
		holdTimer = 1f;
	}

	public override void UpdateState()
	{
		if (falcon.IsInPosition)
		{
			holdTimer -= Time.deltaTime;
		}
	}

	public override void FixedUpdateState()
	{
		falcon.Rotator.RotateToAngle(falcon.transform, 0f);
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (falcon.IsInPosition)
		{
			return holdTimer <= 0f;
		}
		return false;
	}
}
