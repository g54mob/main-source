public class E4_1Idle : StateBaseEnemy
{
	private E4_1SplitShooter splitShooter;

	public override string Key => "Idle";

	public E4_1Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "" };
	}

	public E4_1Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		splitShooter = enemy as E4_1SplitShooter;
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
		if ((!(splitShooter == null) && !(splitShooter.HealthComponent == null) && splitShooter.IsDead) || !(splitShooter.TargetUnit1 == null) || !(splitShooter.TargetUnit2 == null))
		{
			splitShooter.Shoot();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		splitShooter.Move();
		if (!(splitShooter.TargetUnit1 == null) || !(splitShooter.TargetUnit2 == null))
		{
			splitShooter.Aim();
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
