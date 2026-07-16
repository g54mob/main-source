using UnityEngine;

public class E2LaserShoot : StateBaseEnemy
{
	private E2Laser enemyLaserCutter;

	public override string Key => "LaserShoot";

	public E2LaserShoot(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[2] { "Idle", "LaserCharge" };
	}

	public E2LaserShoot(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyLaserCutter = enemy as E2Laser;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		enemy.Anim.Play("Shoot", 1, 0f);
		enemyLaserCutter.isFiringComplete = false;
		enemyLaserCutter.FlipRotateDirection();
	}

	public override void UpdateState()
	{
		if (enemy.RotateTowardsDirection(Vector3.right))
		{
			enemy.Anim.Play("SpriteSway", 0);
		}
		enemy.Aim();
		enemy.Shoot();
	}

	public override bool CanExit()
	{
		return enemyLaserCutter.isFiringComplete;
	}

	public override void ExitState()
	{
		enemyLaserCutter.unitsHitList.Clear();
		enemyLaserCutter.SetLr(Vector2.zero, Vector2.zero);
	}
}
