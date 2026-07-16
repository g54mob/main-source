public class E4ShootLRLR : StateBaseEnemy
{
	private E4Cocoon enemyCocooner;

	private int shotsFired;

	private const int shotsMax = 4;

	public override string Key => "ShootThrice";

	public E4ShootLRLR(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "CloseShield" };
		enemyCocooner = enemy as E4Cocoon;
	}

	public E4ShootLRLR(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		enemyCocooner = enemy as E4Cocoon;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		shotsFired = 0;
		enemy.shotTimer = enemy.timeBetweenShots;
	}

	public override void UpdateState()
	{
		enemy.Aim();
		if (!(enemy.shotTimer > 0f) && shotsFired < 4)
		{
			enemyCocooner.Shoot(shotsFired);
			shotsFired++;
			enemy.shotTimer = enemy.timeBetweenShots;
		}
	}

	public override bool CanExit()
	{
		if (shotsFired >= 4)
		{
			return enemy.shotTimer <= 0f - enemy.timeBetweenShots;
		}
		return false;
	}

	public override void ExitState()
	{
	}
}
