public class E1_B_AimAndFire : StateBaseEnemy
{
	private EnemyCentipede part;

	public override string Key => "AimAndFire";

	public E1_B_AimAndFire(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "DisarmAndClose" };
		part = enemy as EnemyCentipede;
	}

	public E1_B_AimAndFire(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
		part = enemy as EnemyCentipede;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		part.plateAnim.Play("Open");
	}

	public override void UpdateState()
	{
		part.arma.Aim();
		if (!(enemy.shotTimer > 0f))
		{
			part.arma.Fire();
			enemy.shotTimer = part.arma.TimeBetweenShots;
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
