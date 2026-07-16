public class E4_3Idle : StateBaseEnemy
{
	private E4_3Harpooner enemyHarpooner;

	public override string Key => "Idle";

	public E4_3Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_3Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemyHarpooner = enemy as E4_3Harpooner;
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
		if (enemyHarpooner.TargetUnit == null)
		{
			enemyHarpooner.Target();
		}
		if (!(enemyHarpooner.TargetUnit == null) && enemyHarpooner.readyToFire)
		{
			enemyHarpooner.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemyHarpooner.Move();
		if (enemyHarpooner.TargetUnit == null)
		{
			enemyHarpooner.Target();
		}
		if (!(enemyHarpooner.TargetUnit == null))
		{
			enemyHarpooner.Aim();
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
