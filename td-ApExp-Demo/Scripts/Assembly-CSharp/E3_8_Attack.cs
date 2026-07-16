using UnityEngine;

public class E3_8_Attack : StateBaseEnemy
{
	private E3_8_LaserDesignator designator;

	public override string Key => "Attack";

	public E3_8_Attack(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Cooldown" };
	}

	public E3_8_Attack(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		designator.TurnOnLaser();
	}

	public override void UpdateState()
	{
		if (designator.LockedOn && !designator.shotFired)
		{
			designator.targetAnim.Play("LaserDesignatorLaserIdle");
			designator.shotFired = true;
			designator.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		designator.Move();
		designator.Aim();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return designator.TargetUnit == null;
	}
}
