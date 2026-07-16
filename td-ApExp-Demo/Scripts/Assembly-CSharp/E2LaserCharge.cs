using UnityEngine;

public class E2LaserCharge : StateBaseEnemy
{
	private float chargeUpTimer;

	private E2Laser enemyLaserCutter;

	public override string Key => "LaserCharge";

	public E2LaserCharge(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "LaserShoot" };
	}

	public E2LaserCharge(StateMachine sm, EnemyBase enemy, string[] transitionStates)
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
		enemy.Anim.Play("Charge", 1, 0f);
		enemy.Anim.SetFloat("ChargeMult", 1f / enemyLaserCutter.TimeToCharge);
		enemy.PS.Play();
		chargeUpTimer = enemyLaserCutter.TimeToCharge;
	}

	public override void UpdateState()
	{
		if (enemy.RotateTowardsDirection(Vector3.right))
		{
			enemy.Anim.Play("SpriteSway", 0);
		}
		enemy.Aim();
		chargeUpTimer -= Time.deltaTime;
		if (chargeUpTimer <= 2f)
		{
			enemy.PS.Stop();
		}
		Vector3 vector = enemy.GetNeighborAvoidanceVector();
		enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.transform.position + vector, enemy.MoveSpeed * 0.5f * Time.deltaTime);
	}

	public override void ExitState()
	{
		enemy.Target();
	}

	public override bool CanExit()
	{
		return chargeUpTimer <= 0f;
	}
}
