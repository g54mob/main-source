public class E2_8Idle : StateBaseEnemy
{
	private E2_8MedDart medDart;

	private bool canExit;

	public override string Key => "Idle";

	public E2_8Idle(StateMachine sm, EnemyBase enemy)
		: base(sm, enemy)
	{
		transitionStates = new string[1] { "Heal" };
	}

	public E2_8Idle(StateMachine sm, EnemyBase enemy, string[] transitionStates)
		: base(sm, enemy, transitionStates)
	{
	}

	public override void Initialize()
	{
		medDart = enemy as E2_8MedDart;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		canExit = false;
	}

	public override void UpdateState()
	{
		if (medDart.TargetUnit == null || !medDart.CheckIsTargetHealable())
		{
			medDart.Target();
		}
		if (medDart.targetEnteredRange && medDart.CheckIsTargetHealable())
		{
			canExit = true;
			ExitState();
		}
	}

	public override void FixedUpdateState()
	{
		base.FixedUpdateState();
		medDart.Move();
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return canExit;
	}
}
