public class E4_4Idle : StateBaseEnemy
{
	private E4_4SnotLauncher enemySnotLauncher;

	public override string Key => "Idle";

	public E4_4Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_4Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		enemySnotLauncher = enemy as E4_4SnotLauncher;
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
		if (enemySnotLauncher.TargetUnit == null)
		{
			enemySnotLauncher.Target();
		}
		if (!(enemySnotLauncher.TargetUnit == null))
		{
			enemySnotLauncher.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		enemySnotLauncher.Move();
		if (enemySnotLauncher.TargetUnit == null)
		{
			enemySnotLauncher.Target();
		}
		if (!(enemySnotLauncher.TargetUnit == null))
		{
			enemySnotLauncher.Aim();
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
