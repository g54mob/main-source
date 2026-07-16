public class E4_B_Rocketeer_Idle : StateBaseEnemy
{
	private E4_B_Rocketeer enemyRocketeer;

	public override string Key => "Idle";

	public E4_B_Rocketeer_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_B_Rocketeer_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyRocketeer = enemy as E4_B_Rocketeer;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
	}

	public override void UpdateState()
	{
		if (enemyRocketeer.TargetUnit == null)
		{
			enemyRocketeer.Target();
		}
		if (!(enemyRocketeer.TargetUnit == null))
		{
			enemyRocketeer.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyRocketeer.Move();
		if (enemyRocketeer.TargetUnit == null)
		{
			enemyRocketeer.Target();
		}
		if (!(enemyRocketeer.TargetUnit == null))
		{
			enemyRocketeer.Aim();
		}
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return false;
	}
}
