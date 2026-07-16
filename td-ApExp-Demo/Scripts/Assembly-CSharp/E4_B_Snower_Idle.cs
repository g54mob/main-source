public class E4_B_Snower_Idle : StateBaseEnemy
{
	private E4_B_Snower enemySnower;

	public override string Key => "Idle";

	public E4_B_Snower_Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_B_Snower_Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySnower = enemy as E4_B_Snower;
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
		if (!(enemySnower.TargetUnit == null))
		{
			enemySnower.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemySnower.Move();
		if (!(enemySnower.TargetUnit == null))
		{
			enemySnower.Aim();
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
