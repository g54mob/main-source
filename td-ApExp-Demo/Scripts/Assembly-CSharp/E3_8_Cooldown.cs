using UnityEngine;

public class E3_8_Cooldown : StateBaseEnemy
{
	private E3_8_LaserDesignator designator;

	public override string Key => "Cooldown";

	public E3_8_Cooldown(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Attack" };
	}

	public E3_8_Cooldown(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		designator = enemy as E3_8_LaserDesignator;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		Debug.LogWarning("Laser Attack");
		designator.SetTargetPos();
		designator.SetIdleTimer();
		designator.TurnOffLaser();
	}

	public override void UpdateState()
	{
		designator.idleTimer -= Time.deltaTime;
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		designator.Move();
		designator.Rotator.RotateToAngle(designator.transform, 0f);
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		if (designator.IsInPosition)
		{
			return designator.idleTimer <= 0f;
		}
		return false;
	}
}
